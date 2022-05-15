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
            // Create a timer with a two second interval.
            timer = new Timer(1500);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            timer.Stop();
            timer.Dispose();
            Finish();
        }

    }
}