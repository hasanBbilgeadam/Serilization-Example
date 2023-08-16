using System.Text.Encodings.Web;
using System.Text.Json;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            Person p = new Person() { Name = "hasan", SurName = "baysal" };

            var result = JsonSerializer.Serialize(p);

            Console.WriteLine(result);

            var result2 = JsonSerializer.Deserialize<Person>(result);

            Console.WriteLine("deserilize işlemi");
            Console.WriteLine(result2.Name);
            Console.WriteLine(result2.SurName);


            string path = "data.json";

            List<Person> list = new List<Person>()
            {

                new(){Name="hasan 1",SurName="baysal 1"},
                new(){Name="hasan 2",SurName="baysal 2"},
                new(){Name="hasan 3",SurName="baysal 3"},
                new(){Name="hasan 4",SurName="baysal 4"},
                new(){Name="hasan 5",SurName="baysaç 5"}

            };


            Test test = new Test(); 

            test.People.AddRange(list);

            var data = JsonSerializer.Serialize(test, options);

            Console.WriteLine(data);

            //var result3 =  JsonSerializer.Serialize(list,options);

            //File.WriteAllText(path,result3);



            //var dosyadanÖden= File.ReadAllText(path);

            //Console.WriteLine(dosyadanÖden);



            //List<Person> gelenData = JsonSerializer.Deserialize<List<Person>>(dosyadanÖden);

            //Console.WriteLine("list deserilize işlemi yapıyorum");

            //foreach (var item in gelenData)
            //{
            //    Console.WriteLine($"{item.Name} {item.SurName}");
            //}




        }

    }
    
    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
    public class Test
    {
        public int Id { get; set; }
        public List<Person> People { get; set; }

        public Test()
        {
            People = new();
        }
    }

}