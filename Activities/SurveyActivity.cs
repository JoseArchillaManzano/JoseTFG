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
        string title = "";
        RadioGroup rg1 = null;
        RadioGroup rg8 = null;
        int tamSurveySahos;
        int tamSurveyEpoc;
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
                base.OnBackPressed();
                Finish();
            });
            alert.SetNegativeButton(Resources.GetString(Resource.String.cancel_dialog_survey), (senderAlert, args) => { });

            dialog = alert.Create();

            option = Intent.GetStringExtra("option");
            if (option == "sahos")
            {
                SetContentView(Resource.Layout.survey_sahos);
                title = GetString(Resource.String.title_survey_sahos);
                questions = new List<Question>(Data.SahosQuestion.getSahosSurvey());
                rg1 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos1);
                rg1.CheckedChange += (_, args) => { toogleQuestionVisibility(args.CheckedId, 1); };
                rg8 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos8);
                rg8.CheckedChange += (_, args) => { toogleQuestionVisibility(args.CheckedId, 8); };
            }
            else if (option == "epoc")
            {
                SetContentView(Resource.Layout.survey_epoc);
                title = GetString(Resource.String.title_epoc_sahos);
                questions = new List<Question>(Data.EpocQuestion.getEpocSurvey());
            }

            else
            {
                SetContentView(Resource.Layout.survey_health_evaluation);
                title = GetString(Resource.String.title_survey_health_evaluation);
                questions = new List<Question>(Data.SahosQuestion.getSahosSurvey());
                tamSurveySahos = questions.Count;
                questions.AddRange(Data.EpocQuestion.getEpocSurvey());
                tamSurveyEpoc = questions.Count - tamSurveySahos;
                rg1 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos1);
                rg1.CheckedChange += (_, args) => { toogleQuestionVisibility(args.CheckedId, 1); };
                rg8 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos8);
                rg8.CheckedChange += (_, args) => { toogleQuestionVisibility(args.CheckedId, 8); };

            }
            linearLayout = FindViewById<LinearLayout>(Resource.Id.survey);
            bSurvey = FindViewById<Button>(Resource.Id.buttonSendSurvey);
            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.SetNavigationOnClickListener(this);
            SupportActionBar.Title = title;

            bSurvey.Click += checkSurvey;
            resultTest = new int[linearLayout.ChildCount / 2];
            ws = new WS_Breathing();
        }

        private void toogleQuestionVisibility(int idRadioButton, int question)
        {
            if (question == 1)
            {
                int position = rg1.IndexOfChild(FindViewById<RadioButton>(idRadioButton));
                TextView text2 = FindViewById<TextView>(Resource.Id.textViewSahos2);
                TextView text3 = FindViewById<TextView>(Resource.Id.textViewSahos3);
                TextView text4 = FindViewById<TextView>(Resource.Id.textViewSahos4);
                TextView text5 = FindViewById<TextView>(Resource.Id.textViewSahos5);

                RadioGroup rGroup2 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos2);
                RadioGroup rGroup3 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos3);
                RadioGroup rGroup4 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos4);
                RadioGroup rGroup5 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos5);

                text2.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                text3.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                text4.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                text5.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;

                rGroup2.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                rGroup3.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                rGroup4.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                rGroup5.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
            }
            else if (question == 8)
            {
                int position = rg8.IndexOfChild(FindViewById<RadioButton>(idRadioButton));
                TextView text9 = FindViewById<TextView>(Resource.Id.textViewSahos9);
                RadioGroup rGroup9 = FindViewById<RadioGroup>(Resource.Id.radioGroupSahos9);
                text9.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
                rGroup9.Visibility = position == 0 ? ViewStates.Gone : ViewStates.Visible;
            }

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
                    QuestionOneSolution q = (QuestionOneSolution)questions[i / 2];
                    RadioGroup aux = (RadioGroup)child;
                    int checkRadioButton = aux.CheckedRadioButtonId;
                    if (checkRadioButton != -1)
                    {
                        q.AnswerPosition = aux.IndexOfChild(FindViewById<RadioButton>(checkRadioButton));
                        resultTest[i / 2] = q.getPunctuation();
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
            Enfermedad e;

            if (option != "health")
            {
                e = option == "sahos" ? enfermedades[0] : enfermedades[1];
                var risk = ws.riesgoEnfermedad(e.nombre, resultTest);
                Intent intent = new Intent(this, typeof(ResultActivity));
                intent.PutExtra("risk", risk);
                StartActivity(intent);
                Finish();
            }
            else
            {
                int[] resultSahos = new int[tamSurveySahos];
                int[] resultEpoc = new int[tamSurveyEpoc];
                for (int i = 0; i < tamSurveySahos; i++) resultSahos[i] = resultTest[i];
                for (int i = tamSurveySahos; i < questions.Count; i++) resultEpoc[i - tamSurveySahos] = resultTest[i];
                var riskSahos = ws.riesgoEnfermedad(enfermedades[0].nombre, resultSahos);
                var riskEpoc = ws.riesgoEnfermedad(enfermedades[1].nombre, resultEpoc);
                Intent intent = new Intent(this, typeof(ResultHealthyActivity));
                intent.PutExtra("riskSahos", riskSahos);
                intent.PutExtra("riskEpoc", riskEpoc);
                StartActivity(intent);
                Finish();
            }


        }
        public void OnClick(View v)
        {
            dialog.Show();
        }

        public override void OnBackPressed()
        {
            dialog.Show();
        }


    }
}