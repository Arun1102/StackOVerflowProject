using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface IQuestionRepository
    {
        void AddQuestion(Question que);
        void UpdateQuestionDetails(Question que);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswerCount(int que, int value);
        void UpdateQuestionViewCount(int que, int value);
        void DeleteQuestion(int que);
        List<Question> GetAllQuestions();
        List<Question> GetQuestionsByQuestionID(int que);
    }
    public class QuestionsRepository:IQuestionRepository
    {
        StackOverflowDatabaseDBContext db;
        IQuestionRepository qr;
        IVotesRepository vr;
        public QuestionsRepository()
        {
            db = new StackOverflowDatabaseDBContext();
            
        }

        public void AddQuestion(Question que)
        {
            db.Question.Add(que);
            db.SaveChanges();
        }

        public void UpdateQuestionDetails(Question que)
        {
            Question ques = db.Question.Where(temp => temp.QuestionID == que.QuestionID).FirstOrDefault();
            if(ques != null)
            {
                ques.QuestionName = que.QuestionName;
                ques.QuestionDateAndTime = que.QuestionDateAndTime;
                ques.CategoryID = que.CategoryID;
                db.SaveChanges();
            }
            
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
           Question ques =  db.Question.Where(temp=>temp.VotesCount == qid).FirstOrDefault();
            if (ques != null)
            {
                ques.VotesCount += value;
                db.SaveChanges();
               
                
            }
            
        }

        public void UpdateQuestionAnswerCount(int que, int value)
        {
            Question ques = db.Question.Where(temp => temp.AnswerCount == que).FirstOrDefault();
            if (ques != null)
            {
                ques.AnswerCount += value;
                db.SaveChanges();
                
            }
           
        }

        public void UpdateQuestionViewCount(int que, int value)
        {
            Question ques = db.Question.Where(temp => temp.ViewCount == que).FirstOrDefault();
            if (ques != null)
            {
                ques.ViewCount += value;
                db.SaveChanges();
            }
           
        }

        public void DeleteQuestion(int que)
        {
            Question ques = db.Question.Where(temp=> temp.QuestionID == que).FirstOrDefault();
            if(ques != null)
            {
                db.Question.Remove(ques);
            }
            db.SaveChanges();
        }

        public List<Question> GetAllQuestions()
        {
            List<Question> list = db.Question.ToList();
            return list;
        }

        public List<Question> GetQuestionsByQuestionID(int que)
        {
           List<Question> ques =  db.Question.Where(temp=>temp.QuestionID == que).ToList();
           return ques;
        }

    }
}
