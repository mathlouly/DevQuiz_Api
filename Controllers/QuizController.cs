using Microsoft.AspNetCore.Mvc;
using devquiz_api.Models;
using devquiz_api.Services;
using System.ComponentModel.DataAnnotations;

namespace devquiz_api.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;

        public QuizController(QuizService quizService) {
            _quizService = quizService;
        }

        [HttpPost]
        public ActionResult<dynamic> Post([FromBody]QuizModel quizModel) => _quizService.PostQuiz(quizModel);

        [HttpGet]
        public dynamic Get() => _quizService.GetQuizzes();

        [HttpPut]
        public ActionResult<dynamic> Put([FromBody]QuizModel quizModel) => _quizService.PutQuiz(quizModel);

        [HttpDelete]
        public ActionResult<dynamic> Delete([FromForm]string idQuiz) => _quizService.DeleteQuiz(idQuiz);

    }
}