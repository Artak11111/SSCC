using ControlCenter.Client.Managers;
using System;
using System.Windows.Input;

namespace ControlCenter.Client.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

        private string email;
        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }

        public ICommand SignInCommand => new Command(async ()=>
        {
            var accountManager = new AccountManager(new Client.ApiClient());

            await accountManager.SignIn(Email, null);
        });
    }


    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action execute;

        public Command(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}