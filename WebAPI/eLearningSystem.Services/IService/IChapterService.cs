using eLearningSystem.Data.Model;
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
        int CreateChapter(ChapterViewModel chapterViewModel);
    }
}
