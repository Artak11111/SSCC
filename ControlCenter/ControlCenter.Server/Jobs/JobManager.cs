using ControlCenter.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace ControlCenter.Server.Jobs
{
    public class JobManager : IJobManager
    {
        #region Fields

        private readonly Dictionary<string, Timer> timers = new Dictionary<string, Timer>();

        #endregion Fields

        #region Methods

        public void CreateJob(string key, int intervalInSeconds, Func<Task> job)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (job == null) throw new ArgumentNullException(nameof(job));
            if (intervalInSeconds < 1) throw new ArgumentException("Interval must be a positive integer.");

            if (timers.ContainsKey(key)) throw new InvalidOperationException($"Job with key {key} already exists.");

            var timer = new Timer(intervalInSeconds * 1000);
            timer.Elapsed += async (s, e) =>
            {
                await Task.Run(job);
            };

            timer.Enabled = true;

            timers.Add(key, timer);
        }

        public bool ContainsJob(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            return timers.ContainsKey(key);
        }

        public bool StopJob(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (!timers.ContainsKey(key))
                return false;

            var timer = timers[key];
            timer.Enabled = false;
            timer.Dispose();
            timers.Remove(key);

            return true;
        }

        #endregion Methods
    }
}
