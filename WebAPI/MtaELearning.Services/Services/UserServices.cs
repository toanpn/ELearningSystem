using MtaELearning.DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtaELearning.BusinessServices
{

    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>  
        /// Public constructor.  
        /// </summary>  
        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        public void a()
        {
        }
    }
}
