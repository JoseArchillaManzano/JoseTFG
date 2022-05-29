using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace JoseTFG.Activities
{
    [Activity(Label = "ResultHealthyActivity")]
    public class ResultHealthyActivity : Activity
    {
        TextView tRiskEpoc;
        TextView tRiskSahos;
        TextView tIndicationEpoc;
        TextView tIndicationSahos;
        Button bBack;
        string riskEpoc;
        string riskSahos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.result_health_evaluation);
            tRiskEpoc = FindViewById<TextView>(Resource.Id.textRiskEpoc);
            tRiskSahos = FindViewById<TextView>(Resource.Id.textRiskSahos);
            tIndicationEpoc = FindViewById<TextView>(Resource.Id.textIndicationEpoc);
            tIndicationSahos = FindViewById<TextView>(Resource.Id.textIndicationSahos);
            bBack = FindViewById<Button>(Resource.Id.bBackResult);
            bBack.Click += backMenu;
            riskEpoc = Intent.GetStringExtra("riskEpoc");
            riskSahos = Intent.GetStringExtra("riskSahos");

            if (riskEpoc == "ALTO RIESO")
            {
                tRiskEpoc.Text = Resources.GetString(Resource.String.risk_high);
                tRiskEpoc.Background = GetDrawable(Resource.Drawable.rounded_corner_high);
                tIndicationEpoc.Text = Resources.GetString(Resource.String.text_high);
            }
            else if (riskEpoc == "BAJO RIESO")
            {
                tRiskEpoc.Text = Resources.GetString(Resource.String.risk_low);
                tRiskEpoc.Background = GetDrawable(Resource.Drawable.rounded_corner_low);
                tIndicationEpoc.Text = Resources.GetString(Resource.String.text_low);
            }
            else
            {
                tRiskEpoc.Text = Resources.GetString(Resource.String.risk_nonexistent);
                tRiskEpoc.Background = GetDrawable(Resource.Drawable.rounded_corner_not);
                tIndicationEpoc.Text = Resources.GetString(Resource.String.text_nonexistent);
            }

            if (riskSahos == "ALTO RIESO")
            {
                tRiskSahos.Text = Resources.GetString(Resource.String.risk_high);
                tRiskSahos.Background = GetDrawable(Resource.Drawable.rounded_corner_high);
                tIndicationSahos.Text = Resources.GetString(Resource.String.text_high);
            }
            else if (riskSahos == "BAJO RIESO")
            {
                tRiskSahos.Text = Resources.GetString(Resource.String.risk_low);
                tRiskSahos.Background = GetDrawable(Resource.Drawable.rounded_corner_low);
                tIndicationSahos.Text = Resources.GetString(Resource.String.text_low);
            }
            else
            {
                tRiskSahos.Text = Resources.GetString(Resource.String.risk_nonexistent);
                tRiskSahos.Background = GetDrawable(Resource.Drawable.rounded_corner_not);
                tIndicationSahos.Text = Resources.GetString(Resource.String.text_nonexistent);
            }
        }

        private void backMenu(object sender, EventArgs eventArgs)
        {
            base.OnBackPressed();
        }
    }
}