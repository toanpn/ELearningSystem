using eLearningSystem.Data.Model;
using eLearningSystem.Repositories.Common;
using eLearningSystem.Repositories.IRepository;
using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.Base;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Services.Service
{
    public class ChapterService : BaseService<Chapter>, IChapterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChapterRepository _chapterRepository;
        private readonly ILessonRepository _lessonRepository;

        public ChapterService(IUnitOfWork unitOfWork, IChapterRepository repository, ILessonRepository lessonRepository) : base(unitOfWork, repository)
        {
            this._chapterRepository = repository;
            this._lessonRepository = lessonRepository;
            this._unitOfWork = unitOfWork;
        }

        public int CreateChapter(ChapterViewModel chapterViewModel)
        {
            Chapter chapter = this._chapterRepository.Add(new Chapter
            {
                CourseId = chapterViewModel.CourseId,
                Name = chapterViewModel.Name,
                IndexNumber = chapterViewModel.IndexNumber
            });

            if (chapterViewModel.Lessons.Count > 0)
            {
                foreach (var lesson in chapterViewModel.Lessons)
                {
                    _lessonRepository.Add(new Lesson
                    {
                        Name = lesson.Name,
                        Description = lesson.Description,
                        VideoUrl = lesson.VideoUrl,
                        VideoTime = lesson.VideoTime,
                        ChapterId = chapter.Id
                    });
                }
            }

            _unitOfWork.Commit();

            return 1;
        }
    }
}
