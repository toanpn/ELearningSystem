using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Repository;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Service
{
    public class ChapterService : BaseService<Chapter>, IChapterService
    {
        IUnitOfWork _unitOfWork;
        IChapterRepository _chapterRepository;

        public ChapterService(IUnitOfWork unitOfWork, IChapterRepository chapterRepository)
            : base(unitOfWork, chapterRepository)
        {
            _unitOfWork = unitOfWork;
            _chapterRepository = chapterRepository;
        }

        public ICollection<Chapter> GetByCourse(int id)
        {
            return _chapterRepository.GetByCourse(id);
        }

        public Chapter GetById(int Id)
        {
            return _chapterRepository.FindBy(x=>x.Id == Id).FirstOrDefault();
        }
    }
}
