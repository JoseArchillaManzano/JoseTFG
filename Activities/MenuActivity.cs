using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : AppCompatActivity
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

            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Cuestionarios";
            bSahos.Click += startSahosTest;
            bEpoc.Click += startEpocTest;
            bHealthEvaluation.Click += startHealthEvaluationTest;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu1, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.item_perfil:
                    //showMenu();
                    Intent intent = new Intent(this, typeof(ProfileActivity));
                    StartActivity(intent);
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

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

        private void startHealthEvaluationTest(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(SurveyActivity));
            intent.PutExtra("option", "health");
            StartActivity(intent);
        }
    }
}