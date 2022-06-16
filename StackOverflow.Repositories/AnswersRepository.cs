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
        void UpdateAnswerVotesCount(int a, int uid, int value);
        List<Answers> GetAllAnswers();
        List<Answers> GetAnswersByAnswerID( int a);
    }
    public class AnswersRepository:IAnswersRepository
    {
        StackOverflowDatabaseDBContext db;
        IQuestionRepository qr;
        IVotesRepository vos;

        public AnswersRepository()
        {
            db = new StackOverflowDatabaseDBContext();
            qr = new QuestionsRepository();
            vos = new VotesRepository();
        }

        public void InsertAnswers(Answers a)
        {
            db.Answers.Add(a);
            db.SaveChanges();
            qr.UpdateQuestionAnswerCount(a.QuestionID, 1);
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
                qr.UpdateQuestionAnswerCount(ans.QuestionID, -1);
                
            }
            db.SaveChanges();
        }

        //public void UpdateAnswerVotesCount(int a, int value);
        //{
        //   Answers ans =  db.Answers.Where(temp => temp.AnswerID == a ).FirstOrDefault();
        //    if (ans != null)
        //    {
        //        ans.VotesCount += ValueTask;
        //        db.SaveChanges();
        //    }
            
        //}

        public void UpdateAnswerVotesCount(int a,int uid, int value)
        {
            Answers au = db.Answers.Where(temp => temp.AnswerID == a).FirstOrDefault();
            if (au != null)
            {
                au.VotesCount += value;
                db.SaveChanges();
                qr.UpdateQuestionVotesCount(au.QuestionID, value);
                vos.UpdateVotes(a, uid, value);
            }
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
