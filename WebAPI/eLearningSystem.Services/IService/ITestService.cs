using eLearningSystem.Data.Model;
using eLearningSystem.Data.ViewModels;
using eLearningSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface ITestService : IBaseService<Test>
    {
        Test GetTest(int courseId, int chapterId);
        int CheckTest(int courseId, int chapterId, List<SubmitTestViewModel> submitTests);
    }
}
