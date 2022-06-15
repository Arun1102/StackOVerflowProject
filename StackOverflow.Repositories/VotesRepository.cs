using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVotes(Votes vo);
    }
    public class VotesRepository
    {
        StackOverflowDatabaseDBContext db;
        public VotesRepository()
        {
           db= new StackOverflowDatabaseDBContext();
        }

        public void UpdateVotes(Votes vo)
        {
            Votes vot = db.Votes.Where(temp => temp.VoteID == vo.VoteID).FirstOrDefault();
            if (vot != null)
            {
                vot.VoteValue = vot.VoteValue;

            }
            db.SaveChanges();
        }
    }
}
