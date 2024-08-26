using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Noter.ViewModel
{
    public class MainWindowViewModel : DependencyObject
    {
        public DependencyObject UserControlViewModel
        {
            get { return (DependencyObject)GetValue(UserControlViewModelProperty); }
            set { SetValue(UserControlViewModelProperty, value); }
        }
        public static readonly DependencyProperty UserControlViewModelProperty =
               DependencyProperty.Register("UserControlViewModel", typeof(DependencyObject), typeof(MainWindowViewModel), new PropertyMetadata());

        public MainWindowViewModel()
        {
          //  UserControlViewModel = new EditUserControlViewModel();
        }
    }
}
