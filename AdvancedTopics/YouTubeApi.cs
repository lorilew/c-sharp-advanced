using System;
using System.Collections.Generic;

namespace AdvancedTopics
{
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // access youtube web service
                // read the data
                // create a list of video objects
                throw new Exception("Waaa");
            }
            catch (Exception e)
            {
                // log
                throw new YouTubeException("Could not fetch the video for user " + user, e);
            }

            return new List<Video>();
        }
    }
}