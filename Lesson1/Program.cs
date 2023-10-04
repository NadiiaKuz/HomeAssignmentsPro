namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myCol = new MyCollection
            {
                1,
                2,
                3,
                4
            };

            Console.WriteLine(myCol.Length);

            myCol.Add(6);

            Console.WriteLine(myCol.Length);
        }
    }
}