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
        Button bHealthEvaluation;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.menu);
            bSahos = FindViewById<Button>(Resource.Id.button_sahos_menu);
            bEpoc = FindViewById<Button>(Resource.Id.button_epoc_menu);
            bHealthEvaluation = FindViewById<Button>(Resource.Id.button_health_evaluation);

            bSahos.Click += startSahosTest;
            bEpoc.Click += startEpocTest;
            bHealthEvaluation.Click += startHealthEvaluationTest;
        }

        private void startSahosTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "sahos");
            StartActivity(intent);
            Finish();
        }

        private void startEpocTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "epoc");
            StartActivity(intent);
            Finish();
        }

        private void startHealthEvaluationTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "health");
            StartActivity(intent);
            Finish();
        }
    }
}