using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces
{
    public interface IExceptionLog
    {
        public void Log(object obj);
    }
}
