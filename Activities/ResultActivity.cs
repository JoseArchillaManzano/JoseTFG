using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        TextView tRisk;
        TextView tIndication;
        Button bBack;
        string risk;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.result);
            tRisk = FindViewById<TextView>(Resource.Id.textRisk);
            tIndication = FindViewById<TextView>(Resource.Id.textIndication);
            bBack = FindViewById<Button>(Resource.Id.bBackResult);
            bBack.Click += backMenu;
            risk = Intent.GetStringExtra("risk");

            if (risk == "ALTO RIESO")
            {
                setHighRisk();
            }
            else if (risk == "BAJO RIESO")
            {
                setLowRisk();
            }
            else
            {
                setNoRisk();
            }
        }

        private void setHighRisk()
        {
            tRisk.Text = Resources.GetString(Resource.String.risk_high);
            tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_high);
            tIndication.Text = Resources.GetString(Resource.String.text_high);
        }
        private void setLowRisk()
        {
            tRisk.Text = Resources.GetString(Resource.String.risk_low);
            tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_low);
            tIndication.Text = Resources.GetString(Resource.String.text_low);
        }
        private void setNoRisk()
        {
            tRisk.Text = Resources.GetString(Resource.String.risk_nonexistent);
            tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_not);
            tIndication.Text = Resources.GetString(Resource.String.text_nonexistent);
        }
        private void backMenu(object sender, EventArgs eventArgs)
        {
            base.OnBackPressed();
        }
    }
}