using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface IUsersRepositories
    {
        void InsertUsers(Users u);
        void UpdateUsersDetails(Users u);
        void UpdateUsersPassword(Users u);
        void DeleteUsers(int uid);
        List<Users> GetUsers();
        List<Users> GetUsersByEmailAndPassword(string email , string password);
        List<Users> GetUsersByEmail(string email);
        List<Users> GetUsersByUserID(int uid);
        
    }
    public class UsersRepository: IUsersRepositories
    {
        StackOverflowDatabaseDBContext db;
        public UsersRepository()
        {
            db = new StackOverflowDatabaseDBContext();
        }

        public void InsertUsers(Users u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUsersDetails(Users u)
        {
          Users ui =  db.Users.Where(temp=>temp.UserID == u.UserID).FirstOrDefault();
          if (ui != null)
            {
                ui.Email = u.Email;
                ui.Name = u.Name;
                ui.Mobile = u.Mobile;
            }
          db.SaveChanges();
        }

        public void UpdateUsersPassword(Users u)
        {
           Users ui = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (ui != null)
            {
               ui.PasswordHash = u.PasswordHash;

            }
            db.SaveChanges();
        }

        public void DeleteUsers(int uid)
        {
            Users ui =  db.Users.Where(temp=>temp.UserID == uid).FirstOrDefault();
            if (ui != null)
            {
                db.Users.Remove(ui);

            }
            db.SaveChanges();
        }

        public List<Users> GetUsers()
        {
            List<Users> ui = db.Users.ToList();
            return ui;
        }

        public List<Users> GetUsersByEmailAndPassword(string email, string password)
        {
            List<Users> ui = db.Users.Where(temp => temp.Email == email || temp.PasswordHash == password).ToList();
            return ui;
        }

        public List<Users> GetUsersByEmail(string email)
        {
            List<Users> ui = db.Users.Where(temp => temp.Email == email).ToList();
            return ui;
        }

        public List<Users> GetUsersByUserID(int uid)
        {
            List<Users> ui = db.Users.Where(temp => temp.UserID == uid).ToList();
            return ui;
        }

    }
}
