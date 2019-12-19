using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningSystem.ResponseModel
{
    class UserCourseIDResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public int[] IDs { get; set; }
    }
}
