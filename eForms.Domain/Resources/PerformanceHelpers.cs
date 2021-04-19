using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Resources
{
    public static class PerformanceHelpers
    {

        public static double Analyze(Action task, string message = "")
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            task();
            timer.Stop();
            System.Diagnostics.Debug.WriteLine($"{message}: {timer.Elapsed.TotalSeconds}");
            return timer.Elapsed.TotalMilliseconds;
        }

        public async static Task<object> Analyze(Func<Task<object>> task, string message = "")
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var ret = await task();
            timer.Stop();
            System.Diagnostics.Debug.WriteLine($"{message}: {timer.Elapsed.TotalSeconds}");
            return ret;
        }

        public async static Task<T> Analyze<T>(Func<Task<T>> task, string message = "")
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var ret = await task();
            timer.Stop();
            Console.WriteLine($"{message}: {timer.Elapsed.TotalSeconds} seconds");
            return ret;
        }

    }
}
