using System.Windows.Input;
using System;

namespace WPF.CryptoGen.Client.Core
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) => (_canExecute, _execute) = (canExecute, execute);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
