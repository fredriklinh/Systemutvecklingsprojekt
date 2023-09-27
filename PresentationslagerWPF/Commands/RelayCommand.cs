using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationslagerWPF.Commands
{
    public class RelayCommand : CommandBase
    {

    //    private Action<object> execute;

    //    private Func<object, bool> canExecute;

    //    public event EventHandler? CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }

    //    }

    //public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    //    {
    //        this.execute = execute;
    //        this.canExecute = canExecute;
    //    }

    //    public bool CanExecute(object? parameter)
    //    {
    //        return canExecute == null || canExecute(parameter);
    //    }

    //    public void Execute(object? parameter)
    //    {
    //        execute(parameter);
    //    }




        private readonly Action _execute = null!;
        private readonly Func<bool> _canExecute = null!;
        public RelayCommand() { }
        public RelayCommand(Action execute) : this(execute, null!) { }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public override void Execute(object parameter) { _execute(); }
        public override bool CanExecute(object parameter) =>
        _canExecute == null || _canExecute();
    }
    public class RelayCommand<T> : RelayCommand
    {
        private readonly Action<T> _execute = null!;
        private readonly Func<T, bool> _canExecute = null!;
        public RelayCommand(Action<T> execute) : this(execute, null!) { }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public override void Execute(object parameter) { _execute((T)parameter); }


        public override bool CanExecute(object parameter) =>
        _canExecute == null || _canExecute((T)parameter);
    }

}
