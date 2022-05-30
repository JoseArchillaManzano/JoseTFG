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
using System.Timers;

namespace JoseTFG.Activities
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : AppCompatActivity
    {
        TextInputEditText etEmail;
        EditText etPassword;
        EditText etConfirmPassword;
        Android.App.AlertDialog.Builder alert;
        Dialog dialog;
        Button bEmail;
        Button bPassword;
        Button bDelete;
        WS_Breathing ws;
        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.profile);
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.NavigationClick += (send, args) =>
            {
                Intent intent = new Intent(this, typeof(MenuActivity));
                StartActivity(intent);
                Finish();
            };
            SupportActionBar.Title = "Perfil";

            alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle(Resources.GetString(Resource.String.title_dialog_delete));
            alert.SetMessage(Resources.GetString(Resource.String.message_dialog_delete));
            alert.SetPositiveButton(Resources.GetString(Resource.String.confirm_dialog_delete), (senderAlert, args) =>
            {
                bool result = ws.delUser(User.userName, User.password);
                if (result)
                {
                    Toast toast = Toast.MakeText(this, Resource.String.successful_delete, ToastLength.Short);
                    toast.Show();
                    SetTimer();
                }
            });
            alert.SetNegativeButton(Resources.GetString(Resource.String.cancel_dialog_delete), (senderAlert, args) => { });

            dialog = alert.Create();

            etPassword = FindViewById<EditText>(Resource.Id.et_password);
            etConfirmPassword = FindViewById<EditText>(Resource.Id.et_confirm_password);
            etEmail = FindViewById<TextInputEditText>(Resource.Id.et_email);
            bEmail = FindViewById<Button>(Resource.Id.button_update_email);
            bPassword = FindViewById<Button>(Resource.Id.button_update_password);
            bDelete = FindViewById<Button>(Resource.Id.button_delete);

            bDelete.Click += deleteAccount;
            bEmail.Click += updateEmail;
            bPassword.Click += updatePassword;
            ws = new WS_Breathing();
        }

        private void SetTimer()
        {
            timer = new Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            timer.Stop();
            timer.Dispose();
            timer = null;
            Finish();
        }
        private void updateEmail(object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
            var textEmail = etEmail.Text;
            if (!Helper.validEmail(textEmail))
            {
                Toast toast = Toast.MakeText(this, Resource.String.mail_no_valid, ToastLength.Short);
                toast.Show();
            }
            else
            {
                bool result = ws.Upd_eMail(User.userName, User.password, textEmail);
                if (result)
                {
                    Toast toast = Toast.MakeText(this, Resource.String.successful_update, ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    Toast toast = Toast.MakeText(this, Resource.String.no_successful_update, ToastLength.Short);
                    toast.Show();
                }
            }
        }

        private void updatePassword(object sender, EventArgs eventArgs)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
            var textPassword = etPassword.Text;
            var textConfirmPassword = etConfirmPassword.Text;
            if (textPassword != textConfirmPassword)
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
                bool result = ws.UpdPwd(User.userName, User.password, textPassword);
                if (result)
                {
                    Toast toast = Toast.MakeText(this, Resource.String.successful_update, ToastLength.Short);
                    toast.Show();
                    User.password = textPassword;
                }
                else
                {
                    Toast toast = Toast.MakeText(this, Resource.String.no_successful_update, ToastLength.Short);
                    toast.Show();
                }
            }
        }

        private void deleteAccount(object sender, EventArgs eventArgs)
        {
            dialog.Show();
        }
    }
}