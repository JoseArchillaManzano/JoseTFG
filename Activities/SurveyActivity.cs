using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JoseTFG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoseTFG.Activities
{
    [Activity(Label = "SurveyActivity")]
    public class SurveyActivity : Activity
    {
        List<Question> questions;
        LinearLayout linearLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.survey);
            questions = new List<Question>(Data.AllQuestions.getSurvey());
            linearLayout = FindViewById<LinearLayout>(Resource.Id.survey);
            PrepareSurvey();
        }

        private void PrepareSurvey()
        {
            int contador = 0;
            foreach(Question q in questions){
                contador += 10;
                TextView title = new TextView(BaseContext);
                title.Text = q.Title;
                title.SetPadding(20, 20, 20, 20);
                title.SetTextSize(Android.Util.ComplexUnitType.Dip,20);
                linearLayout.AddView(title);
                RadioGroup rg = new RadioGroup(BaseContext);
                for(int i = 0; i< q.Options.Count; i++)
                {
                    RadioButton rb = new RadioButton(BaseContext);
                    rb.Id = contador + i;
                    rb.Text = q.Options[i];
                    rb.SetPadding(0, 6, 0, 6);
                    rg.AddView(rb);
                }
                linearLayout.AddView(rg);
            }
        }
    }
}