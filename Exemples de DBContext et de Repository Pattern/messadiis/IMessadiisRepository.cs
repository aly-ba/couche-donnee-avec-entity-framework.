using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESSADIIS.Data
{
    public interface IMessadiisRepository
    {
        IQueryable<Question> GetQuestions();
        IQueryable<Question> GetQuestionsInclusReponses();
        IQueryable<Reponse> GetReponsesByQuestion(int QuestionId);

        bool Save();

        bool AddQuestion(Question  newQuestion);
        bool AddReponse(Reponse newReponse);

    }
}