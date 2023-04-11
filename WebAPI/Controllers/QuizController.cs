using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    //[ApiController]
    //[Route("/api/v1/quizzes")]
    public class QuizController : Controller
    {
        private readonly IQuizUserService _services;
        public QuizController(IQuizUserService service)
        {
            _services = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var result = QuizDto.of(_services.FindQuizById(id));
            if(result is null)
            {
               return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            return _services.FindAllQuizzes().Select(QuizDto.of).AsEnumerable();
        }
        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto,[FromRoute] int quizId, [FromRoute] int itemId)
        {
            _services.SaveUserAnswerForQuiz(quizId, itemId, dto.Id, dto.Answer);

        }
        [HttpGet("correct_answers")]
        public int CorrectAnswers(int quizId, int userId)
        {
            return _services.CountCorrectAnswersForQuizFilledByUser(quizId,userId);
        }

    }
}
