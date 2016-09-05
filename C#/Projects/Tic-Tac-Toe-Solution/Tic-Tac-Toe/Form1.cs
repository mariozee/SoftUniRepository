using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        GFX engine;
        Board theBoard;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics toPass = panel1.CreateGraphics();
            this.engine = new GFX(toPass);

            this.theBoard = new Board();
            this.theBoard.InitBoard();

            this.RefreshLabel();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point mouse = Cursor.Position;
            mouse = panel1.PointToClient(mouse);
            this.theBoard.DetectHit(mouse);

            this.RefreshLabel();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Tic-Tac-Toe Game").AppendLine();
            sb.AppendLine("**Fluffy colours edtion**");
            MessageBox.Show(sb.ToString());
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            this.theBoard.Restart();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RefreshLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("It is ");
            if (this.theBoard.GetPlayerForTuen() == Board.X)
            {
                sb.Append("X");
            }
            else
            {
                sb.Append("O");
            }

            sb.AppendLine("'s Turn ")
                .AppendLine($"X has won {this.theBoard.GetXwins()} times.")
                .AppendLine($"O has won {this.theBoard.GetOwins()} times.");

            label1.Text = sb.ToString();
        }        
    }
}
