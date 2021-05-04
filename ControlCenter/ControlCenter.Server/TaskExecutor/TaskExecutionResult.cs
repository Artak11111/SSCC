namespace ControlCenter.Server.TaskExecutor
{
    public class TaskExecutionResult<T>
    {
        public T Result { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class TaskExecutionResult
    { 

        public string ErrorMessage { get; set; }
    }
}
