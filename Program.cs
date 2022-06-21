using System;
using System.IO;
using System.Linq;


namespace YandexHypothesis8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = (File.ReadAllLines(@"../../../shmya_final_version.csv")).Skip(1).ToArray();

            var data = lines.Select(q => q.Split(","))
                .Select(q => new OrderLine()
                {
                    Date = DateTime.Parse(q[0]),
                    Cutlery = Convert.ToInt32(q[1]),
                    Tips = Convert.ToInt32(q[2]),
                    OrderPrice = Convert.ToInt32(q[3]),
                    Uid = Convert.ToInt32(q[4]),
                    OrderId = Convert.ToInt32(q[5])
                });

            var cutleryMoreTwo = data.Where(q => q.Cutlery > 2).ToArray();
            var cutleryMoreTwoSumTips = cutleryMoreTwo.Select(q => q.Tips).Sum();
            var cutleryMoreTwoSumOrderPrice = cutleryMoreTwo.Select(q => q.OrderPrice).Sum();
            var averageTipAmount = cutleryMoreTwoSumTips / cutleryMoreTwo.Length;
            var percentTipsOrder = Convert.ToDouble(cutleryMoreTwoSumTips) /
                Convert.ToDouble(cutleryMoreTwoSumOrderPrice);

            var cutleryLessTwo = data.Where(q => q.Cutlery <= 2).ToArray();
            var cutleryLessTwoSumTips = cutleryLessTwo.Select(q => q.Tips).Sum();
            var cutleryLessTwoSumOrderPrice = cutleryMoreTwo.Select(q => q.OrderPrice).Sum();
            var averageTipAmountLessTwo = cutleryLessTwoSumTips / cutleryLessTwo.Length;
            var percentTipsOrderLessTwo = Convert.ToDouble(cutleryLessTwoSumTips) /
                Convert.ToDouble(cutleryLessTwoSumOrderPrice);

            DateTime date1 = new DateTime(2022, 01, 09).Date;

            var cutleryMoresTwoNoHolidays = cutleryMoreTwo.Where(q => q.Date > date1 && q.OrderPrice > 800)
                .Select(q => q.ToBackString());
            var numberOfPersons = cutleryMoresTwoNoHolidays.Count();

            File.WriteAllLines(@"../../../targetOrders.csv", cutleryMoresTwoNoHolidays);
        }
    }
}