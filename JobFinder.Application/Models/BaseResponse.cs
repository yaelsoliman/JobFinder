using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Models;
public class BaseResponse<T>
{
    public BaseResponse(string message)
    {
        Succeeded = Data is not null;
        Message = message;
    }

    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Succeeded { get; set; }
}

public class ResponseBool : BaseResponse<bool>
{
    public ResponseBool(string message):base(message) { }

    public static ResponseBool Success(string message) => new(message) { Data = true, Message = message };
    public static ResponseBool Fail(string message) => new(message) { Data = false, Message = message };
}