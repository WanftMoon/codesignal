using System;
namespace CodeSignal.Arcade.TheCore
{
    public class TimeRiver
    {
        /// <remarks>
        /// Check if the given string is a correct time representation of the 24-hour clock.
        /// 
        /// Example
        /// 
        /// For time = "13:58", the output should be
        /// validTime(time) = true;
        /// For time = "25:51", the output should be
        /// validTime(time) = false;
        /// For time = "02:76", the output should be
        /// validTime(time) = false.
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        /// string time
        /// 
        /// A string representing time in HH:MM format.It is guaranteed that the first two characters, as well as the last two characters, are digits.
        /// 
        /// [output] boolean
        /// 
        /// true if the given representation is correct, false otherwise.
        ///
        /// TimeSpan.TryParse(time, out dummyOutput);
        /// </remarks>
        public static bool ValidTime(string time)
        {
            string[] values = time.Split(':');

            return (int.Parse(values[0]) < 24 && int.Parse(values[1]) < 60);
        }


        /// <remarks>
        /// You have been watching a video for some time. Knowing the total video duration find out what portion of the video you have already watched.
        /// 
        /// Example
        /// 
        /// For part = "02:20:00" and total = "07:00:00", the output should be
        /// videoPart(part, total) = [1, 3].
        /// 
        /// You have watched 1 / 3 of the whole video.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string part
        /// 
        /// A string of the following format "hh:mm:ss" representing the time you have been watching the video.
        /// 
        /// [input] string total
        /// 
        /// A string of the following format "hh:mm:ss" representing the total video duration.
        /// 
        /// [output] array.integer
        /// 
        /// An array of the following format[a, b] (where a / b is a reduced fraction).
        /// </remarks>
        public static int[] VideoPart(string part, string total)
        {
            Func<int, int, int> GCD = (int a, int b) =>
            {
                while (a > 0)
                {
                    int temp = a;

                    a = b % a;
                    b = temp;
                }
                return b;
            };

            Func<string, int> ToSecs = (string time) =>
            {
                string[] parts = time.Split(':');

                return (int.Parse(parts[0]) * 60 + int.Parse(parts[1])) * 60 + int.Parse(parts[2]);
            };

            int partSecs = ToSecs(part);
            int totalSecs = ToSecs(total);
            int div = GCD(partSecs, totalSecs);

            return new int[] { partSecs / div, totalSecs / div };
        }


        /// <remarks>
        /// Whenever you decide to celebrate your birthday you always do this your favorite café, which is quite popular and as such usually very crowded. This year you got lucky: when you and your friend enter the café you're surprised to see that it's almost empty. The waiter lets slip that there are always very few people on this day of the week.
        /// 
        /// You enjoyed having the café all to yourself, and are now curious about the next time you'll be this lucky. Given the current birthdayDate, determine the number of years until it will fall on the same day of the week.
        /// 
        /// For your convenience, here is the list of months lengths(from January to December, respectively) :
        /// 
        /// Months lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
        /// Please, note that in leap years February has 29 days.If your birthday is on the 29th of February, you celebrate it once in four years.Otherwise you birthday is celebrated each year.
        /// 
        /// Example
        /// 
        /// For birthdayDate = "02-01-2016", the output should be
        /// dayOfWeek(birthdayDate) = 5.
        /// 
        /// February 1 in 2016 is a Monday. The next year in which this same date will be Monday too is 2021. 2021 - 2016 = 5, which is the answer.
        /// 
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string birthdayDate
        /// 
        /// 
        /// A string representing the correct date in the format mm-dd-yyyy, where mm is the number of month (1-based, i.e. 01 for January, 02 for February and so on), dd is the day, and yyyy is the year.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ int(mm) ≤ 12,
        /// 1 ≤ int(dd) ≤ 31,
        /// 1900 ≤ int(yyyy) ≤ 2100.
        /// 
        /// 
        /// [output] integer
        /// 
        /// An integer describing the number of years until your birthday falls on the same day of the week.
        /// </remarks>
        public static int DayOfWeek(string birthdayDate)
        {
            DateTime bd = DateTime.Parse(birthdayDate);
            bool leapYear = bd.Day == 29 && bd.Month == 2;
            int years = 0;

            while (true)
            {
                years++;

                DateTime candidate = bd.AddYears(years);

                Console.WriteLine($"{candidate} {bd} {years} {bd.DayOfWeek} {candidate.DayOfWeek}");

                if (bd.DayOfWeek == candidate.DayOfWeek && bd.Day == candidate.Day)
                    break;
            }

            return years;
        }

