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

    public interface IUsersService
    {
        int InsertUser(RegisterViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int id);
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);
        UserViewModel GetUsersByUserID(int UserID);

    }
     

    
    public class UsersService: IUsersService
    {
        IUsersRepositories ur;
        public UsersService()
        {
            ur = new UsersRepository();
        }

        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, Users>();
                cfg.IgnoreUnmapped();
            } 
            );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<RegisterViewModel, Users>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);

            ur.InsertUsers(u);
            int uid = ur.GetLatestUsers();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserDetailsViewModel, Users>();
                cfg.IgnoreUnmapped();
            }
            );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(uvm);
            ur.UpdateUsersDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserPasswordViewModel, Users>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserPasswordViewModel, Users>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUsersPassword(u);
        }

        public void DeleteUser(int id)
        {
            ur.DeleteUsers(id);
        }


        public List<UserViewModel> GetAllUsers()
        {
            List<Users> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<Users>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
           Users u = ur.GetUsersByEmailAndPassword(Email,SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users,UserViewModel>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            Users u = ur.GetUsersByEmail(Email).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users, UserViewModel>(u);
            return uvm;
        }

        public UserViewModel GetUsersByUserID(int UserID)
        {
            Users u = ur.GetUsersByUserID(UserID).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            }
           );
            //RegisterViewModel=>sourcetype USers=>destinationtype
            IMapper mapper = config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users, UserViewModel>(u);
            return uvm;
        }

    }
}
