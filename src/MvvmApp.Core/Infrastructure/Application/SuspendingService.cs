using Windows.ApplicationModel;

namespace MvvmApp.Infrastructure.Application;

public interface ISuspendingService
{
    void OnSuspending(object sender, SuspendingEventArgs e);
}

public class SuspendingService : ISuspendingService
{
    public void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        //TODO: Save application state and stop any background activity
        deferral.Complete();
    }
}
