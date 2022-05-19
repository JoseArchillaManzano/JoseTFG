using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using JoseTFG.WebReference;
using System;
using static Android.Views.View;

namespace JoseTFG.Activities
{
    [Activity(Label = "ForgotPasswordActivity")]
    public class ForgotPasswordActivity : AppCompatActivity, IOnClickListener
    {
        Button bSend;
        TextInputEditText etUserName;
        WS_Breathing ws;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.forgot_password);
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.SetNavigationOnClickListener(this);
            //SupportActionBar.Title = GetString(Resource.String.title_register);
            SupportActionBar.Title = "";
            bSend = FindViewById<Button>(Resource.Id.button_send);
            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            ws = new WS_Breathing();
            bSend.Click += sendPassword;
        }

        private void sendPassword(object sender, EventArgs eventArgs)
        {
            var textUser = etUserName.Text;
            bool result = ws.RecuperaPwd(textUser);
            if (result)
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast toast = Toast.MakeText(this, Resource.String.user_not_registered, ToastLength.Short);
                toast.Show();
            }
        }

        public void OnClick(View v)
        {
            base.OnBackPressed();
        }
    }
}