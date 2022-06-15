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
        void UpdateQuestionVotesCount(Question que);
        void UpdateQuestionAnswerCount(int que);
        void UpdateQuestionViewCount(int que);
        void DeleteQuestion(int que);
        List<Question> GetAllQuestions();
        List<Question> GetQuestionsByQuestionID(int que);
    }
    public class QuestionsRepository
    {
        StackOverflowDatabaseDBContext db;
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

            }
            db.SaveChanges();
        }

        public void UpdateQuestionVotesCount(Question que)
        {
           Question ques =  db.Question.Where(temp=>temp.VotesCount == que.VotesCount).FirstOrDefault();
            if (ques != null)
            {
                ques.VotesCount = que.VotesCount + 1;
                
            }
            db.SaveChanges();
        }

        public void UpdateAnswerViewCount(Question que)
        {
            Question ques = db.Question.Where(temp => temp.AnswerCount == que.AnswerCount).FirstOrDefault();
            if (ques != null)
            {
                ques.AnswerCount = que.AnswerCount + 1;

            }
            db.SaveChanges();
        }

        public void UpdateQuestionViewCount(Question que)
        {
            Question ques = db.Question.Where(temp => temp.ViewCount == que.ViewCount).FirstOrDefault();
            if (ques != null)
            {
                ques.ViewCount = que.ViewCount + 1;

            }
            db.SaveChanges();
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
