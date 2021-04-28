using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace devquiz_api.Models
{
    public class QuizModel
    {
         [BsonId]
         [BsonRepresentation(BsonType.ObjectId)]
         public string id {get; set;}
         [Required]
         public string title {get; set;}
         [Required]
         [MinLength(1, ErrorMessage = "Quantidade mínima de questões = 1")]
         public List<Question> questions {get; set;}
         [Required]
         public string imagem {get; set;}
         [Required]
         public string level {get; set;}
    }

    public class Question
    {
        [Required]
        public string title {get; set;}
        [Required]
        [MinLength(4, ErrorMessage = "Quantidade mínima de alternativas = 4")]
        [MaxLength(4, ErrorMessage = "Quantidade máxima de alternativas = 4")]
        public List<Answer> answers {get; set;}
    }

    public class Answer
    {
        [Required]
        public string title {get; set;}
        [BsonRepresentation(BsonType.Boolean)]
        public bool isRight {get; set;}
    }
}