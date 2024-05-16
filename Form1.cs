using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace LumberjackGame
{
    public partial class Form1 : Form
    {
        private PictureBox playerBox;
        private PictureBox TrunkBox;
        private PictureBox branch1;
        private PictureBox branch2;
        private PictureBox branch3;
        private Timer gameTimer;
        private int score = 0;
        private Random random = new Random();
        private Stopwatch stopwatch = new Stopwatch();

        private string playerLeftImagePath = ".\\hit.png";
        private string playerRightImagePath = ".\\hitflip.png";
        private string playerNormal = ".\\normal.png";
        private string branchImagePath = ".\\branch.png";
        private string branchFlipImagePath = ".\\branchflip.png";
        private string trunkImagePath = ".\\trunk.png";

        private Label scoreLabel;
        private Label GameName;







        //SET TIME LIMIT HERE
        private int max_time = 10;




        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.Text = "Lumberjack Game";
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


            stopwatch.Start();

            GameName = new Label();
            GameName.ForeColor = Color.Black;
            GameName.Size = new Size(190, 20);
            GameName.Font = new Font(GameName.Font.FontFamily, 14);
            GameName.Location = new Point(400, 10);
            GameName.Text = "Lumberjack in C#";
            this.Controls.Add(GameName);

            scoreLabel = new Label();
            scoreLabel.ForeColor = Color.Black;
            scoreLabel.Font = new Font(scoreLabel.Font.FontFamily, 14);
            scoreLabel.Location = new Point(10, 10);
            this.Controls.Add(scoreLabel);


            TrunkBox = new PictureBox();
            TrunkBox.Size = new Size(100, 600);
            TrunkBox.Location = new Point(250, 0);
            TrunkBox.Image = Image.FromFile(trunkImagePath);
            TrunkBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(TrunkBox);

            playerBox = new PictureBox();
            playerBox.Size = new Size(160, 160);
            playerBox.Location = new Point(80, 370); 
            playerBox.Image = Image.FromFile(playerNormal);
            playerBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(playerBox);




            branch1 = new PictureBox();
            branch1.Size = new Size(210, 90);
            branch1.Image = Image.FromFile(branchImagePath);
            branch1.SizeMode = PictureBoxSizeMode.StretchImage;
            branch1.Location = new Point(70, 50);
            this.Controls.Add(branch1);

            branch2 = new PictureBox();
            branch2.Size = new Size(210, 90);
            branch2.Image = Image.FromFile(branchImagePath);
            branch2.SizeMode = PictureBoxSizeMode.StretchImage;
            branch2.Location = new Point(70, 250);
            this.Controls.Add(branch2);

            branch3 = new PictureBox();
            branch3.Size = new Size(210, 90);
            branch3.Image = Image.FromFile(branchFlipImagePath);
            branch3.SizeMode = PictureBoxSizeMode.StretchImage;
            branch3.Location = new Point(330, 450);
            this.Controls.Add(branch3);







            gameTimer = new Timer();
            gameTimer.Interval = 100; 
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (branch1.Bounds.IntersectsWith(playerBox.Bounds) || branch2.Bounds.IntersectsWith(playerBox.Bounds) || branch3.Bounds.IntersectsWith(playerBox.Bounds))
            {
                gameTimer.Stop();
                MessageBox.Show($"Game Over! Your score: {score-1}");
                this.Close();
            }


            if (stopwatch.Elapsed.Seconds >= max_time)
            {
                gameTimer.Stop();
                MessageBox.Show($"Time Up! Your score: {score-1}");
                this.Close();
            }

            scoreLabel.Text = "Score: " + score.ToString();


        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.A)
            {
                MovePlayerLeft();
                BranchMove();
                score++;

            }
            else if (e.KeyCode == Keys.D)
            {
                MovePlayerRight();
                BranchMove();
                score++;
            }
        }

        private void MovePlayerLeft()
        {
            if (playerBox.Left > 0)
            {
                playerBox.Left = 90; 
                playerBox.Image = Image.FromFile(playerLeftImagePath); 
                
            }
        }


        private void MovePlayerRight()
        {
            if (playerBox.Right < this.ClientSize.Width)
            {
                playerBox.Left = 350; 
                playerBox.Image = Image.FromFile(playerRightImagePath); 
            }
        }


        private void BranchMove()
        {
            if (branch1.Top == 550)
            {
                if (random.Next(10) % 2 == 0)
                {
                    branch1.Image = Image.FromFile(branchImagePath);
                    branch1.Location = new Point(70, 50);
                }

                else
                {
                    branch1.Image = Image.FromFile(branchFlipImagePath);
                    branch1.Location = new Point(330, 50);
                }
            }
            else
            {
                branch1.Top += 100;
            }

            if (branch2.Top == 550)
            {
                if (random.Next(10) % 2 == 0)
                {
                    branch2.Image = Image.FromFile(branchImagePath);
                    branch2.Location = new Point(70, 50);
                }

                else
                {
                    branch2.Image = Image.FromFile(branchFlipImagePath);
                    branch2.Location = new Point(330, 50);
                }
            }
            else
            {
                branch2.Top += 100;
            }

            if (branch3.Top == 550)
            {
                if (random.Next(10) % 2 == 0)
                {
                    branch3.Image = Image.FromFile(branchImagePath);
                    branch3.Location = new Point(70, 50);
                }

                else
                {
                    branch3.Image = Image.FromFile(branchFlipImagePath);
                    branch3.Location = new Point(330, 50);
                }
            }
            else
            {
                branch3.Top += 100;
            }



        }

    }
}
