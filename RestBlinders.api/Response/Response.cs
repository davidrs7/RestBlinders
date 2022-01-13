using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBlinders.api.Response
{
    public class Response<T>
    {
        public Response(T data) {
            Data = data; 
        } 
        public T Data { get; set; } 
    }
}
