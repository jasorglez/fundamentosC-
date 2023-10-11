using fundamentals.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace fundamentals
{
    class Generico
    {
        static void ain(string[] args)
        {
            // Create a Box for integers
            Box<int> intBox = new Box<int>(42);
            int intData = intBox.GetData();
            Console.WriteLine("Integer Data: " + intData);

            // Create a Box for strings
            Box<string> stringBox = new Box<string>("Hello, C#");
            string stringData = stringBox.GetData();
            Console.WriteLine("String Data: " + stringData);
        }
    }


    public class Box<T>
    {
        private T data;

        public Box(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return data;
        }
    }
}