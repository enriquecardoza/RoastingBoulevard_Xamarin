using Rg.Plugins.Popup.Extensions;
using RoastingBoulevard.Models;
using RoastingBoulevard.Tools;
using RoastingBoulevard.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

// https://jorgediegocrespo.wordpress.com/2020/11/18/alert-dialog-personalizado-con-xamarin-forms/
[assembly: Xamarin.Forms.Dependency(typeof(AlertDialogService))]
namespace RoastingBoulevard.Tools
{
    public class AlertDialogService : IAlertDialogService
    {
        private  static TaskCompletionSource<bool> taskCompletionSource;
        private static Task<bool> task;

        public async Task ShowDialogAsync(string title, string message, string close)
        {
            taskCompletionSource = new TaskCompletionSource<bool>();
            task = taskCompletionSource.Task;

            AlertDialogPopup alertDialog = new AlertDialogPopup(title, message, null, close, Callback);
            await Application.Current.MainPage.Navigation.PushPopupAsync(alertDialog);
            await task;
        }

        public async Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok)
        {
            taskCompletionSource = new TaskCompletionSource<bool>();
            task = taskCompletionSource.Task;

            AlertDialogPopup alertDialog = new AlertDialogPopup(title, message, cancel, ok, Callback);
            await Application.Current.MainPage.Navigation.PushPopupAsync(alertDialog);

            return await task;
        }

        private async Task Callback(bool result)
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
            if (!taskCompletionSource.Task.IsCanceled &&
                !taskCompletionSource.Task.IsCompleted &&
                !taskCompletionSource.Task.IsFaulted)
            {
                taskCompletionSource.SetResult(result);
            }
        }

        public async Task<bool> ShowDialogFood(Food food)
        {
            taskCompletionSource = new TaskCompletionSource<bool>();
            task = taskCompletionSource.Task;
            SelectedFood alertDialog = new SelectedFood(food, Callback);
            await Application.Current.MainPage.Navigation.PushPopupAsync(alertDialog);
            return await task;
        }
        public async Task HideDialog()
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
        }
    }
}
