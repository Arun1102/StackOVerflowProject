using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace StackOverflow.DomainModels
{
    public class StackOverflowDatabaseDBContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Votes> Votes { get; set; }
       



    }
}
