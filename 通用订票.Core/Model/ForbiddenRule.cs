using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Model
{
    public class ForbiddenRule
    {
        public int[] Weeks { get; set; }
        public int[] Months { get; set; }
        public int[] Days { get; set; }
        public DateTime[] dates { get; set; }

        public bool IsDateVaild(DateTime date)
        {
            foreach (int week in Weeks)
            {
                if ((int)date.DayOfWeek == week)
                {
                    return false;
                }
            }


            foreach (int Month in Months)
            {
                if (date.Month == Month)
                {
                    return false;
                }
            }

            foreach (int Day in Days)
            {
                if (date.Day == Day)
                {
                    return false;
                }
            }

            foreach (var _date in dates)
            {
                if (_date.Date.CompareTo(date.Date) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
