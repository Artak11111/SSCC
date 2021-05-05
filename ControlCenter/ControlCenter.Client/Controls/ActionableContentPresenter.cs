using System.Windows;
using System.Windows.Controls;

namespace ControlCenter.Client.Controls
{
    public class ActionableContentPresenter : ContentControl
    {
        static ActionableContentPresenter()
        {
            ContentProperty.OverrideMetadata(typeof(ActionableContentPresenter),
             new FrameworkPropertyMetadata(OnContentChanged));
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mcc = d as ActionableContentPresenter;
            mcc?.ContentChanged?.Invoke(mcc,
                  new DependencyPropertyChangedEventArgs(ContentProperty, e.OldValue, e.NewValue));
        }
        public event DependencyPropertyChangedEventHandler ContentChanged;
    }
}
