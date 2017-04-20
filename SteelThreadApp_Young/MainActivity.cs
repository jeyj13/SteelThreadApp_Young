using Android.App;
using Android.Widget;
using Android.OS;
using System.Text;
using System.Net.Http;
using System;

namespace SteelThreadApp_Young
{
    [Activity(Label = "SteelThreadApp_Young", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btn1;
        private EditText txt1;
        private string editTextString;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            txt1 = FindViewById<EditText>(Resource.Id.txtInput);
            btn1 = FindViewById<Button>(Resource.Id.btnSend);
            btn1.Click += btn1_Click;

        }
        protected override void OnStart()
        {
            base.OnStart();


        }
        private void btn1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                editTextString = txt1.Text;
                var url = string.Format("https://jacobproject.azurewebsites.net/api/HttpTriggerCSharp1?code=CF5a7FaDJ/SkohQ9H8q0gyZg4zsMIzya7VvxKliNW5nxITavR25TUA==");
                var content = new StringContent("{passedString:'" + editTextString + "'}", Encoding.UTF8, "application/json");
                client.PostAsync(url, content).Result.EnsureSuccessStatusCode();
            }
        }
    }
    }

