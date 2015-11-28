using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardDetection.Lib;
using System.Configuration;

namespace PokerBotTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string bitmapsPath = String.Format("{0}", ConfigurationSettings.AppSettings["BitmapsFolderLocation"]);
            CardDetectionHandler.Initialize(bitmapsPath);

        }

        private void btnScreenCapture_Click(object sender, EventArgs e)
        {
            Bitmap PokerStarsWindow = ApplicationCaptureHandler.CaptureApplication("PokerStars");
            pictureBoxScreen.Width = PokerStarsWindow.Width;
            pictureBoxScreen.Height = PokerStarsWindow.Height;
            pictureBoxScreen.BackgroundImage = PokerStarsWindow;
        }

        private void btnHandCardCapture_Click(object sender, EventArgs e)
        {
            Bitmap PokerStarsWindow = CardDetectionHandler.CaptureYourHandImage();
            pictureBoxScreen.Width = PokerStarsWindow.Width;
            pictureBoxScreen.Height = PokerStarsWindow.Height;
            pictureBoxScreen.BackgroundImage = PokerStarsWindow;
        }

        private void btnCommunityCardCapture_Click(object sender, EventArgs e)
        {
            Bitmap PokerStarsWindow = CardDetectionHandler.CaptureCommunityCardsImage();
            pictureBoxScreen.Width = PokerStarsWindow.Width;
            pictureBoxScreen.Height = PokerStarsWindow.Height;
            pictureBoxScreen.BackgroundImage = PokerStarsWindow;
        }

        private void btnHandCards_Click(object sender, EventArgs e)
        {
            Card[] hand = CardDetectionHandler.RetrieveYourHand();

            string msg = "";
            foreach (Card card in hand)
            {
                if (card != null)
                {
                    msg += card.CardRank + " of " + card.CardSuit + "\n";
                }
            }

            if (msg == "")
            {
                MessageBox.Show("No cards in hand.", "Cards in Hand");
            }
            else {
                MessageBox.Show(msg, "Cards in Hand");
            }
        }

        private void btnCommCards_Click(object sender, EventArgs e)
        {
            Card[] comm = CardDetectionHandler.RetrieveCommunityCards();

            string msg = "";
            if (comm != null)
            {
                foreach (Card card in comm)
                {
                    if (card != null)
                    {
                        msg += card.CardRank + " of " + card.CardSuit + "\n";
                    }
                }
            }

            if (msg == "")
            {
                MessageBox.Show("No cards in Community.", "Cards in Community");
            }
            else
            {
                MessageBox.Show(msg, "Cards in Community");
            }
        }
    }
}
