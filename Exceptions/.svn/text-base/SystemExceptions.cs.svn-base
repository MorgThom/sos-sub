using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoboSub.Exceptions
{
    /// <summary>
    /// Unable to find module.
    /// </summary>
    [Serializable]
    class ModuleNotFoundException : SystemException
    {
        public ModuleNotFoundException()
        {
        }

        public ModuleNotFoundException(string message)
            : base(message)
        {
        }

        public ModuleNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModuleNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Requested module unavailable.
    /// (Has been used, offline)
    /// </summary>
    [Serializable]
    class ModuleNotAvailableException : SystemException
    {
        public ModuleNotAvailableException()
        {
        }

        public ModuleNotAvailableException(string message)
            : base(message)
        {
        }

        public ModuleNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected ModuleNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
