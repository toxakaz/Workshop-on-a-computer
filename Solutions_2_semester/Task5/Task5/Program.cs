﻿using System;
using System.Collections.Generic;
using System.Timers;

namespace Task5
{
    public static class DateTimeExtension
    {
        public static int GetTime(this DateTime time)
        {
            return time.Millisecond + time.Second * 1000 + time.Minute * 60000 + time.Hour * 320000;
        }
    }
    class Program
    {
        public static void Main() { }
    }
}
