using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTMS
{
    public struct MonthData
    {
        public DateTime firstDayOfMonth { get; set; }
        public DateTime lastDayOfMonth { get; set; }
        public double percent { get; set; }
        public decimal depositAmount { get; set; }
        public decimal revenueForTheCurrentMonth { get; set; }
    }

    public class Bank
    {

        public List<MonthData> calculateContribution(in int countOfMonth, in double percent, in decimal depositAmount)
        {
            DateTime _dateTime = DateTime.Now;
            _dateTime = _dateTime.AddDays(1);

            decimal _depositAmount = depositAmount;
            var _daysEndOfTheMonth = DaysEndOfTheMonth(_dateTime);

            for (int i = 0; i <= countOfMonth; i++)
            {
                MonthData monthData = new();
                monthData.firstDayOfMonth = _dateTime;
                monthData.percent = percent;
                monthData.depositAmount = _depositAmount;
                if(i == 0)
                {
                    
                    monthData.revenueForTheCurrentMonth = CalculateThePercentage
                        (_depositAmount, (decimal)monthData.percent, _daysEndOfTheMonth);

                    _depositAmount += monthData.revenueForTheCurrentMonth;

                    monthData.lastDayOfMonth = _dateTime.AddDays(_daysEndOfTheMonth+1);
                    _daysEndOfTheMonth = DateTime.DaysInMonth(_dateTime.Year, _dateTime.Month);
                    _dateTime = monthData.lastDayOfMonth;
                    ArrayMonthData.Add(monthData);

                }
                else if (i == countOfMonth)
                {
                    monthData.revenueForTheCurrentMonth = CalculateThePercentage
                        (_depositAmount, (decimal)monthData.percent, ArrayMonthData.First().firstDayOfMonth.Day-1);

                    _depositAmount += monthData.revenueForTheCurrentMonth;

                    monthData.lastDayOfMonth = _dateTime.AddDays(ArrayMonthData.First().firstDayOfMonth.Day-2);
                    ArrayMonthData.Add(monthData);

                }
                else
                {
                    monthData.revenueForTheCurrentMonth = CalculateThePercentage
                        (_depositAmount, (decimal)monthData.percent, _daysEndOfTheMonth);

                    _depositAmount += monthData.revenueForTheCurrentMonth;

                    _daysEndOfTheMonth = DateTime.DaysInMonth(_dateTime.Year, _dateTime.Month);
                    monthData.lastDayOfMonth = _dateTime.AddDays(DaysEndOfTheMonth(_dateTime)+1);
                    
                    _dateTime = monthData.lastDayOfMonth;
                    ArrayMonthData.Add(monthData);
                }
            }
            return ArrayMonthData;
        }


        private int DaysEndOfTheMonth(in DateTime dateTime) 
        {
            return DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - dateTime.Day;
        }

        private decimal CalculateThePercentage(in decimal depositAmount, in decimal percent, in int daysEndOfTheMonth)
        {
            return (depositAmount * percent * daysEndOfTheMonth) / (365 * 100);
        }

        readonly private List<MonthData> ArrayMonthData = new List<MonthData>();
    }
}
