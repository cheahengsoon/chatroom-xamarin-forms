using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Chatroom.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            LoginButton.Clicked += LoginButton_Clicked;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text))
            {
                await DisplayAlert("Ehm", "Enter a username plz", "Ok?");
                return;
            }

            App.Username = UsernameEntry.Text;
            
            await Navigation.PushAsync(new GroupChatPage(), true);
            Navigation.RemovePage(this);
            NavigationPage.SetHasBackButton(this, true);
        }
    }
}
