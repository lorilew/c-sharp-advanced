using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AdvancedTopics
{
    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Generics
            //GenericsLesson1();
            
            // Delegates
            // DelegatesLesson2();
            
            // Lambdas 
            // LambdasLesson3();
            
            // Events & Delegates
            // EventsLesson4();
            
            // Extension Methods
            // ExtensionMethodsLesson5();
            
            // Linq
            // LinqLesson6();
            
            // Nullables
            // NullableLesson7();
            
            // C# is a statically typed language, they introduced dynamics
            // (Dynamic languages like jS determine type at runtime,
            //  statically typed languages check at compile time)
            // so you don't have to use reflection.
            // DynamicLesson8();
            
            // Exception Handling
            // ExceptionHandlingLesson9();
            
            // Asynchronous Programming with Async/ Await
            AsynchronousProgrammingLesson10TaskAsync();
        }

        static async Task AsynchronousProgrammingLesson10TaskAsync()
        {
            // Best practise to name method with Async suffix
            // task based asynchronous 
            
            // when you use await the runtime thread is released so any other processes
            // can use it. Then returns to runtime once the await is complete.
            
            // At runtime the code is compiled into a method with a cb, but the
            // programmer does not need to do this.
            await SlowMethodTaskAsync();
            Console.WriteLine("Hello");

            var task = SlowMethodTaskAsync();
                
            Console.WriteLine("Hello 2");

            var result = await task;
            Console.WriteLine("Hello 3");

        }

        static async Task<int> SlowMethodTaskAsync()
        {
            var t = new WebClient();
            try
            {
                var html = await t.DownloadStringTaskAsync("http://msdn.microsoft.com");
                using (var streamWriter = new StreamWriter(@"c:\tmp\test.html"))
                {
                    await streamWriter.WriteAsync(html);
                }

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        static void ExceptionHandlingLesson9()
        {
            // try/catch
            StreamReader streamReader = null;
            try
            {
                // var zero = 0;
                var zero = 1;
                var result = 7 / zero;
                streamReader = new StreamReader(@"/Users/laurenlewis/projects/AdvancedTopics/AdvancedTopics/Video.cs");
                var content = streamReader.ReadToEnd();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("You cannot divide by zero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw; // or not to throw
            }
            finally
            {
                // close connections here and clean up
                if (streamReader != null) streamReader.Dispose(); // implements IDisposable
                Console.WriteLine("Closed connections");
            }
            
            // a cleaner way to code use `using` instead of `finally`
            try
            {
                using (var streamReader2 = new StreamReader("dummy.txt"))
                {
                    var content = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // custom Exceptions can be used to hide low level exceptions
            try
            {
                var youtubeApi = new YouTubeApi();
                youtubeApi.GetVideos("hello");
            }
            catch (YouTubeException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static void DynamicLesson8()
        {
            object obj = "Foo";
            // obj.GetHashCode(); // I can use this because type in determined
            
            // using reflection
            // var methodInfo = obj.GetType().GetMethod("GetHashCode"); // error
            // methodInfo.Invoke(null, null);
            
            //using dynamic
            dynamic name = "mosh";
            // name.Optimze();
            // name++; // error thrown `Operator '++' cannot be applied to operand of type 'string'`
            name = 16; // we can reassign to a different type
            name++; // no error

            dynamic a = 1;
            dynamic b = 2;
            var c = a + b; // at runtime c is a dynamic 
            

        }

        static void NullableLesson7()
        {
            DateTime? birthDate = null;
            // Console.WriteLine(birthDate.HasValue);
            // Console.WriteLine(birthDate.GetValueOrDefault());
            // Console.WriteLine(birthDate.Value); EXCEPTION!!!
            
            DateTime? thisMonth = new DateTime(2021, 05, 01);
            DateTime copy = thisMonth.GetValueOrDefault();

            DateTime? copyCopy = copy;
            // Console.WriteLine(copyCopy);

            DateTime? date1 = new DateTime(2021,05,03);
            DateTime date2 = date1 ?? DateTime.Today;
            Console.WriteLine(date2);

        }

        static void LinqLesson6()
        {
            var books = new BookRepository().GetBooks();
            // LINQ Query operators
            // always start with `from` and finish with `select`
            var cheaperBooks =
                from b in books
                where b.Price < 5
                orderby b.Title
                select b.Title;

            // LINQ extension methods
            // more powerful syntax, better to use this.
            var cheapBooks = books
                .Where(b => b.Price < 10M)
                .OrderBy(b => b.Title);

            Console.WriteLine("Cheap Books:");
            foreach (var book in cheapBooks)
            {
                Console.WriteLine($"{book.Title}: ${book.Price}");
            }
            
            Console.WriteLine("\nCheapest Books:");
            foreach (var book in cheaperBooks)
            {
                Console.WriteLine($"{book}");
            }

            var nameOfTheWind = books.Single(b => b.Title == "Name of the Wind");
            Console.WriteLine(nameOfTheWind.Title);

            var mostExpensiveBookPrice = books.Max(b => b.Price);
            Console.WriteLine($"How much is the most expensive book? {mostExpensiveBookPrice}");


        }
        static void ExtensionMethodsLesson5()
        {
            string post = "This is a very long blog post, blah blah blah. The end.";
            var shortedPost = post.Shorten(3);
            Console.WriteLine(shortedPost);
        }

        static void EventsLesson4()
        {
            var video = new Video{Title = "Chicken Run"};
            var encoder = new VideoEncoder(); // publisher
            var mailService = new VideoMailService(); // subscriber
            var messageService = new VideoMessageService(); // subscriber2
            // register handler for event
            // (pointer to the event handler method.)
            encoder.VideoEncoded += mailService.OnVideoEncoded;
            encoder.VideoEncoded += messageService.OnVideoEncoded;
            
            encoder.Encode(video);

        }

        static void LambdasLesson3()
        {
            Func<int, int> square = n => n * n;
            Console.WriteLine(square(5));
            
            //scope of lamdba
            const int factor = 5;
            Func<int, int> factor5 = n => n * factor;
            Console.WriteLine(factor5(7));
        }

        public static void customFilterToRemoveRedEye(Photo photo)
        {
            Console.WriteLine("Remove red eye");
        }

        static void DelegatesLesson2()
        {
            var filters = new PhotoFilters();
            var processor = new PhotoProcessor();
            // PhotoProcessor.PhotoFilterHandler filterHandler = filters.Resize;
            Action<Photo> filterHandler = filters.Resize;
            filterHandler += filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast; 
            // delegates allow you to extend with functions of the same signature
            filterHandler += customFilterToRemoveRedEye;
            
            processor.Process("pig.jpg", filterHandler);
        }
        

        static void GenericsLesson1()
        {
            var book = new Book() {ISBN = "12345", Title = "the pig book", Price = 12.99M};
            var books = new GenericList<Book>();
            books.Add(book);

            var bookDict = new GenericDictionary<string, int>();
            bookDict.Add(book.ISBN, 1);

            var discounter = new DiscountCalculator<Book>();
            book.Price = discounter.CalculateDiscount(book, 0.1M);
            Console.WriteLine("New price: " + book.Price);

            // var number = new Nullable<int>();
            // var defaultValue = number.GetValueOrDefault();
            // Console.WriteLine("Default value: " + defaultValue);


            int? x = null;
            int? y = 7;
            Console.WriteLine("x: " + x.GetValueOrDefault());
            Console.WriteLine("y: " + y.GetValueOrDefault());

            var BookMachine = new ProductFactory<Book>();
            var newBook = BookMachine.Create();
            newBook.Title = "The book about a pear";
        }
    }
    
}