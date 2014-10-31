namespace Reto5
{
    using System;

    public class Duration
    {
        private Func<DateTime, int> calculator;
        
        private Duration(Func<DateTime, int> offsetCalculator)
        {
            this.calculator = offsetCalculator;
        }

        public static Duration Day
        {
            get
            {
                return new Duration(x => 1);
            }
        }

        public static Duration Week {
            get 
            { 
                return new Duration(x => 7); 
            }
         }

        public static Duration Month
        {
            get
            {
                return new Duration(x => (int)DateTime.DaysInMonth(x.Year, x.Month) );
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
