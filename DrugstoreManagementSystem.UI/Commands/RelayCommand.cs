using System;
using System.Windows.Input;

namespace DrugstoreManagementSystem.UI.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = _canExecuteEvaluator.Invoke();

                return result;
            }
        }

        public void Execute(object parameter)
        {
            _methodToExecute.Invoke();
        }
    }
}