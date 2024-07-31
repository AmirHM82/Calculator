using Calculator.Views.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Button_Click = new(x => buttonClickCommand(x), y => true);
            Operation_Click = new(x => operationClickCommand(x), y => true);
            Clear_Click = new(x => clearClickCommand(), y => true);
            Equal_Click = new(x => equalClickCommand(), y => true);
        }

        private void buttonClickCommand(object content)
        {
            if (Expression == "0")
            {
                Expression = $"{content}";
            }
            else
            {
                Expression = $"{Expression}{content}";
            }
        }

        private void operationClickCommand(object content)
        {
            Expression = $"{Expression}{content}";
        }

        private void clearClickCommand()
        {
            Expression = "0";
            Result = "";
        }

        private void equalClickCommand()
        {
            var dataTable = new DataTable();
            Result = dataTable.Compute(expression, "").ToString();
        }

        private string expression = "0";
        public string Expression
        {
            get
            {
                return expression;
            }
            set
            {
                expression = value;
                RaisePropertyChanged();
            }
        }

        private string result = "";
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand Button_Click { get; set; }
        public RelayCommand Operation_Click { get; set; }
        public RelayCommand Clear_Click { get; set; }
        public RelayCommand Equal_Click { get; set; }
    }
}
