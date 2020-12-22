using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecttttttttt.Models
{
    public class response<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public bool isSuccess { get; set; } = true;
    }
}
