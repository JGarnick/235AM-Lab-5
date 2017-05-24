using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

using Android.Content.PM;

namespace Lab5BigPig
{
    [Activity(Label = "Lab5BigPig", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {

        Button playButton;
        EditText introPlayer1Name;
        EditText introPlayer2Name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            playButton = FindViewById<Button>(Resource.Id.playBtn);
            introPlayer1Name = FindViewById<EditText>(Resource.Id.enterP1Name);
            introPlayer2Name = FindViewById<EditText>(Resource.Id.enterP2Name);

            playButton.Click += delegate
            {
                var game = new Intent(this, typeof(GameActivity));
                game.PutExtra("StartNewGame", true);
                game.PutExtra("P1NameEntered", introPlayer1Name.Text);
                game.PutExtra("P2NameEntered", introPlayer2Name.Text);
                StartActivity(game);
            };
        }
            

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            
        }
    }
}

