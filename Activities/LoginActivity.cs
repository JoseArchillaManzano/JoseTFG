using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Android.Material.TextField;
using JoseTFG.Models;
using JoseTFG.WebReference;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        TextInputEditText etUserName;
        EditText etPassword;
        Button bForgotPassword;
        Button bSignIn;
        Button bSignUp;
        WS_Breathing ws;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here
            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            bForgotPassword = FindViewById<Button>(Resource.Id.button_forgot_password);
            bSignIn = FindViewById<Button>(Resource.Id.button_signin);
            bSignUp = FindViewById<Button>(Resource.Id.button_signup);
            ws = new WS_Breathing();

            bSignIn.Click += signIn;
            bSignUp.Click += signUp;
            bForgotPassword.Click += forgotPassword;
        }
        private void signIn(object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
            if (ws.EstaRegistrado(etUserName.Text, etPassword.Text))
            {
                User.userName = etUserName.Text;
                User.password = etPassword.Text;
                Intent intent = new Intent(this, typeof(MenuActivity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast failSignIn = Toast.MakeText(this, Resource.String.fail_login, ToastLength.Short);
                failSignIn.Show();
            }
        }

        private void signUp(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        private void forgotPassword(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(ForgotPasswordActivity));
            StartActivity(intent);
        }
    }
}