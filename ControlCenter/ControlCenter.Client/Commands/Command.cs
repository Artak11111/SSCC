using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControlCenter.Client.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Func<Task> executeAsync;
        private readonly Action execute;

        public Command(Func<Task> executeAsync)
        {
            this.executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        }

        public Command(Action execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                if (execute != null)
                    execute();
                else if (executeAsync != null)
                    await executeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application error");
            }
        }
    }
}
