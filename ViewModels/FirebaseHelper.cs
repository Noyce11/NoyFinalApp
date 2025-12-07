using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore.Auth;
using Firebase;

namespace NoyFinalApp.ViewModels
{
    public static class FireBaseHelper
    {
        private static TaskCompletionListeners taskCompletionListeners;
        public static FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                .SetProjectId("orfinal-2d77b")
                .SetApplicationId("orfinal-2d77b")
                .SetApiKey("AIzaSyAykQRB71ydCRMREDPYJKgK3fAUiunGV0o")
                .SetDatabaseUrl("orfinal-2d77b.firebaseapp.com")
                .SetStorageBucket("orfinal-2d77b.firebasestorage.app")
                .Build();
                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }
            return mAuth;
        }
        public static void RegisterUserForAuth(User user)
        {
            //Insert User to Firebase Authentication List with email amd password
            FirebaseAuth mAuth = GetFirebaseAuth();
            taskCompletionListeners = new TaskCompletionListeners();
            mAuth.CreateUserWithEmailAndPassword(user.UserEmail, user.UserPass)
            .AddOnSuccessListener(taskCompletionListeners)
            .AddOnFailureListener(taskCompletionListeners);

        }
    }

    public class TaskCompletionListeners : Java.Lang.Object, IOnSuccessListener, IOnFailureListener
    {
        public event EventHandler<TaskSuccessEventArgs> Success;
        public event EventHandler<TaskCompletionFailureEventArgs> Failure;
        //Success
        public class TaskCompletionFailureEventArgs : EventArgs
        {
            public string Cause { get; set; }
        }
        //Failure
        public class TaskSuccessEventArgs : EventArgs
        {
            public Java.Lang.Object Result { get; set; }
        }
        public void OnFailure(Java.Lang.Exception e)
        {
            Failure?.Invoke(this, new TaskCompletionFailureEventArgs { Cause = e.Message });
        }
        public void OnSuccess(Java.Lang.Object result)
        {
            Success?.Invoke(this, new TaskSuccessEventArgs { Result = result });
        }
    }
}