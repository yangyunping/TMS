using System;

namespace GoldenLady.Standard
{
    public class DefValue
    {
        static readonly DateTime _date = new DateTime(1989, 1, 1);
        static readonly DateTime _date1900 = new DateTime(1900, 1, 1);
        public static DateTime Date { get { return _date; } }

        public static DateTime Date1900 { get { return _date1900; } }
    }
}
