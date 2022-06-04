using System.Globalization;
using Forum.Helpers;
namespace Forum.Helpers
{
    public class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(string errorMessage) :base(errorMessage) { }

        public CustomException(string errorMessage, object[] arg) : base(String.Format(CultureInfo.CurrentCulture, errorMessage, arg)) { }

    }
}
