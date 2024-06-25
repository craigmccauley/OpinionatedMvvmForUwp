using System;
using System.Windows.Input;

namespace MvvmApp.Infrastructure.ViewModel;
public abstract class CommandBase : ICommand
{
    public event EventHandler CanExecuteChanged;
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    public virtual bool CanExecute(object parameter) => true;
    public abstract void Execute(object parameter);
}