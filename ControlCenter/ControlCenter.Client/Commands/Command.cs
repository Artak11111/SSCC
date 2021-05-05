using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControlCenter.Client.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Func<Task> execute;

        public Command(Func<Task> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await execute();
                    
            }
            catch
            {
                MessageBox.Show("Application error");
            }
        }
    }
}
