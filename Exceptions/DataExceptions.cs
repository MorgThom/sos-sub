using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoboSub.Exceptions
{
    /// <summary>
    /// Lost Data Connection.
    /// </summary>
    [Serializable]
    class DataConnectionLostException : DataException
    {
        public DataConnectionLostException()
        {
        }

        public DataConnectionLostException(string message)
            : base(message)
        {
        }

        public DataConnectionLostException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataConnectionLostException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// No sensor input available.
    /// </summary>
    [Serializable]
    class NoDataAvailableException : DataException
    {
        public NoDataAvailableException()
        {
        }

        public NoDataAvailableException(string message)
            : base(message)
        {
        }

        public NoDataAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NoDataAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Wrong number of elements in an input array.
    /// </summary>
    [Serializable]
    class InvalidInputException : DataException
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message)
            : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Bad input data.
    /// </summary>
    [Serializable]
    class UnreadableInputException : DataException
    {
        public UnreadableInputException()
        {
        }

        public UnreadableInputException(string message)
            : base(message)
        {
        }

        public UnreadableInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnreadableInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    /// <summary>
    /// Unknown command given.
    /// </summary>
    [Serializable]
    class UnknownInputCommandException : DataException
    {
        public UnknownInputCommandException()
        {
        }

        public UnknownInputCommandException(string message)
            : base(message)
        {
        }

        public UnknownInputCommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownInputCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

}
