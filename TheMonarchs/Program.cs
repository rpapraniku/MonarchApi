using System;
using System.Linq;
using System.Net.Http;

namespace TheMonarchs
{
    class Program
    {
        private const string baseAddress = "http://localhost:5000/api/";

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Please choose one of the follwing questions:");

            var questions = Question.GetQuestions();

            foreach (var q in questions)
            {
                Console.WriteLine($"{q.Identifier}) {q.Question}");
            }

            var quit = true;
            while (quit)
            {
                var input = Console.ReadLine();

                if (!questions.Select(x => x.Identifier).ToList().Contains(input))
                {
                    Console.WriteLine("Please choose one of the follwing answers: a,b,c,d!");
                }
                else
                {
                    var selectedQuesiton = questions.FirstOrDefault(x => x.Identifier == input);
                    using (var client = new HttpClient()) //WebClient  
                    {
                        client.BaseAddress = new Uri(baseAddress);

                        var response = await client.GetAsync(selectedQuesiton.Endpoint);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(result);
                        }
                    }
                }
            }
        }
    }
}
