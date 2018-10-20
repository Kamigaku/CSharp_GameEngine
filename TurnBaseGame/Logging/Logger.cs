using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurnBaseGame.Logging
{
    public static class Logger
    {

        public enum LogLevel
        {
            DEBUG,
            ERROR
        }

        static Logger() { }

        public static void Log(LogLevel level, string message)
        {
            string msg = "[Thread n°" + Thread.CurrentThread.ManagedThreadId + "] : " + message;
            Console.WriteLine(msg);
        }

    }
}
