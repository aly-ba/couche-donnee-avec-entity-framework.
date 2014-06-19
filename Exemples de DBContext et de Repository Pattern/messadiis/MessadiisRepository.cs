using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESSADIIS.Data
{
    public class MessadiisRepository : IMessadiisRepository
    {
        //the goog choice is to create an instance of the db context hihin lol
        //bonne pratique je préfére because DbContext n'est une classe statique ici lol et
        // ne le sera jaamais pour moi pour de rire ni abstract, ni extension method avec db context

        MessadiisContext _ctx;

        public MessadiisRepository(MessadiisContext ctx) 
        {
            _ctx = ctx;
        }

        
        public IQueryable<Question> GetQuestions()
        {
            //the context is a disposable object


            return _ctx.Questions;
        }

        public IQueryable<Reponse> GetReponsesByQuestion(int QuestionId)
        {
            return _ctx.Reponses.Where(r => r.QuestionId == QuestionId);
        }


        public bool Save()
        {
            try
            {
                //retourne an integer of how many request we done
                return  _ctx.SaveChanges() >0 ;

            }
            catch (Exception ex) 
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddQuestion(Question newQuestion)
        {
            try
            {
                _ctx.Questions.Add(newQuestion);
                return true;
            }

            catch (Exception ex)
            {
                //TODO log this error
                return false; 
            }
        }


        public IQueryable<Question> GetQuestionsInclusReponses()
        {
           return _ctx.Questions.Include("Reponses");
        }


        public bool AddReponse(Reponse newReponse)
        {
            try
            {
                _ctx.Reponses.Add(newReponse);
                return true;
            }

            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }
    }
}