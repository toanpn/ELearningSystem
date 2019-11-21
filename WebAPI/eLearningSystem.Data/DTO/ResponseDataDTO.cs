using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.DTO
{
    public class ResponseDataDTO<T>
    {
        public int Code { get; set; }

        public String Message { get; set; }

        public T Data { get; set; }

        public ResponseDataDTO()
        {
        }

        public ResponseDataDTO(int code, String message, T data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
    }
}
