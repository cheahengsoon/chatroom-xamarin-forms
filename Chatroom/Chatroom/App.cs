using Chatroom.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Chatroom
{
    public class App : Application
    {
        public static string Username { get; set; }

        public App()
        {
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("2D5672"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
