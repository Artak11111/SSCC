using System;

namespace ControlCenter.Server.Models
{
    public class ErrorResult
    {
        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
