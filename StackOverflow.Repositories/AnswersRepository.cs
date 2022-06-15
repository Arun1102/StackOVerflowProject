using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface IAnswersRepository
    {
        void InsertAnswers(Answers a);
        void UpdateAnswers(Answers a);
        void DeleteAnswers(int a);
        void UpdateAnswerVotesCount(Answers a);
        List<Answers> GetAllAnswers();
        List<Answers> GetAnswersByAnswerID( int a);
    }
    public class AnswersRepository
    {
        StackOverflowDatabaseDBContext db;

        public AnswersRepository()
        {
            db = new StackOverflowDatabaseDBContext();
        }

        public void InsertAnswers(Answers a)
        {
            db.Answers.Add(a);
            db.SaveChanges();
        }

        public void UpdateAnswers(Answers a)
        {
            Answers ans = db.Answers.Where(temp=>temp.AnswerID == a.AnswerID).FirstOrDefault();
            if (ans != null)
            {
                ans.AnswerText = a.AnswerText;
            }
            db.SaveChanges();
        }

        public void DeleteAnswers(int a)
        {
            Answers ans = db.Answers.Where(temp => temp.AnswerID == a).FirstOrDefault();
            if(ans != null)
            {
                db.Answers.Remove(ans);

            }
            db.SaveChanges();
        }

        public void UpdateAnswerVotesCount(Answers a)
        {
           Answers ans =  db.Answers.Where(temp => temp.AnswerID == a.AnswerID).FirstOrDefault();
            if (ans != null)
            {
                ans.VotesCount = a.VotesCount + 1 ;
            }
            db.SaveChanges ();
        }

        public List<Answers> GetAllAnswers()
        {
           List<Answers> ans =  db.Answers.ToList();
            return ans;
        }

        public List<Answers> GetAnswersByAnswerID(int a)
        {
            List<Answers> ans = db.Answers.Where(temp => temp.AnswerID == a).ToList();
            return ans;
        }

    }
}
