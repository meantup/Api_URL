using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Model
{
    public class Response<T>
    {
        public int response { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public bool isSuccess { get; set; } = true;
      
    }
}
