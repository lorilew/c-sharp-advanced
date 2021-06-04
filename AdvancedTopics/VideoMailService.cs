using System;

namespace AdvancedTopics
{
    public class VideoMailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending email..." + e.Video.Title);
            
        }
    }
    
    public class VideoMessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: Sending text..." + e.Video.Title);
            
        }
    }
}