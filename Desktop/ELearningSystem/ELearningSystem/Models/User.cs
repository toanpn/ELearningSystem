using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningSystem.Models
{
    class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }

        public bool? Gender { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        public int? Score { get; set; }
    }
}
