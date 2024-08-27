using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.Core.Model
{
    public class ForbiddenRule
    {
        private int[] Weeks { get; set; }
        private int[] Months { get; set; }
        private int[] Days { get; set; }

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

            return true;
        }
    }
}
