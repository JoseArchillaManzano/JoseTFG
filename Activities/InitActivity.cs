using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Timers;

namespace JoseTFG.Activities
{
    [Activity(Label = "InitActivity", MainLauncher = true)]
    public class InitActivity : Activity
    {
        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTimer();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.init);
            // Create your application here

        }

        private void SetTimer()
        {
            timer = new Timer(100);
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

    }
}