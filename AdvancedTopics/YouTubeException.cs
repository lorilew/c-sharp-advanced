using System;

namespace AdvancedTopics
{
    public class YouTubeException: Exception
    {
        public YouTubeException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}