namespace _02_SoftUni_Coffee_Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int numOrders = int.Parse(Console.ReadLine());

            List<decimal> list = new List<decimal>();
            for (int i = 0; i < numOrders; i++)
            {
                decimal priceCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy"
                                    , CultureInfo.InvariantCulture);
                
                long capsuleCount = long.Parse(Console.ReadLine());
                decimal priceResult = DateTime.DaysInMonth(date.Year, date.Month) // making month
                                                                 * capsuleCount * priceCapsule;
                    
                Console.WriteLine("The price for the coffee is: ${0:F2}", priceResult);
                list.Add(priceResult);
            }
            decimal finishSum = 0;
            foreach (var number in list)
            {
                finishSum = number + finishSum;
            }
            Console.WriteLine("Total: ${0:F2}", finishSum);
        }
    }
}
