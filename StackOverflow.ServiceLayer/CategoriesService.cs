using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModels;
using StackOverflow.Repositories;
using StackOverflow.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflow.ServiceLayer
{
    public interface ICategoriesService
    {
        void InsertCategory(CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void DeleteCategory(int c);
        List<CategoryViewModel> GetCategory();
        CategoryViewModel GetCategoryById(int id);
    }
    public class CategoriesService:ICategoriesService
    {

        ICategoriesRepository cr;

        public CategoriesService()
        {
            cr = new CategoriesRepository();
        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped();}); 
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.InsertCategories(c);

        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.UpdateCategories(c);
        }

        public void DeleteCategory(int c)
        {
            cr.DeleteCategory(c);
        }

        public List<CategoryViewModel> GetCategory()
        {
            List<Category> c = cr.GetCategories();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> uvm = mapper.Map<List<Category>, List<CategoryViewModel>>(c);
            return uvm;
        }


        public CategoryViewModel GetCategoryById(int id)
        {
            Category c = cr.GetCategoriesByCategoryID(id).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            }
          );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            CategoryViewModel uvm = mapper.Map<Category, CategoryViewModel>(c);
            return uvm;
        }
    }
}
