using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Views.Commands
{
    public interface ICustomeCommand : ICommand
    {
        void RaiseCanExecuteChanged([CallerMemberName] string callerName = null);
    }
}
