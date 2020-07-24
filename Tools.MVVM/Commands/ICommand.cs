using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.MVVM.Commands
{
    public interface ICommand : System.Windows.Input.ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
