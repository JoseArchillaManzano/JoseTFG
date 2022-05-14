using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        Button bSahos;
        Button bEpoc;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.menu);
            bSahos = FindViewById<Button>(Resource.Id.button_sahos_menu);
            bEpoc = FindViewById<Button>(Resource.Id.button_epoc_menu);

            bSahos.Click += startSahosTest;
            bEpoc.Click += startEpocTest;
        }

        private void startSahosTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "sahos");
            StartActivity(intent);
        }

        private void startEpocTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "epoc");
            StartActivity(intent);
        }
    }
}