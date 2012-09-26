using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoboSub.Exceptions
{
    /// <summary>
    /// Image undecipherable.
    /// </summary>
    [Serializable]
    class ImageNotDecipherableException : VisionException
    {
        public ImageNotDecipherableException()
        {
        }

        public ImageNotDecipherableException(string message)
            : base(message)
        {
        }

        public ImageNotDecipherableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ImageNotDecipherableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
