using System;
using System.Threading.Tasks;

namespace ControlCenter.Abstractions
{
    public interface IJobManager
    {
        void CreateJob(string key, int intervalInSeconds, Func<Task> job);

        bool ContainsJob(string key);

        bool StopJob(string key);
    }
}
