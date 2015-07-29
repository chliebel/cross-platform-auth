using System;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using Thinktecture.IdentityModel.Client;

namespace WpfApplication
{
	public partial class MainWindow
	{
		readonly WebViewWindow _login;
		AuthorizeResponse _response;

		public MainWindow()
		{
			InitializeComponent();

			_login = new WebViewWindow();
			_login.Done += _login_Done;

			Loaded += MainWindow_Loaded;
		}

		void _login_Done(object sender, AuthorizeResponse e)
		{
			_response = e;
			TextBox1.Text = e.Raw;
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			_login.Owner = this;
		}

		private void AuthenticateClick(object sender, RoutedEventArgs e)
		{
			var client = new OAuth2Client(new Uri("http://localhost:8081/connect/authorize"));
			var startUrl = client.CreateAuthorizeUrl(
				clientId: "wpf",
				responseType: "token",
				scope: "sample_webapi",
				redirectUri: "oob://localhost/wpfclient");

			_login.Show();
			_login.Start(new Uri(startUrl), new Uri("oob://localhost/wpfclient"));
		}

		private async void PerformRequestClick(object sender, RoutedEventArgs e)
		{
			var client = new HttpClient()
			{
				BaseAddress = new Uri("http://localhost:8082/api/")
			};

			if (_response == null && !_response.Values.ContainsKey("access_token"))
			{
				MessageBox.Show("Bisher wurde keine Antwort erhalten oder die Antwort schloss keinen Access-Token ein!");
				return;
			}

			client.SetBearerToken(_response.AccessToken);

			var response = await client.GetAsync("Profile/GetProfile");

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var json = await response.Content.ReadAsStringAsync();
				TextBox1.Text = JObject.Parse(json).ToString();
				Image1.Source = new BitmapImage(new Uri(JObject.Parse(json).Value<string>("ImageUrl")));
			}
			else
			{
				MessageBox.Show(response.StatusCode.ToString());
			}
		}
	}
}
