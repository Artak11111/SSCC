using ControlCenter.Contracts.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace ControlCenter.Server.Jobs
{
    public class JobManager : IJobManager
    {
        #region Properties

        protected Dictionary<string, Timer> Timers { get; } = new Dictionary<string, Timer>();

        #endregion Properties

        #region Methods

        public void Create(string key, int intervalInSeconds, Func<Task> job)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if (job == null) throw new ArgumentNullException(nameof(job));
            if (intervalInSeconds < 1) throw new ArgumentException("Interval must be a positive integer.");

            if (Timers.ContainsKey(key)) throw new InvalidOperationException($"Job with key {key} already exists.");

            var timer = new Timer(intervalInSeconds * 1000);
            timer.Elapsed += async (s, e) =>
            {
                await Task.Run(job);
            };

            timer.Enabled = true;

            Timers.Add(key, timer);
        }

        public bool Contains(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            return Timers.ContainsKey(key);
        }

        public bool Stop(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            if (!Timers.ContainsKey(key))
                return false;

            var timer = Timers[key];
            timer.Enabled = false;
            timer.Dispose();
            Timers.Remove(key);

            return true;
        }

        #endregion Methods
    }
}
