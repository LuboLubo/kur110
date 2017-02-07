namespace _01_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Numbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                                            .Split() 
                                            .Select(double.Parse)
                                            .ToList();

            if (numbers.Count <= 1)
            {
                Console.WriteLine("No");
                return;
            }
            double averageResult = numbers.Average();
            List<double> listResult = new List<double>();
            foreach (var num in numbers.OrderByDescending(x => x).Take(5))
            {
                if (num <= averageResult)
                {
                    break;
                }
                listResult.Add(num);
            }
            Console.WriteLine(string.Join(" ",listResult));
        }
    }
}
