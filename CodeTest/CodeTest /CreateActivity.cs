
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Person = CodeTest.Model.Person;
using Android.Widget;
using CodeTest.Helper;
using System.Text.RegularExpressions;

namespace CodeTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class CreateActivity : Activity
    {
        List<Person> listSource = new List<Person>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateUser);
            db = new Database();
            db.createDatabase();
            // Create your application here
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            
            btnAdd.Click += delegate
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum5Chars = new Regex(@".{5,}");
                var isValidated = hasNumber.IsMatch(edtPassword.Text) && hasUpperChar.IsMatch(edtPassword.Text) && hasMinimum5Chars.IsMatch(edtPassword.Text);
                if (edtName.Text != null && edtName.Text !="")
                {
                    if (edtEmail.Text != null && edtEmail.Text != "")
                    {
                        if (isValidated)
                        {
                            if (checkPattern(edtPassword.Text, "aaa"))
                            { 
                                if (edtPassword.Text.Length > 5 && edtPassword.Text.Length < 12)

                                {
                                    Person person = new Person()
                                    {
                                        Name = edtName.Text,
                                        Email = edtEmail.Text,
                                        Password = edtPassword.Text
                                    };
                                    db.insertIntoTable(person);
                                    //LoadData();
                                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                                    Android.App.AlertDialog alert = dialog.Create();
                                    alert.SetTitle("Success");
                                    alert.SetMessage("Create User Successfully");
                                    alert.SetButton("OK", (c, ev) =>
                                    {
                                        var intent = new Intent(this, typeof(ListActivity));
                                        StartActivity(intent);
                                    });
                                    alert.Show();
                                    edtPassword.Text = string.Empty;
                                    edtName.Text = string.Empty;
                                    edtEmail.Text = string.Empty;
                                }
                                else
                                {
                                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                                    Android.App.AlertDialog alert = dialog.Create();
                                    alert.SetTitle("Validation");
                                    alert.SetMessage("Please Enter Valid Password");
                                    alert.SetButton("OK", (c, ev) =>
                                    {

                                    });
                                    alert.Show();
                                }
                        }
                            else
                            {
                                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                                Android.App.AlertDialog alert = dialog.Create();
                                alert.SetTitle("Validation");
                                alert.SetMessage("Please Enter Valid Password");
                                alert.SetButton("OK", (c, ev) =>
                                {

                                });
                                alert.Show();
                            }

                        }
                        else
                        {
                            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                            Android.App.AlertDialog alert = dialog.Create();
                            alert.SetTitle("Validation");
                            alert.SetMessage("Please Enter Valid Password");
                            alert.SetButton("OK", (c, ev) =>
                            {

                            });
                            alert.Show();
                        }

                    }
                    else
                    {
                        Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alert = dialog.Create();
                        alert.SetTitle("Validation");
                        alert.SetMessage("Please Enter Email");
                        alert.SetButton("OK", (c, ev) =>
                        {

                        });
                        alert.Show();
                    }
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Validation");
                    alert.SetMessage("Please Enter User Name");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        
                    });
                    alert.Show();
                }
            };
            static Boolean checkPattern(String str, String pattern)
            {
                // len stores length of the given pattern  
                int len = pattern.Length;

                // if length of pattern is more than length of  
                // input string, return false; 
                if (str.Length < len)
                {
                    return false;
                }

                for (int i = 0; i < len - 1; i++)
                {
                    // x, y are two adjacent characters in pattern 
                    char x = pattern[i];
                    char y = pattern[i + 1];

                    // find index of last occurrence of character x 
                    // in the input string 
                    int last = str.LastIndexOf(x);

                    // find index of first occurrence of character y 
                    // in the input string 
                    int first = str.IndexOf(y);

                    // return false if x or y are not present in the  
                    // input string OR last occurrence of x is after  
                    // the first occurrence of y in the input string 
                    if (last == -1 || first
                            == -1 || last > first)
                    {
                        return false;
                    }
                }

                // return true if string matches the pattern 
                return true;
            }
        }
    }
}
