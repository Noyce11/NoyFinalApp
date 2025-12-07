using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using NoyFinalApp.ViewModels;

namespace NoyFinalApp
{
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : Activity
    {
        Dialog mProgressDialog;
        TextView tvToSignUp, tvResetPass;
        TaskCompletionListeners taskCompletionListeners;
        EditText etUserEmail, etUserPass;
        Button btnSignin;
        CheckBox ckStayIn;
        private readonly string TAG = "OrFinalTAG";
        bool staySignedInFlag = false;

        bool IsUserEmailEmpty = true;
        bool IsUserPassEmpty = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signin_layout);
            // Create your application here

            InitilizeViews();


        }

        private void InitilizeViews()
        {
            tvToSignUp = FindViewById<TextView>(Resource.Id.btn_sign_up);
            tvToSignUp.Click += (s, a) => { StartActivity(typeof(SignUpActivity)); };

            etUserEmail = FindViewById<EditText>(Resource.Id.et_email);
            etUserPass = FindViewById<EditText>(Resource.Id.et_password);
            btnSignin = FindViewById<Button>(Resource.Id.btn_login);
            btnSignin.Click += SignInButton_Clicked;

            etUserEmail.TextChanged += (s, a) =>
            {
                IsUserEmailEmpty = etUserEmail.Text.Length == 0 ? true : false;
                PingSignInButton();
            };
        }

        private void PingSignInButton()
        {
            if (IsUserEmailEmpty || IsUserPassEmpty)
                btnSignin.Enabled = false;
            else btnSignin.Enabled = true;
        }

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            {
                // Login with Firebase Auth
                FirebaseAuth mAuth = FireBaseHelper.GetFirebaseAuth();
                TaskCompletionListeners taskCompletionListeners = new TaskCompletionListeners();

                mAuth.SignInWithEmailAndPassword(etUserEmail.Text, etUserPass.Text)
                    .AddOnSuccessListener(taskCompletionListeners)
                    .AddOnFailureListener(taskCompletionListeners);
                ShowProgressBar(true);

                taskCompletionListeners.Success += (success, args) =>
                {
                    ShowProgressBar(false);
                    Log.Debug(TAG, $"EventCake SignIn Success: email: {etUserEmail.Text} password: {etUserPass.Text} ");

                    string userId = mAuth.CurrentUser.Uid;
                    Toast.MakeText(this, "Welcome to EventCake!", ToastLength.Short).Show();

                };

                taskCompletionListeners.Failure += (failure, args) =>
                {
                    ShowProgressBar(false);
                    Log.Debug(TAG, $"EventCake signIn Failed: email: {etUserEmail.Text} password: {etUserPass.Text} {args.Cause}");
                    Toast.MakeText(this, "Login failed:\n " + args.Cause, ToastLength.Short).Show();
                };
            }

        }
        private void ShowProgressBar(bool show)
        {
            //android:background="@android:color/transparent"
            if (show)
            {
                mProgressDialog = new Dialog(this, Android.Resource.Style.ThemeNoTitleBar);
                View view = LayoutInflater.From(this).Inflate(Resource.Layout.progress_layout, null);
                //var mProgressMessage = (TextView)view.FindViewById(Resource.Id.;
                //mProgressMessage.Text = "Loading...";
                mProgressDialog.Window.SetBackgroundDrawableResource(Resource.Color.mtrl_btn_transparent_bg_color);
                mProgressDialog.SetContentView(view);
                mProgressDialog.SetCancelable(false);
                mProgressDialog.Show();
            }
            else
            {
                mProgressDialog.Dismiss();
            }
            //https://github.com/redth-org/AndHUD
        }
    }
}
//            btnSignin.Click += (s, a) =>
//            {
//                try
//                {
//                    if (ProManager.IsExist(umail.Text, upass.Text))
//                    {
//                        //update shared prefrences
//                        if(staySignedInFlag)
//                            new SharedPrefrencesHelper(this).PutUserEmail(umail.Text);
//                        // Save user details
//                        ProManager.SetCurrentUser(umail.Text);
//                        StartActivity(typeof(MainPageActivity));
//                    }
//                    else
//                    {
//                        Toast.MakeText(this, "User details are incorrect!", ToastLength.Short).Show();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Toast.MakeText(this, "Error: User incorrect details!\n" + ex.Message, ToastLength.Short).Show();
//                }
//            };

//            ckStayIn = FindViewById<CheckBox>(Resource.Id.stayInFlag);
//            ckStayIn.Click += (s, a) =>
//            {
//                staySignedInFlag = !staySignedInFlag;
//            };