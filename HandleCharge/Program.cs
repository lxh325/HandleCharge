using HandleCharge.BLL;
using HandleCharge.Common;

DisableConsoleQuickEdit.Go();
new AutoHandleChargeBLL().Start();
var cancellationTokenSource = new CancellationTokenSource();
AppDomain.CurrentDomain.ProcessExit += (s, e) => cancellationTokenSource.Cancel();
Console.CancelKeyPress += (s, e) => cancellationTokenSource.Cancel();
await Task.Delay(-1, cancellationTokenSource.Token).ContinueWith(t => { });