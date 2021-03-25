using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RoastingBoulevard.Tools
{
    public class Tools
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public static void PushAsync(string tittle,INavigation navigation, Page page)
        {
            NavigationPage newpage = new NavigationPage(page);
            newpage.Title = tittle;
            Device.BeginInvokeOnMainThread(async () => await navigation.PushAsync(newpage));
        }
        public static void PushAsync(INavigation navigation, Page page)
        {
            NavigationPage newpage = new NavigationPage(page);
            Device.BeginInvokeOnMainThread(async () => await navigation.PushAsync(newpage));
        }
        public static void PopAsync(INavigation navigation)
        {
            Device.BeginInvokeOnMainThread(async () => await navigation.PopAsync());
        }
        public static void PopToRootAsync(INavigation navigation)
        {
            Device.BeginInvokeOnMainThread(async () => await navigation.PopToRootAsync());
        }
        public static void UseActionMainThread(Action action)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                action.Invoke();
            });
        }
    }
}
