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
    public interface IAnswersService
    {
        void InsertAnswer(NewAnswerViewModel avm);
        void UpdateAnswer(EditAnswerViewModel avm);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<AnswerViewModel> GetAnswersByQuestionID(int qid);
        AnswerViewModel GetAnswerByAnswerID(int AnswerID);
    }
    public class AnswersService:IAnswersService
    {
        IAnswersRepository ar;

        public AnswersService()
        {
            ar = new AnswersRepository();
        }

        public void InsertAnswer(NewAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewAnswerViewModel, Answers>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Answers a = mapper.Map<NewAnswerViewModel, Answers>(avm);
            ar.InsertAnswers(a);
        }
        public void UpdateAnswer(EditAnswerViewModel avm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditAnswerViewModel, Answers>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Answers a = mapper.Map<EditAnswerViewModel, Answers>(avm);
            ar.UpdateAnswers(a);
        }
        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            ar.UpdateAnswerVotesCount(aid, uid, value);
        }
        public void DeleteAnswer(int aid)
        {
            ar.DeleteAnswers(aid);
        }

        public List<AnswerViewModel> GetAnswersByQuestionID(int qid)
        {
            List<Answers> a = ar.GetAnswersByQuestionID(qid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answers, AnswerViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<AnswerViewModel> avm = mapper.Map<List<Answers>, List<AnswerViewModel>>(a);
            return avm;
        }

        public AnswerViewModel GetAnswerByAnswerID(int AnswerID)
        {
            Answers a = ar.GetAnswersByAnswerID(AnswerID).FirstOrDefault();
            AnswerViewModel avm = null;
            if (a != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Answers, AnswerViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                avm = mapper.Map<Answers, AnswerViewModel>(a);
            }
            return avm;
        }
    }
}
