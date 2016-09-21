using Chatroom.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Chatroom.Pages
{
    public partial class GroupChatPage : ContentPage
    {
        private HubConnection hubConnection;
        private IHubProxy chatHubProxy;

        public ObservableCollection<MessageViewModel> Messages { get; set; }

        public GroupChatPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            Title = "Chat";

            Messages = new ObservableCollection<MessageViewModel>();
            MessagesListView.ItemsSource = Messages;

            SendMessageButton.Clicked += SendMessageButton_Clicked;
        }

        private void SendMessageButton_Clicked(object sender, EventArgs e)
        {
            chatHubProxy.Invoke<string>("SendMessage", MessageEntry.Text, App.Username, DateTimeOffset.Now);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ConnectAndDoThatThang();
        }

        private async void ConnectAndDoThatThang()
        {
            try
            {
                // Connect to the server
                hubConnection = new HubConnection("http://192.168.10.2:5000");
                chatHubProxy = hubConnection.CreateHubProxy("ChatroomHub");

                chatHubProxy.On<MessageViewModel>("onMessage", message =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Messages.Add(message);
                    });
                });

                await hubConnection.Start();
            }
            catch (Exception e)
            {
                await DisplayAlert("Oops", e.Message, "Ok");
            }
        }
    }
}
