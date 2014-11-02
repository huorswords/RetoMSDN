namespace Reto5
{
    using System;

    public class Duration
    {
        private static Duration _day = new Duration(x => 1);
        private static Duration _week = new Duration(x => 7);
        private static Duration _month = new Duration(x => (int)DateTime.DaysInMonth(x.Year, x.Month));

        private Func<DateTime, int> calculator;
        
        private Duration(Func<DateTime, int> offsetCalculator)
        {
            this.calculator = offsetCalculator;
        }

        public static Duration Day
        {
            get
            {
                return _day;
            }
        }

        public static Duration Week {
            get 
            { 
                return _week; 
            }
         }

        public static Duration Month
        {
            get
            {
                return _month;
            }
        }

        public DateTime From(DateTime dateTime)
        {
            int days = this.calculator(dateTime);
            if (days == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return dateTime.AddDays(days);
        }

        public static explicit operator Duration(int value)
        {
            return new Duration(x => -1);
        }
    }
}
