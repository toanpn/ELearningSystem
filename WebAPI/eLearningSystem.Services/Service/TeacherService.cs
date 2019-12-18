using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
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
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(IUnitOfWork unitOfWork, ITeacherRepository repository) : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._teacherRepository = repository;
        }
    }
}
