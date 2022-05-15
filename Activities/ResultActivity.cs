using Android.App;
using Android.OS;
using Android.Widget;
namespace JoseTFG.Activities
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        TextView tRisk;
        TextView tIndication;
        string risk;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.result);
            tRisk = FindViewById<TextView>(Resource.Id.textRisk);
            tIndication = FindViewById<TextView>(Resource.Id.textIndication);
            risk = Intent.GetStringExtra("risk");

            if (risk == "ALTO RIESO")
            {
                tRisk.Text = Resources.GetString(Resource.String.risk_high);
                tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_high);
                //tRisk.SetBackgroundColor(Color.Red);
                //tRisk.SetTextColor(Android.Graphics.Color.Red);
                tIndication.Text = Resources.GetString(Resource.String.text_high);
            }
            else if (risk == "BAJO RIESO")
            {
                tRisk.Text = Resources.GetString(Resource.String.risk_low);
                tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_low);
                //tRisk.SetBackgroundColor(Color.Yellow);
                //tRisk.SetTextColor(Android.Graphics.Color.LightGoldenrodYellow);
                tIndication.Text = Resources.GetString(Resource.String.text_low);
            }
            else
            {
                tRisk.Text = Resources.GetString(Resource.String.risk_nonexistent);
                tRisk.Background = GetDrawable(Resource.Drawable.rounded_corner_not);
                //tRisk.SetBackgroundColor(Color.Green);
                //tRisk.SetTextColor(Android.Graphics.Color.ForestGreen);
                tIndication.Text = Resources.GetString(Resource.String.text_nonexistent);
            }
        }
    }
}