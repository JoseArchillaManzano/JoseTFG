using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using JoseTFG.Models;
using JoseTFG.WebReference;
using System;
namespace JoseTFG.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : AppCompatActivity
    {
        TextInputEditText etEmail;
        TextInputEditText etUserName;
        EditText etPassword;
        EditText etConfirmPassword;
        Button bSignUp;
        WS_Breathing ws;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.register);
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.NavigationClick += (send, args) =>
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
                Finish();
            };
            SupportActionBar.Title = "";
            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            etConfirmPassword = FindViewById<EditText>(Resource.Id.et_confirm_password);
            etEmail = FindViewById<TextInputEditText>(Resource.Id.et_email);
            bSignUp = FindViewById<Button>(Resource.Id.button_signin);
            ws = new WS_Breathing();

            bSignUp.Click += register;
        }

        private void register(object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }

            var textEmail = etEmail.Text;
            var textUser = etUserName.Text;
            var textPassword = etPassword.Text;
            var textConfirm = etConfirmPassword.Text;


            if (textEmail == "" || textUser == "" || textPassword == "" || textConfirm == "")
            {
                Toast toast = Toast.MakeText(this, Resource.String.missing_fields, ToastLength.Short);
                toast.Show();
            }
            else if (!Helper.validEmail(textEmail))
            {
                Toast toast = Toast.MakeText(this, Resource.String.mail_no_valid, ToastLength.Short);
                toast.Show();
            }
            else if (!textPassword.Equals(textConfirm))
            {
                Toast toast = Toast.MakeText(this, Resource.String.mismatched_password, ToastLength.Short);
                toast.Show();
            }
            else if (!Helper.strongPassword(textPassword))
            {
                Toast toast = Toast.MakeText(this, Resource.String.password_no_strong, ToastLength.Long);
                toast.Show();
            }
            else
            {
                bool result = ws.Registrar(textUser, textPassword, "usuario", textEmail);
                if (result)
                {
                    User.userName = etUserName.Text;
                    User.password = etPassword.Text;
                    Intent intent = new Intent(this, typeof(MenuActivity));
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast toast = Toast.MakeText(this, Resource.String.user_already_registered, ToastLength.Short);
                    toast.Show();
                }
            }
        }
    }
}