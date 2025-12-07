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

namespace NoyFinalApp
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {

        //private ImageButton ibDelete;
        //private Button btnSignup;
        //private EditText fname, lname, uemail, upass, umobile;
        ////private User user;
        //private int position;

        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    SetContentView(Resource.Layout.signup_layout);
        //    // Create your application here

        //    InitilizaViews();
        //}

        //private void InitilizaViews()
        //{
        //    ibDelete = FindViewById<ImageButton>(Resource.Id.ibDelete);
        //    btnSignup = FindViewById<Button>(Resource.Id.btn_register);
        //    fname = FindViewById<EditText>(Resource.Id.et_first_name);
        //    lname = FindViewById<EditText>(Resource.Id.et_last_name);
        //    uemail = FindViewById<EditText>(Resource.Id.et_email);
        //    upass = FindViewById<EditText>(Resource.Id.et_password);
        //    umobile = FindViewById<EditText>(Resource.Id.et_mobile);

        //    btnSignup.Click += BtnSignup_Click;
        //    position = Intent.GetIntExtra("position", -1); // -1 is default
        //    if (position != -1) // Arrived from ListView
        //    {
        //        btnSignup.Text = "Update";
        //        btnSignup.SetBackgroundColor(new Color(171, 52, 235));

        //        if (position != -2)
        //        {
        //            ibDelete.Visibility = ViewStates.Visible;
        //            ibDelete.Click += (s, e) =>
        //            {
        //                ProManager.RemoveUser(position);

        //                Finish();
        //            };
        //        }




        //        FillUserDetails();
        //    }

        //}

        //private void FillUserDetails()
        //{
        //    User user = 
        //        position == -2 ?
        //        ProManager.CurrentUser : ProManager.users[position];

        //    fname.Text = user.FName;
        //    lname.Text = user.LName;
        //    uemail.Text = user.UEmail;
        //    upass.Text = user.UPass;
        //    umobile.Text = user.UMobile;
        //}

        //private void BtnSignup_Click(object sender, EventArgs e)
        //{
        //    if (Validate())
        //    {
        //        user = new User()
        //        {
        //            FName = fname.Text,
        //            LName = lname.Text,
        //            UEmail = uemail.Text,
        //            UPass = upass.Text,
        //            UMobile = umobile.Text
        //        };

        //        if(position != -1)
        //        {
        //            ProManager.UpdateUser(user, position);
        //            Finish();
        //        }
        //        else //Add new user
        //        {
        //            try
        //            {
        //                user.RegDate = DateTime.Now;
        //                ProManager.AddUser(user);
        //                Toast.MakeText(this, "Register User", ToastLength.Short).Show();
        //                StartActivity(typeof(MainPageActivity));
        //            }
        //            catch (FormatException fx)
        //            {
        //                Toast.MakeText(this, fx.Message, ToastLength.Short).Show();
        //            }
        //            catch (System.Exception ex)
        //            {
        //                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
        //            }
        //        }
        //    }
        //}

        //private bool Validate()
        //{
        //    //if (fname.Text.Length <= 0 || fname.Text.Length > 20 ||
        //    //    lname.Text.Length <= 0 || lname.Text.Length > 20 ||
        //    //    upass.Text.Length < 8 ||
        //    //    umobile.Text.Length != 10 ||
        //    //    uemail.Text.Length <= 0)
        //    //    return false;
        //    //else return true;
        //    return true;
    }

}