using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDetection.Lib;
using System.Configuration;

namespace PokerStarsBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TestHandCards();
        }

        static void TestHandCards()
        {
            string bitmapsPath = String.Format("{0}", ConfigurationSettings.AppSettings["BitmapsFolderLocation"]);
            CardDetectionHandler.Initialize(bitmapsPath);

            Card[] hand = CardDetectionHandler.RetrieveYourHand();
            Card[] comm = CardDetectionHandler.RetrieveCommunityCards();

            Console.WriteLine("Cards in your hand : ");
            foreach (Card card in hand)
            {
                if (card != null)
                {
                    Console.WriteLine(card.CardRank + " of " + card.CardSuit);
                }
            }

            Console.WriteLine("\nCards in Community : ");
            if (comm != null)
            {
                foreach (Card card in comm)
                {
                    if (card != null)
                    {
                        Console.WriteLine(card.CardRank + " of " + card.CardSuit);
                    }
                }
            }

            Console.ReadLine();
        }

        /*
        void TestSearchBitmap()
        {
            //Define Bitmap Images from filepaths
            Bitmap PokerTable = new Bitmap(Application.StartupPath + "//PokerTable.bmp");
            Bitmap S7 = new Bitmap(Application.StartupPath + "//S7.bmp");
            Bitmap C7 = new Bitmap(Application.StartupPath + "//C7.bmp");

            //Check for Seven of Spades on the table
            if (SearchBitmap(PokerTable, S7))
            {
                Console.WriteLine("Seven of Spades was found on the table.");
            }
            else
            {
                Console.WriteLine("Seven of Spades was not found on the table.");
            }

            //Check for Seven of Clubs on the table
            if (SearchBitmap(PokerTable, C7))
            {
                Console.WriteLine("Seven of Clubs was found on the table.");
            }
            else
            {
                Console.WriteLine("Seven of Clubs was not found on the table.");
            }
        }
         */
    }
}
