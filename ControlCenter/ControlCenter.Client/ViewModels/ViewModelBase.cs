using ControlCenter.Client.Models;

namespace ControlCenter.Client.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        #region Properties

        private int blockCount = 0;

        public bool IsBusy
        {
            get => blockCount > 0;
            set
            {
                blockCount = value
                    ? ++blockCount
                    : blockCount == 0
                        ? 0
                        : --blockCount;

                OnPropertyChanged(nameof(IsBusy));
            }
        }

        #endregion Properties
    }
}