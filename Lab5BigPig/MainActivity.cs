using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Text;
using static Lab5BigPig.Resource;
using Android.Content.Res;

namespace Lab5BigPig
{
    [Activity(Label = "Lab5BigPig", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public class Player
        {
            public bool IsTurn { get; set; }
            public int Score { get; set; }
            public string Name { get; set; }
            public bool ScoreLimitReached { get; set; }

            public Player()
            {
                IsTurn = false;
                Score = 0;
                ScoreLimitReached = false;
            }
        }

        public void SetNames(EditText t1, EditText t2, Player p1, Player p2)
        {
            p1Name = t1.Text;
            p2Name = t2.Text;

            player1.Name = p1Name;
            player2.Name = p2Name;
        }

        public void SetWhoseTurnText(Player p1, Player p2, TextView tv)
        {
            if (p1.IsTurn)
                tv.Text = p1.Name;
            else
                tv.Text = p2.Name;

            tv.Text += "'s Turn";
        }
        public void SetValues()
        {
            p1ScoreTotal.Text = p1Score;
            p2ScoreTotal.Text = p2Score;
            
            pointsTextView.Text = turnPoints;
            whoseTurn.Text = whoseTurnText;
            player1EditText.Text = p1Name;
            player2EditText.Text = p2Name;
            points = int.Parse(turnPoints);
        }

        public void NewGameValues()
        {
            p1Score = "0";
            p2Score = "0";
            
            dieImage.SetImageResource(Resource.Drawable.Die8Side1);
            turnPoints = "0";
            whoseTurnText = "Enter your names and start a game!";
            rollDieButton.Enabled = false;
            endTurnButton.Enabled = false;
            points = 0;
        }

        public void SetDieImage(int dieImageNum)
        {
            switch(dieImageNum)
            {
                case 1:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side1);
                    break;
                case 2:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side2);
                    break;
                case 3:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side3);
                    break;
                case 4:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side4);
                    break;
                case 5:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side5);
                    break;
                case 6:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side6);
                    break;
                case 7:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side7);
                    break;
                case 8:
                    dieImage.SetImageResource(Resource.Drawable.Die8Side8);
                    break;
                default:
                    break;
            }
        }

        string p1Score, p2Score, turnPoints, whoseTurnText, p1Name, p2Name;
        int dieImageNum = 0;
        int points = 0;

        TextView p1ScoreTotal;
        TextView p2ScoreTotal;
        TextView whoseTurn;
        TextView p1ScoreTV;
        TextView p2ScoreTV;
        Button newGameButton;
        Button rollDieButton;
        Button endTurnButton;
        TextView player1TextView;
        TextView player2TextView;
        ImageView dieImage;
        TextView pointsTextView;
        EditText player1EditText;
        EditText player2EditText;
        GameLogic game;

        Player player1 = new Player();
        Player player2 = new Player();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            p1ScoreTotal = FindViewById<TextView>(Resource.Id.p1ScoreTotal);
            p2ScoreTotal = FindViewById<TextView>(Resource.Id.p2ScoreTotal);
            whoseTurn = FindViewById<TextView>(Resource.Id.textView1);
            p1ScoreTV = FindViewById<TextView>(Resource.Id.p1ScoreTV);
            p2ScoreTV = FindViewById<TextView>(Resource.Id.p2ScoreTV);
            newGameButton = FindViewById<Button>(Resource.Id.newGameBtn);
            rollDieButton = FindViewById<Button>(Resource.Id.rollDieBtn);
            endTurnButton = FindViewById<Button>(Resource.Id.endTurnBtn);
            player1TextView = FindViewById<TextView>(Resource.Id.player1);
            player2TextView = FindViewById<TextView>(Resource.Id.player2);
            dieImage = FindViewById<ImageView>(Resource.Id.dieImage);
            pointsTextView = FindViewById<TextView>(Resource.Id.numPointsTV);
            player1EditText = FindViewById<EditText>(Resource.Id.p1EditText);
            player2EditText = FindViewById<EditText>(Resource.Id.p2EditText);
            game = new GameLogic();
            


            if (bundle == null)
            {
                NewGameValues();
                SetValues();
            }
            else
            {
                SetDieImage(bundle.GetInt("DieImageNum", 1));
                p1Score = bundle.GetString("P1Score", "0");
                p2Score = bundle.GetString("P2Score", "0");
                whoseTurnText = bundle.GetString("WhoseTurnName", "");
                turnPoints = bundle.GetString("TurnPoints", "0");
                rollDieButton.Enabled = bundle.GetBoolean("RollDiceEnabled", false);
                p1Name = bundle.GetString("p1Name", "");
                p2Name = bundle.GetString("p2Name", "");

                //Restore Player 1
                player1.Name = p1Name;
                player1.ScoreLimitReached = bundle.GetBoolean("p1ScoreLimit", false);
                player1.IsTurn = bundle.GetBoolean("p1IsTurn", false);
                player1.Score = int.Parse(p1Score);

                //Restore player 2
                player2.Name = p2Name;
                player2.ScoreLimitReached = bundle.GetBoolean("p2ScoreLimit", false);
                player2.IsTurn = bundle.GetBoolean("p2IsTurn", false);
                player2.Score = int.Parse(p2Score);
                

                SetValues();
            }

            rollDieButton.Click += delegate { //Set the picture and add point value to total
                switch (game.RollDice())
                {
                    case 1:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side1);
                        points += 1;
                        dieImageNum = 1;
                        break;
                    case 2:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side2);
                        points += 2;
                        dieImageNum = 2;
                        break;
                    case 3:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side3);
                        points += 3;
                        dieImageNum = 3;
                        break;
                    case 4:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side4);
                        points += 4;
                        dieImageNum = 4;
                        break;
                    case 5:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side5);
                        points += 5;
                        dieImageNum = 5;
                        break;
                    case 6:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side6);
                        points += 6;
                        dieImageNum = 6;
                        break;
                    case 7:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side7);
                        points += 7;
                        dieImageNum = 7;
                        break;
                    case 8:
                        dieImage.SetImageResource(Resource.Drawable.Die8Side8);
                        points = 0;
                        rollDieButton.Enabled = false;
                        dieImageNum = 8;
                        break;
                    default:
                        break;
                }
                pointsTextView.Text = points.ToString();
            }; 

            newGameButton.Click += delegate
            {
                NewGameValues();
                game.NewGame(player1, player2); //Setting IsTurn property to determine a random turn

                SetNames(player1EditText, player2EditText, player1, player2);
                SetWhoseTurnText(player1, player2, whoseTurn);


                rollDieButton.Enabled = true;
                endTurnButton.Enabled = true;

            };

            endTurnButton.Click += delegate
            {
                if(player1.IsTurn)
                {
                    game.AddPoints(points, player1);
                    p1Score = player1.Score.ToString();
                    p1ScoreTotal.Text = player1.Score.ToString();
                    if (player1.Score >= 100)
                        player1.ScoreLimitReached = true;
                }
                else
                {
                    game.AddPoints(points, player2);
                    p2Score = player2.Score.ToString();
                    p2ScoreTotal.Text = player2.Score.ToString();
                    if (player2.Score >= 100)
                        player2.ScoreLimitReached = true;
                }
                points = 0;
                pointsTextView.Text = points.ToString();
                
                var winner = game.EndTurn(player1, player2);
                if(winner != null)
                {
                    rollDieButton.Enabled = false;
                    endTurnButton.Enabled = false;
                    whoseTurn.Text = winner.Name + " Wins!";
                    return;
                }
                SetWhoseTurnText(player1, player2, whoseTurn);
                if (!rollDieButton.Enabled)     //Re enable the button
                    rollDieButton.Enabled = true;

                
            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            outState.PutString("P1Score", p1Score);
            outState.PutString("P2Score", p2Score);

            //TODO Save current player's turn and set it
            if(player1.IsTurn)
            {
                outState.PutInt("WhoseTurnLogic", 0);
                outState.PutString("WhoseTurnName", player1.Name);
            }
            else
            {
                outState.PutInt("WhoseTurnLogic", 1);
                outState.PutString("WhoseTurnName", player2.Name);
            }

            outState.PutInt("DieImageNum", dieImageNum);
            outState.PutString("TurnPoints", turnPoints);

            outState.PutString("p1Name", player1EditText.Text);
            outState.PutString("p2Name", player2EditText.Text);
            outState.PutBoolean("RollDiceEnabled", rollDieButton.Enabled);

            //Store players
            outState.PutBoolean("p1IsTurn", player1.IsTurn);
            outState.PutBoolean("p2IsTurn", player2.IsTurn);
            outState.PutInt("p1Score", player1.Score);
            outState.PutInt("p2Score", player2.Score);
            outState.PutBoolean("p1ScoreLimit", player1.ScoreLimitReached);
            outState.PutBoolean("p2ScoreLimit", player2.ScoreLimitReached);

        }
    }
}

