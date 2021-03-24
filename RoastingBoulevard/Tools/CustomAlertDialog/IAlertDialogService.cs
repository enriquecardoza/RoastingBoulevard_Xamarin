using System;
using System.Threading.Tasks;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Tools
{
    public interface IAlertDialogService
    {
        Task ShowDialogAsync(string title, string message, string close);
        Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok);
        Task<bool> ShowDialogFood(Food food);
        Task HideDialog();
    }
}
