using Microsoft.AspNetCore.Mvc;
using devquiz_api.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;

namespace devquiz_api.Services
{
    public class QuizService : ControllerBase
    {
        private readonly IMongoCollection<QuizModel> _mongoCollection;

        public QuizService(IDatabaseSetting databaseSetting)
        {
            MongoClient _client = new MongoClient(databaseSetting.ConnectionString);
            IMongoDatabase _mongoDatabase = _client.GetDatabase("QuizDatabase");
            _mongoCollection = _mongoDatabase.GetCollection<QuizModel>("quizzes");
        }

        public ActionResult PostQuiz(QuizModel quizModel) {
            QuizModel _quizModel = new QuizModel() {
                id = ObjectId.GenerateNewId().ToString(),
                title=quizModel.title,
                questions=quizModel.questions,
                imagem=quizModel.imagem,
                level=quizModel.level
            };
            _mongoCollection.InsertOne(quizModel);
            return Created("Criado com Sucesso!", _quizModel);
        }
        
        public ActionResult GetQuizzes() {
            List<QuizModel> _listQuiz = _mongoCollection.Find<QuizModel>(quiz => true).ToList();
            return Ok(_listQuiz);
        }

        public ActionResult PutQuiz(QuizModel quizModel) {
            try
            {
                _mongoCollection.FindOneAndReplace<QuizModel>(quiz => quiz.id == quizModel.id, quizModel);
                return Ok("Quiz alterado com sucesso!");
            }
            catch (System.Exception)
            {
                return NotFound("Quiz não encontrado!");
            }
        }

        public ActionResult DeleteQuiz(string idQuiz) {
            try
            {
                QuizModel quiz = _mongoCollection.FindOneAndDelete<QuizModel>(quiz => quiz.id == idQuiz);
                return quiz != null ? Ok($"Quiz de id {idQuiz} deletado!") : Ok("id informado não existe!");
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}