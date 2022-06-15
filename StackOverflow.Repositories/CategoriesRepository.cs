using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories
{
    public interface ICategories
    {
        void InsertCategories(Category ci);
        void UpdateCategories(Category cu);
        List<Category> GetCategories();
        List<Category> GetCategoriesByID(int cid);
        void DeleteCategory( int dc);
    }
    public class CategoriesRepository
    {
        StackOverflowDatabaseDBContext db;

        public CategoriesRepository()
        {
            db = new StackOverflowDatabaseDBContext();
        }

        public void InsertCategories(Category ci)
        {
            db.Category.Add(ci);
            db.SaveChanges();
        }

        public void UpdateCategories(Category cu)
        {
           Category ci =  db.Category.Where(temp=>temp.CategoryID == cu.CategoryID).FirstOrDefault();
            if (ci != null)
            {
                ci.CategoryName = cu.CategoryName;
            }
            db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            List<Category> list = db.Category.ToList();
            return list;
        }

        public List<Category> GetCategoriesByID(int cid)
        {
            List<Category> li = db.Category.Where(temp=> temp.CategoryID == cid).ToList();
            return li;
        }

        public void DeleteCategory(int dc)
        {
            Category du = db.Category.Where(temp => temp.CategoryID == dc).FirstOrDefault();
            if (du != null)
            {
                db.Category.Remove(du);
            }

            

            db.SaveChanges();

        }



    }
}