        /// <remarks>
        /// Benjamin recently bought a digital clock at a magic trick shop. The seller never told Ben what was so special about it, but mentioned that one day Benjamin would be faced with a surprise.
        /// 
        /// Indeed, the clock did surprise Benjamin: without warning, at someTime the clock suddenly started going in the opposite direction! Unfortunately, Benjamin has an important meeting very soon, and knows that at leavingTime he should leave the house so as to not be late.Ben spent all his money on the clock, so has to figure out what time his clock will show when it's time to leave.
        /// 
        /// 
        /// Given the someTime at which the clock started to go backwards, find out what time will be shown on the curious clock at leavingTime.
        /// 
        /// For your convenience, here is the list of months lengths (from January to December, respectively):
        /// 
        /// Months lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
        /// Please, note that in leap years February has 29 days.
        /// 
        /// Example
        /// 
        /// For someTime = "2016-08-26 22:40" and leavingTime = "2016-08-29 10:00", the output should be
        /// curiousClock(someTime, leavingTime) = "2016-08-24 11:20".
        /// 
        /// There are 2 days, 11 hours and 20 minutes till the meeting.Thus, the clock will show 2016-08-24 11:20 at the leavingTime.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds (cs)
        /// 
        /// [input] string someTime
        /// 
        /// The time at which the clock started going backwards.It is guaranteed that the time is correct.
        /// The time is given in the format "YYYY-MM-DD HH:MM".
        /// 
        /// Guaranteed constraints:
        /// 1970-01-01 00:00 ≤ someTime.
        /// 
        /// [input] string leavingTime
        /// 
        /// The time at which Ben will have to leave for the meeting in the same format as someTime and with the same constraints.
        /// 
        /// Guaranteed constraints:
        /// someTime<leavingTime,
        /// leavingTime ≤ 2035-12-31 23:59.
        /// 
        /// [output] string
        /// 
        /// The time Ben's curious clock will show when it's time to leave in the same format as leavingTime and someTime.It is guaranteed that it will be not earlier than the midnight of January the 1st, 1970.
        /// </remarks>
        public static string CuriousClock(string someTime, string leavingTime)
        {
            DateTime st = DateTime.Parse(someTime);
            DateTime lt = DateTime.Parse(leavingTime);

            return (st - (lt - st)).ToString("yyyy-MM-dd HH:mm");
        }

