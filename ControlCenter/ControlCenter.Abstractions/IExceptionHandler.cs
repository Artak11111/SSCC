using System;

namespace ControlCenter.Abstractions
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}