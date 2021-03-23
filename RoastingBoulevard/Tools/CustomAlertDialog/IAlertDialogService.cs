using System;
using System.Threading.Tasks;

namespace RoastingBoulevard.Tools
{
    public interface IAlertDialogService
    {
        Task ShowDialogAsync(string title, string message, string close);
        Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok);
    }
}
