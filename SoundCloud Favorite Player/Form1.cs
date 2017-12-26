namespace SoundCloud_Favorite_Player
{
    using Newtonsoft.Json;
    using SoundCloud_Favorite_Player.SoundCloud.Dialogs;
    using SoundCloud_Favorite_Player.SoundCloud.Models;
    using SoundCloud_Favorite_Player.SoundCloud.Models.Security;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UserAccount account;
        List<Favorite> Favorites;

        private async void Init()
        {
            string uApath = string.Format(@"{0}\\ua", Environment.CurrentDirectory);
            if (!File.Exists(uApath))
            {
                using (LoginDialog diag = new LoginDialog() { CancelButtonVisible = false })
                {
                    account = new UserAccount();
                    account.Username = diag.Username;
                    account.Password = diag.Password;

                    try
                    {
                        await account.Login("93b91d45311209981dbbb60b58dd1964", "03ea3608ebe2f2a834d4d7f7a01e598d");
                    }
                    catch
                    {
                        Init();
                    }

                    await account.Save(uApath);
                }
            }
            else
            {
                account = await UserAccount.Load(uApath);
            }

            Favorites = new List<Favorite>();
            await GetFavoritesAsync("https://api.soundcloud.com/me/favorites?oauth_token=" + account.AccessToken);
        }

        async Task GetFavoritesAsync(string uri)
        {
            string page = await GetPageSource(uri);

            if (page == null)
                return;

            Data data = JsonConvert.DeserializeObject<Data>(page);

            if (data != null)
            {
                Favorites.AddRange(data.Collection);
                
                if (data.NextPage != null)
                {
                    await GetFavoritesAsync(data.NextPage);
                }
            }
        }

        private async Task<string> GetPageSource(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage message = await client.GetAsync(url))
                {
                    if (message.StatusCode != System.Net.HttpStatusCode.OK)
                        return null;

                    return await message.Content.ReadAsStringAsync();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
