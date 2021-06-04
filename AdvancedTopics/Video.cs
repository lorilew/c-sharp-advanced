using System;
using System.Threading;

namespace AdvancedTopics
{
    public class Video
    {
        public string Title { get; set; }
    }

    // 1. define a delegate that will describe the function called when
    //      VideoEncoder publishes an event.
    // 2. Event based on that delegate
    // 3. Publish event
    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        // public delegate void VideoEncoderEventHandler(object source, VideoEventArgs args);
        public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video... " + video.Title);
            Thread.Sleep(3000);
            
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs(){ Video = video });
            } 
        }
    }
}