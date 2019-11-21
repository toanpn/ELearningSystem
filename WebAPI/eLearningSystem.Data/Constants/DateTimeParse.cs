using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearningSystem.Data.Constants
{
    public static class DateTimeParse
    {
        public static DateTime AddYears(DateTime aDateTime)
        {
            DateTime newTime = aDateTime.AddYears(1);
            return newTime;
        }

        public static string ConvertDtToString(DateTime aDateTime)
        {
            return aDateTime.ToString("yyyy-mm-dd");
        }

        public static DateTime ConvertStringToDt(string aDateTime)
        {
            return DateTime.ParseExact(aDateTime, "yyyy-mm-dd", null);
        }

        public static int SSTowDateTime(DateTime DateTime1, DateTime DateTime2)
        {
            return DateTime.Compare(DateTime1, DateTime2);
        }
    }
}
