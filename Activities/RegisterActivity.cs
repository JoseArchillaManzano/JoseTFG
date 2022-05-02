using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Google.Android.Material.TextField;
using JoseTFG.WebReference;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
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

            etUserName = FindViewById<TextInputEditText>(Resource.Id.et_username);
            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            etConfirmPassword = FindViewById<EditText>(Resource.Id.et_confirm_password);
            etEmail = FindViewById<TextInputEditText>(Resource.Id.et_email);
            bSignUp = FindViewById<Button>(Resource.Id.button_signin);
            ws = new WS_Breathing();

            bSignUp.Click += register;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
            else if (!textPassword.Equals(textConfirm))
            {
                Toast toast = Toast.MakeText(this, Resource.String.mismatched_password, ToastLength.Short);
                toast.Show();
            }
            else if (!validEmail(textEmail))
            {
                Toast toast = Toast.MakeText(this, Resource.String.mail_no_valid, ToastLength.Short);
                toast.Show();
            }
            else
            {
                bool result = ws.Registrar(textUser, textPassword, "usuario", textEmail);
                if (result)
                {
                    Intent intent = new Intent(this, typeof(SurveyActivity));
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

        private Boolean validEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}