        /// <remarks>
        /// You're a pretty busy billionaire, and you often fly your personal Private Jet to remote places. Usually travel doesn't bother you, but this time you are unlucky: it's New Year's Eve, and since you have to fly halfway around the world, you'll probably have to celebrate New Year's Day in mid-air!
        /// 
        /// Your course lies west of your current location and crosses several time zones.The pilot told you the exact schedule: it is known that you will take off at takeOffTime, and in minutes[i] after takeoff you will cross the ith border between time zones.After crossing each border you will have to set your wrist watch one hour earlier (every second matters to you, so you can't let your watch show incorrect time). It is guaranteed that you won't cross the IDL (i.e.after crossing each time zone border your current time will be set one hour back).
        /// 
        /// You've been thinking about this situation and realized that it might be a good opportunity to celebrate New Year's Day more than once, i.e.each time your wrist watch shows 00:00. Assuming that you set your watch immediately after the border is crossed, how many times will you be able to celebrate this New Year's Day with a nice bottle of champagne? Note that the answer should include celebrations both in mid-air and on the ground (it doesn't matter if the plane landed in the last time zone before the midnight or not, you'll not let the last opportunity to celebrate New Year slip through your fingers).
        /// 
        /// 
        /// Example
        /// 
        /// For takeOffTime = "23:35" and minutes = [60, 90, 140],
        /// the output should be
        /// newYearCelebrations(takeOffTime, minutes) = 3.
        /// 
        /// Here is the list of events by the time zones:
        /// 
        /// 
        /// initial time zone:
        /// at 23:35 your flight starts;
        /// at 00:00 you celebrate New Year for the first time;
        /// at 00:35 (60 minutes after the take off) you cross the first border;
        ///         time zone -1:
        /// at 23:35 you cross the border (00:35 by your initial time zone);
        /// at 00:00 you celebrate New Year for the second time(01:00 by your initial time zone);
        ///         at 00:05 (90 minutes after the take off) you cross the second border;
        /// time zone -2:
        /// at 23:05 you cross the border;
        ///         at 23:55 (140 minutes after the take off) you cross another border;
        ///         time zone -3:
        /// at 22:55 you cross the border;
        ///         at 00:00 you celebrate New Year for the third time.
        ///         Thus, the output should be 3. That's a lot of champagne!
        /// </remarks>
        public static int NewYearCelebrations(string takeOffTime, int[] minutes)
        {
            DateTime takeOff = DateTime.Parse(takeOffTime);
            DateTime temp = GetDate(new DateTime(1900, 1, 3, takeOff.Hour, takeOff.Minute, takeOff.Second));
            DateTime eve = new DateTime(1900, 1, 4, 0, 0, 0);
            int newsYear = 0;
            int previousTimeZone = 0;

            for (int i = 0; i < minutes.Length; i++)
            {
                DateTime initial = temp;
                DateTime final = initial.AddMinutes(minutes[i] - previousTimeZone);

                if (initial <= eve && eve <= final)
                    newsYear++;

                temp = temp.AddMinutes(minutes[i] - previousTimeZone - 60);
                previousTimeZone = minutes[i];

                Console.WriteLine($"{initial} {final} {eve} {temp}");
            }

            if (temp <= eve)
                newsYear++;

            return (newsYear);
        }

        /// <summary>
        /// helper
        /// </summary>
        public static DateTime GetDate(DateTime time)
        {
            DateTime date = time;

            if (date.Hour == 0 && date.Minute == 0 ||
                date.Hour == 12 && date.Minute == 0)
                date = date.AddDays(1);

            return (date);
        }


        /// <remarks>
        /// In an effort to be more innovative, your boss introduced a strange new tradition: the first day of every month you're allowed to work from home. You like this rule when the day falls on a Monday, because any excuse to skip rush hour traffic is great!
        /// 
        /// You and your colleagues have started calling these months regular months.Since you're a fan of working from home, you decide to find out how far away the nearest regular month is, given that the currMonth has just started.
        /// 
        /// For your convenience, here is a list of month lengths(from January to December, respectively) :
        /// 
        /// Month lengths: 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31.
        /// Please, note that in leap years February has 29 days.
        /// 
        /// Example
        /// 
        /// For currMonth = "02-2016", the output should be
        /// regularMonths(currMonth) = "08-2016".
        /// 
        /// February of 2016 year is regular, but it doesn't count since it has started already, so the next regular month is August of 2016 - which is the answer.
        /// 
        /// Input/Output
        /// 
        /// [execution time limit] 3 seconds(cs)
        /// 
        /// [input]
        ///         string currMonth
        /// 
        /// A string representing the current month in the format mm-yyyy, where mm is the number of the month(1-based, i.e. 01 for January, 02 for February and so on) and yyyy is the year.
        /// 
        /// Guaranteed constraints:
        /// 1 ≤ int(mm) ≤ 12,
        /// 1970 ≤ int(yyyy) ≤ 2100.
        /// 
        /// 
        /// [output] string
        /// 
        /// The earliest regular month after the given one in the same format as currMonth.
        /// </remarks>
        public static string RegularMonths(string currMonth)
        {
            DateTime month = DateTime.Parse(currMonth);

            do
            {
                month = month.AddMonths(1);
            }
            while (month.DayOfWeek != System.DayOfWeek.Monday);

            return month.ToString("MM-yyyy");
        }


    }
}
