using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDetection.Lib
{
    public class CardDetectionHandler
    {
        private struct NamedBitmap
        {
            public Bitmap bitmap;
            public string name;
        }

        private static List<NamedBitmap> cardPics = new List<NamedBitmap>();
        private static List<NamedBitmap> tablePics = new List<NamedBitmap>();

        public static void Initialize(string bitmapsPath)
        {
            //Set Path of the Bitmap folder
            //string bitmapsPath = String.Format("{0}", System.Configuration.ConfigurationManager.AppSettings["ReportFolderPath"]); ;   //Application.StartupPath + "\\Bitmaps\\";

            //Load the Bitmaps into carPics, and tablePics Lists
            foreach (string s in Directory.GetFiles(bitmapsPath))
            {
                if (s.ToUpper().EndsWith(".BMP"))
                {
                    string[] splitter = s.Split('\\');
                    string fileName = splitter[splitter.Length - 1];

                    string[] splitter2 = fileName.Split('.');

                    //if filename Length is 2 or 3.
                    if (splitter2[0].Length == 2 || splitter2[0].Length == 3)
                    {
                        //File name was 2 or 3 chars long, its a card bitmap
                        NamedBitmap b = new NamedBitmap();
                        b.name = splitter2[0];
                        b.bitmap = new Bitmap(s);
                        cardPics.Add(b);
                    }
                    else
                    {
                        //File name was not 2 chars long, its a table bitmap
                        NamedBitmap b = new NamedBitmap();
                        b.name = splitter2[0];
                        b.bitmap = new Bitmap(s);
                        tablePics.Add(b);
                    }
                }
            }
        }

        private static Bitmap RetrieveBitmap(string name)
        {
            //Check cardPics List
            foreach (NamedBitmap nb in cardPics)
            {
                if (nb.name.ToUpper() == name.ToUpper())
                {
                    return nb.bitmap;
                }
            }

            //Check tablePics List
            foreach (NamedBitmap nb in tablePics)
            {
                if (nb.name.ToUpper() == name.ToUpper())
                {
                    return nb.bitmap;
                }
            }

            return null;
        }

        // Converts a string "S", "C", "H", or "D" into the coresponding Suit Enum
        private static Card.Suit ConvertStringToSuit(string stringSuit)
        {
            Card.Suit cardSuit;

            //Figure out which suit the found card was
            switch (stringSuit)
            {
                case "S":
                    cardSuit = Card.Suit.Spades;
                    break;
                case "C":
                    cardSuit = Card.Suit.Clubs;
                    break;
                case "H":
                    cardSuit = Card.Suit.Hearts;
                    break;
                case "D":
                    cardSuit = Card.Suit.Diamonds;
                    break;
                default:
                    cardSuit = Card.Suit.NotFound;
                    break;
            }

            return cardSuit;
        }


        // Converts a string "2", "3", "4"... "J", "Q", "K", or "A"  into the coresponding Rank Enum
        private static Card.Rank ConvertStringToRank(string stringRank)
        {
            Card.Rank cardRank;

            //Figure out which rank the found card was
            switch (stringRank)
            {
                case "2":
                    cardRank = Card.Rank.Two;
                    break;
                case "3":
                    cardRank = Card.Rank.Three;
                    break;
                case "4":
                    cardRank = Card.Rank.Four;
                    break;
                case "5":
                    cardRank = Card.Rank.Five;
                    break;
                case "6":
                    cardRank = Card.Rank.Six;
                    break;
                case "7":
                    cardRank = Card.Rank.Seven;
                    break;
                case "8":
                    cardRank = Card.Rank.Eight;
                    break;
                case "9":
                    cardRank = Card.Rank.Nine;
                    break;
                case "10":
                    cardRank = Card.Rank.Ten;
                    break;
                case "J":
                    cardRank = Card.Rank.Jack;
                    break;
                case "Q":
                    cardRank = Card.Rank.Queen;
                    break;
                case "K":
                    cardRank = Card.Rank.King;
                    break;
                case "A":
                    cardRank = Card.Rank.Ace;
                    break;
                default:
                    cardRank = Card.Rank.NotFound;
                    break;
            }

            return cardRank;
        }

        public static Bitmap CaptureYourHandImage()
        {
            return BitmapHandler.CopyPartialBitmap(ApplicationCaptureHandler.CaptureApplication("PokerStars"), new Rectangle(352, 365, 90, 53));
        }

        public static Bitmap CaptureCommunityCardsImage()
        {
            return BitmapHandler.CopyPartialBitmap(ApplicationCaptureHandler.CaptureApplication("PokerStars"), new Rectangle(262, 204, 282, 74));
        }

        public static Card[] RetrieveYourHand()
        {
            Bitmap currentHand = CaptureYourHandImage();

            //First check to see if there are no cards in your hand to avoid unnessicary searching.
            if (BitmapHandler.SearchBitmap(currentHand, RetrieveBitmap("NoHand")))
            {
                return null;
            }
            else
            {
                int foundCount = 0;
                int cardsToSearch = 2;
                Card[] hand = new Card[2];

                foreach (NamedBitmap cardImage in cardPics)
                {
                    if (BitmapHandler.SearchBitmap(currentHand, cardImage.bitmap))
                    {
                        //Split the Bitmap filenames up into two seperate strings. EX) filename == S7, then stringSuit = "S", and stringRank = "7"
                        string stringSuit = cardImage.name.Substring(0, 1);
                        string stringRank = cardImage.name.Substring(1);

                        //Get the Bitmap filenames into Suit and Rank Enums. EX) filename == S7, then cardSuit = Suit.Spades, and cardRank = Rank.Seven
                        Card.Suit cardSuit = ConvertStringToSuit(stringSuit);
                        Card.Rank cardRank = ConvertStringToRank(stringRank);

                        hand[foundCount] = new Card(cardSuit, cardRank);
                        foundCount++;

                        //If you found all the cards, stop searching
                        if (foundCount == cardsToSearch)
                        {
                            break;
                        }
                    }
                }
                return hand;
            }
        }

        public static Card[] RetrieveCommunityCards()
        {
            Bitmap currentCommunityCards = CaptureCommunityCardsImage();

            int foundCount = 0;
            int cardsToSearch;
            Card[] hand;

            //Check to see how many cards you need to find, if no cards are on the table return null.
            if (BitmapHandler.SearchBitmap(currentCommunityCards, RetrieveBitmap("3cards")))
            {
                cardsToSearch = 3;
                hand = new Card[3];
            }
            else if (BitmapHandler.SearchBitmap(currentCommunityCards, RetrieveBitmap("4cards")))
            {
                cardsToSearch = 4;
                hand = new Card[4];
            }
            else if (BitmapHandler.SearchBitmap(currentCommunityCards, RetrieveBitmap("5cards")))
            {
                cardsToSearch = 5;
                hand = new Card[5];
            }
            else
            {
                return null;
            }

            foreach (NamedBitmap cardImage in cardPics)
            {
                if (BitmapHandler.SearchBitmap(currentCommunityCards, cardImage.bitmap))
                {
                    //Split the Bitmap filenames up into two seperate strings. EX) filename == S7, then stringSuit = "S", and stringRank = "7"
                    string stringSuit = cardImage.name.Substring(0, 1);
                    string stringRank = cardImage.name.Substring(1);

                    //Get the Bitmap filenames into Suit and Rank Enums. EX) filename == S7, then cardSuit = Suit.Spades, and cardRank = Rank.Seven
                    Card.Suit cardSuit = ConvertStringToSuit(stringSuit);
                    Card.Rank cardRank = ConvertStringToRank(stringRank);

                    hand[foundCount] = new Card(cardSuit, cardRank);
                    foundCount++;

                    //If you found all the cards, stop searching
                    if (foundCount == cardsToSearch)
                    {
                        break;
                    }
                }
            }
            return hand;
        }
    }
}
