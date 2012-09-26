using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoboSub.Exceptions
{
    /// <summary>
    /// Data type exceptions.
    /// </summary>
    [Serializable]
    class DataException : System.Exception
    {
        public DataException()
        {
        }

        public DataException(string message)
            : base(message)
        {
        }

        public DataException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected DataException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
        }
    }
    /// <summary>
    /// System type exceptions.
    /// </summary>
    [Serializable]
    class SystemException : System.Exception
    {
        public SystemException()
        {
        }

        public SystemException(string message)
            : base(message)
        {
        }

        public SystemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SystemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Vision type exceptions.
    /// </summary>
    [Serializable]
    class VisionException : System.Exception
    {
        public VisionException()
        {
        }

        public VisionException(string message)
            : base(message)
        {
        }

        public VisionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected VisionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Internal condition exceptions.
    /// </summary>
    [Serializable]
    class InternalConditionException : System.Exception
    {
        public InternalConditionException()
        {
        }

        public InternalConditionException(string message)
            : base(message)
        {
        }

        public InternalConditionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InternalConditionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
