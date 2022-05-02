using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using JoseTFG.Models;
using System;
using System.Collections.Generic;

namespace JoseTFG.Activities
{
    [Activity(Label = "SurveyActivity")]
    public class SurveyActivity : Activity
    {
        List<Question> questions;
        LinearLayout linearLayout;
        Dictionary<int, int> radioGroups;
        Dictionary<int, int> checkBoxes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.survey);
            questions = new List<Question>(Data.AllQuestions.getSurvey());
            linearLayout = FindViewById<LinearLayout>(Resource.Id.survey);
            radioGroups = new Dictionary<int, int>();
            checkBoxes = new Dictionary<int, int>();
            PrepareSurvey();
        }

        private void PrepareSurvey()
        {
            float di = 10 * this.Resources.DisplayMetrics.Density;
            int padding = (int)Math.Round(di);
            int contador = 0;
            foreach (Question q in questions)
            {
                contador += 10;
                TextView title = new TextView(BaseContext);
                title.Text = q.Title;
                title.Id = contador;
                title.SetTextColor(Color.Black);
                title.SetPadding(padding, padding, padding, padding);
                title.SetTextSize(Android.Util.ComplexUnitType.Dip, 20);
                linearLayout.AddView(title);
                if (q is QuestionOneSolution)
                {
                    RadioGroup rg = new RadioGroup(BaseContext);
                    rg.Id = contador * 100;
                    radioGroups.Add(rg.Id, title.Id);
                    for (int i = 1; i <= q.Options.Count; i++)
                    {
                        RadioButton rb = new RadioButton(BaseContext);
                        rb.Id = contador + i;
                        rb.Text = q.Options[i - 1];
                        rb.SetPadding(0, 6, 0, 6);
                        rg.AddView(rb);
                    }
                    linearLayout.AddView(rg);

                }
                else
                {
                    LinearLayout ll = new LinearLayout(BaseContext);
                    ll.Orientation = Orientation.Vertical;
                    ll.Id = contador * 100;
                    checkBoxes.Add(ll.Id, title.Id);
                    for (int i = 1; i <= q.Options.Count; i++)
                    {
                        CheckBox c = new CheckBox(BaseContext);
                        c.Text = q.Options[i - 1];
                        c.SetPadding(0, 6, 0, 6);
                        ll.AddView(c);
                    }
                    linearLayout.AddView(ll);
                }
            }
            Button sendSurvey = new Button(new ContextThemeWrapper(this, Resource.Style.Button1), null, 0);
            sendSurvey.Text = "Enviar cuestionario";
            sendSurvey.SetPadding(0, padding, 0, padding);
            sendSurvey.Click += checkSurvey;
            linearLayout.AddView(sendSurvey);
        }

        private void checkSurvey(object sender, EventArgs eventArgs)
        {
            bool missAnswer = false;
            for (int i = 1; i < linearLayout.ChildCount; i += 2)
            {
                var child = linearLayout.GetChildAt(i);
                Question q = questions[i / 2];
                if (q.NoAnswer) continue;

                if (child is RadioGroup)
                {
                    RadioGroup aux = (RadioGroup)child;
                    int checkRadioButton = aux.CheckedRadioButtonId;
                    TextView tv = FindViewById<TextView>(radioGroups[aux.Id]);
                    if (checkRadioButton == -1)
                    {
                        tv.SetBackgroundColor(Color.Red);
                        missAnswer = true;
                    }
                    else
                    {
                        tv.SetBackgroundColor(Color.White);
                    }
                }
            }
            if (missAnswer)
            {
                Toast toast = Toast.MakeText(this, "Faltan preguntas por responder", ToastLength.Short);
                toast.Show();
            }
            else
            {
                saveAnswers();
            }
        }

        private void saveAnswers()
        {
            for (int i = 1; i < linearLayout.ChildCount; i += 2)
            {
                var child = linearLayout.GetChildAt(i);
                if (child is RadioGroup)
                {
                    QuestionOneSolution q = (QuestionOneSolution)questions[i / 2];
                    RadioGroup aux = (RadioGroup)child;
                    int checkRadioButton = aux.CheckedRadioButtonId;
                    if (checkRadioButton != -1)
                    {
                        q.AnswerPosition = aux.IndexOfChild(FindViewById<RadioButton>(checkRadioButton));
                    }
                }
                else if (child is LinearLayout j)
                {

                    QuestionMultipleSolutions q = (QuestionMultipleSolutions)questions[i / 2];
                    for (int y = 0; y < j.ChildCount; y++)
                    {
                        CheckBox c = (CheckBox)j.GetChildAt(y);
                        q.Answers.Add(c.Checked);
                    }
                }
            }
                List<Question> borrar = new List<Question>(questions);
        }
    }
}