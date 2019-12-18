using eLearningSystem.Data.Model;
using eLearningSystem.Data.ViewModels;
using eLearningSystem.Services.Base;
using eLearningSystem.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.IService
{
    public interface IChapterService : IBaseService<Chapter>
    {
        int CreateChapters(CreateChaptersViewModel chapterViewModel);
        List<Chapter> GetChaptersByCourseId(int courseId);
    }
}
