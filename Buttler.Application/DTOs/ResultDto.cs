using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Buttler.Application.DTOs
{
    public class ResultDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ResultDto(T data, string message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public ResultDto(T data, bool isSuccess) : this(data)
        {
            IsSuccess = isSuccess;
        }

        public ResultDto(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public ResultDto(T data) => Data = data;

        public ResultDto()
        {
        }
    }
}
