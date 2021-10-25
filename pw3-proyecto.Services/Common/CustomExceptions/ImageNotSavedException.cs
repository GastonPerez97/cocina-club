using System;

namespace pw3_proyecto.Services.Common.CustomExceptions
{
    public class ImageNotSavedException : Exception
    {
        public ImageNotSavedException()
        {
        }

        public ImageNotSavedException(string message)
            : base(message)
        {
        }

        public ImageNotSavedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
