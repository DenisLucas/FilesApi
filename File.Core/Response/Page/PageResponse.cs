using System;

namespace File.Core.Response
{
    public class PageResponse<T>
    {
        public T Data { get; set; }
        public PageResponse(T data)
        {
            Data = data;
            
        }
    }
}
