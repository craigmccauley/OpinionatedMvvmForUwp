using System;
using System.Windows.Input;

namespace MvvmApp.Infrastructure.Common;
public abstract class CommandBase : ICommand
{
    public event EventHandler CanExecuteChanged;
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    public bool CanExecute(object parameter) => true;

    public event EventHandler ExecuteCompleted;
    protected abstract void ExecuteCommand(object parameter);
    public void Execute(object parameter)
    { 
        ExecuteCommand(parameter);
        ExecuteCompleted?.Invoke(this, EventArgs.Empty);
    }
}