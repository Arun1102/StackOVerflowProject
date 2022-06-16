using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVotes(int a, int uid, int value);
    }
    public class VotesRepository:IVotesRepository
    {
        StackOverflowDatabaseDBContext db;
        public VotesRepository()
        {
           db = new StackOverflowDatabaseDBContext();
        }

        public void UpdateVotes(int a, int uid, int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;

            Votes vo = db.Votes.Where(temp=> temp.AnswerID == a && temp.UserID == uid).FirstOrDefault();
            if (vo != null)
            {
                vo.VoteValue = updateValue;
            }
            else
            {
                Votes newVo = new Votes() { AnswerID = a, UserID = uid, VoteValue = updateValue};
            }
            db.SaveChanges();
        }
    }
}
