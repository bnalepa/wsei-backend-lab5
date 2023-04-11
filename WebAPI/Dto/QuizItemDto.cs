using ApplicationCore.Models;
using WebAPI.Controllers;

namespace WebAPI.Dto
{
    public class QuizItemDto
    {
        public int Id { get; set; }
        public string Question  { get; set; }
        public IEnumerable<string> Options { get; set; }

        public static QuizItemDto of(QuizItem quiz)
        {
            QuizItemDto quizItemDto = new QuizItemDto()
            {
                Id = quiz.Id,
                Question = quiz.Question,
                Options = quiz.IncorrectAnswers.Append(quiz.CorrectAnswer)
            };

            return quizItemDto;

        }
    }
}
