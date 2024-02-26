namespace ControlCenter.Contracts.Contracts
{
    public interface IJobManager
    {
        void Create(string key, int intervalInSeconds, Func<Task> job);

        bool Contains(string key);

        bool Stop(string key);
    }
}
