using eLearningSystem.Data.Constants;
using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eLearningSystem.WebApi.API
{
    public class ManagerCourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public ManagerCourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        #region methods
        /// <summary>
        /// Lấy ra danh sách khoá học có phân trang
        /// </summary>
        /// <returns></returns>
        [Route("api/course/page")]
        public IHttpActionResult GetCoursePaging(int pageSize, int pageNumber)
        {
            ResponseDataDTO<PagedResults<Course>> response = new ResponseDataDTO<PagedResults<Course>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _courseService.CreatePagedResults(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        [Route("api/course/getCoursesByCategory")]
        public IHttpActionResult GetCoursesCategory(int pageSize, int pageNumber, int id)
        {
            ResponseDataDTO<PagedResults<Course>> response = new ResponseDataDTO<PagedResults<Course>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _courseService.GetCoursesCategory(pageNumber, pageSize, id);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        /// <summary>
        /// Lấy ra khoá học theo id
        /// </summary>
        /// <returns></returns>
        [Route("api/course/{id}")]
        public IHttpActionResult GetCourseById(int id)
        {
            ResponseDataDTO<Course> response = new ResponseDataDTO<Course>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _courseService.GetById(id);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        /// <summary>
        /// Tạo mới khoá học
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/course/create")]
        public async Task<IHttpActionResult> CreateCourse()
        {
            ResponseDataDTO<string> response = new ResponseDataDTO<string>();
            try
            {
                var path = Path.GetTempPath();

                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
                }

                MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(path);

                await Request.Content.ReadAsMultipartAsync(streamProvider);
                // save file
                string fileName = "";
                foreach (MultipartFileData fileData in streamProvider.FileData)
                {
                    fileName = FileExtension.SaveFileOnDisk(fileData);
                }

                Course course = new Course
                {
                    Name = Convert.ToString(streamProvider.FormData["Name"]),
                    Description = Convert.ToString(streamProvider.FormData["Description"]),
                    Price = Convert.ToDouble(streamProvider.FormData["Price"]),
                    ImageUrl = fileName,
                    CategoryId = Convert.ToInt32(streamProvider.FormData["CategoryId"]),
                    IsVisiable = true
                };

                _courseService.Create(course);

                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = fileName;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;
                Console.WriteLine(ex.ToString());

                return Ok(response);
            }
        }

        /// <summary>
        /// Cập nhập khoá học
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("api/course/update/{courseId}")]
        public async Task<IHttpActionResult> UpdateCourse(int courseId)
        {
            ResponseDataDTO<string> response = new ResponseDataDTO<string>();
            try
            {
                var path = Path.GetTempPath();

                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
                }

                MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(path);

                await Request.Content.ReadAsMultipartAsync(streamProvider);
                // save file
                string fileName = "";
                foreach (MultipartFileData fileData in streamProvider.FileData)
                {
                    fileName = FileExtension.SaveFileOnDisk(fileData);
                }

                Course course = new Course
                {
                    Id = courseId,
                    Name = Convert.ToString(streamProvider.FormData["Name"]),
                    Description = Convert.ToString(streamProvider.FormData["Description"]),
                    Price = Convert.ToDouble(streamProvider.FormData["Price"]),
                    CategoryId = Convert.ToInt32(streamProvider.FormData["CategoryId"]),
                    IsVisiable = true
                };

                var existCourse = _courseService.GetById(courseId);
                if (fileName != "")
                {
                    course.ImageUrl = fileName;
                }
                else
                {
                    course.ImageUrl = existCourse.ImageUrl;
                }

                _courseService.Update(courseId, course);

                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = fileName;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;
                Console.WriteLine(ex.ToString());

                return Ok(response);
            }
        }


        /// <summary>
        /// Lấy ra khoá học giảm giá
        /// </summary>
        /// <returns></returns>
        [Route("api/course/GetCoursesFreePageResult")]
        public IHttpActionResult GetCoursesFree()
        {
            ResponseDataDTO<List<Course>> response = new ResponseDataDTO<List<Course>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _courseService.GetListCourseFree();
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        /// <summary>
        /// Lấy ra khoá học giảm giá
        /// </summary>
        /// <returns></returns>
        [Route("api/course/getteacher/{courseId}")]
        public IHttpActionResult GetTeacherByCourseId(int courseId)
        {
            ResponseDataDTO<Teacher> response = new ResponseDataDTO<Teacher>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _courseService.GetTeacherByCourseId(courseId);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [Route("api/course/GetCoursesNewPageResult")]
        [HttpGet]
        public PagedResults<Course> GetCoursesNewPageResult(int pageSize, int pageNumber)
        {
            return _courseService.GetListCourseNewPageResult(pageNumber, pageSize);
        }

        [AllowAnonymous]
        [Route("api/course/GetCoursesHot")]
        [HttpGet]
        public ICollection<Course> GetCoursesHot()
        {
            return _courseService.GetListCourseHot();
        }
        #endregion
    }
}
