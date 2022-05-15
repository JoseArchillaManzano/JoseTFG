using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using JoseTFG.Models;
using JoseTFG.WebReference;
using System;

using System.Collections.Generic;
using static Android.Views.View;

namespace JoseTFG.Activities
{
    [Activity(Label = "SurveyActivity")]
    public class SurveyActivity : AppCompatActivity, IOnClickListener
    {
        List<Question> questions;
        LinearLayout linearLayout;
        Button bSurvey;
        int[] resultTest;
        WS_Breathing ws;
        string option;
        Android.App.AlertDialog.Builder alert;
        Dialog dialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here

            alert = new Android.App.AlertDialog.Builder(this);
            alert.SetTitle(Resources.GetString(Resource.String.title_dialog_survey));
            alert.SetMessage(Resources.GetString(Resource.String.message_dialog_survey));
            alert.SetPositiveButton(Resources.GetString(Resource.String.confirm_dialog_survey), (senderAlert, args) =>
            {
                Intent intent = new Intent(this, typeof(MenuActivity));
                StartActivity(intent);
                Finish();
            });
            alert.SetNegativeButton(Resources.GetString(Resource.String.cancel_dialog_survey), (senderAlert, args) => { });

            dialog = alert.Create();

            option = Intent.GetStringExtra("option");
            if (option == "sahos")
            {
                SetContentView(Resource.Layout.survey_sahos);
                linearLayout = FindViewById<LinearLayout>(Resource.Id.surveySahos);
                bSurvey = FindViewById<Button>(Resource.Id.buttonSendSurveySahos);
            }
            else if (option == "epoc")
            {
                SetContentView(Resource.Layout.survey_epoc);
                linearLayout = FindViewById<LinearLayout>(Resource.Id.surveyEpoc);
                bSurvey = FindViewById<Button>(Resource.Id.buttonSendSurveyEpoc);
            }

            else
            {
                SetContentView(Resource.Layout.survey_quality_life);
                linearLayout = FindViewById<LinearLayout>(Resource.Id.survey);
                bSurvey = FindViewById<Button>(Resource.Id.buttonSendSurvey);

            }
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.SetNavigationOnClickListener(this);


            // questions = new List<Question>(Data.AllQuestions.getSurvey());
            bSurvey.Click += checkSurvey;
            resultTest = new int[linearLayout.ChildCount / 2];
            ws = new WS_Breathing();
        }

        private void checkSurvey(object sender, EventArgs eventArgs)
        {
            bool missAnswer = false;
            for (int i = 1; i < linearLayout.ChildCount; i += 2)
            {
                var child = linearLayout.GetChildAt(i);
                // Question q = questions[i / 2];
                //if (q.NoAnswer) continue; //:TODO QUIZAS HAYA QUE DEJARLO

                if (child is RadioGroup)
                {
                    RadioGroup aux = (RadioGroup)child;
                    var id = aux.Id;
                    int checkRadioButton = aux.CheckedRadioButtonId;
                    TextView tv = (TextView)linearLayout.GetChildAt(i - 1);
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
                Toast toast = Toast.MakeText(this, Resource.String.questions_no_answered, ToastLength.Short);
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
                    // QuestionOneSolution q = (QuestionOneSolution)questions[i / 2];
                    RadioGroup aux = (RadioGroup)child;
                    int checkRadioButton = aux.CheckedRadioButtonId;
                    if (checkRadioButton != -1)
                    {
                        //q.AnswerPosition = aux.IndexOfChild(FindViewById<RadioButton>(checkRadioButton));
                        resultTest[i / 2] = aux.IndexOfChild(FindViewById<RadioButton>(checkRadioButton));
                    }
                }
                else if (child is LinearLayout j)
                {

                    // QuestionMultipleSolutions q = (QuestionMultipleSolutions)questions[i / 2];
                    for (int y = 0; y < j.ChildCount; y++)
                    {
                        CheckBox c = (CheckBox)j.GetChildAt(y);
                        // q.Answers.Add(c.Checked);
                    }
                }
            }
            consultResults();
        }

        private void consultResults()
        {
            Enfermedad[] enfermedades = ws.listaEnfermedades();
            Enfermedad e = option == "sahos" ? enfermedades[0] : enfermedades[1];

            var risk = ws.riesgoEnfermedad(e.nombre, resultTest);

            Intent intent = new Intent(this, typeof(ResultActivity));
            intent.PutExtra("risk", risk);
            StartActivity(intent);
            Finish();

        }
        public void OnClick(View v)
        {
            dialog.Show();
        }


    }
}