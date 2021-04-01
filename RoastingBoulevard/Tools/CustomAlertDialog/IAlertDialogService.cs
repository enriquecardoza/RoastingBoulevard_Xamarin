using System;
using System.Threading.Tasks;
using RoastingBoulevard.Models;
using Xamarin.Forms;

namespace RoastingBoulevard.Tools
{
    public interface IAlertDialogService
    {
        Task ShowDialogAsync(string title, string message, string close);
        Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok);
        Task<bool> ShowDialogFood(Food food);
        Task<bool> ShowDialogDelivering();
        Task HideDialog();
    }
}
