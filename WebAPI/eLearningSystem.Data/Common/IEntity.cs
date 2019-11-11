using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Common
{
    public interface IEntity<T>
    {
        int id { get; set; }
    }
}
