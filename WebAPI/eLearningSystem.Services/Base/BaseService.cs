using eLearningSystem.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Base
{
    public abstract class BaseService
    {
        protected readonly UnitOfWork uow;
        public BaseService(UnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
