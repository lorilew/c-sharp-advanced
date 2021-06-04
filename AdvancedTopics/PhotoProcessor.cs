using System;

namespace AdvancedTopics
{
    public class PhotoProcessor
    {
        // declare the signature of the delegate - it's like a new type
        // public delegate void PhotoFilterHandler(Photo photo);
        
        // public void Process(string path, PhotoFilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler)

        {
            // An object that knows how to all a method (or group of methods)
            // A reference to a function
            var photo = new Photo();
            photo.Load(path);
            filterHandler(photo);
            photo.Save();
        }
    }
}