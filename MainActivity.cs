using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace atelierXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText usernameEditText;
        EditText passwordEditText;
        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get references to UI elements
            usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            // Attach click event handler to the login button
            loginButton.Click += LoginButton_Click;
        }
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            // Get the entered username and password
            string username = usernameEditText.Text;
            string password = passwordEditText.Text;

            // Check if the entered username and password match the hardcoded values
            if (username == "admin" && password == "admin")
            {
                // For demonstration purposes, display a toast message indicating successful login
                Toast.MakeText(this, "Login Successful!", ToastLength.Short).Show();

                // Start Activity1
                StartActivity(typeof(Activity2));
            }
            else
            {
                // Display an error message if the entered username or password is incorrect
                Toast.MakeText(this, "Incorrect username or password!", ToastLength.Short).Show();
            }
        }


    }
}