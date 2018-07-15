using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;


namespace Game
{
    public class Bonuses
    {
        SpriteBatch spriteBatch;
        GameObject[,] bonus;

        Random rand = new Random();

        int[,] bonusBoard;
        int h, w;
        int bonusCount = 0;

        public Bonuses(SpriteBatch spriteBatch, int boardHeight, int boardWidth)
        {
            this.spriteBatch = spriteBatch;
            h = boardHeight;
            w = boardWidth;
        }

        public GameObject[,] Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public int BonusCount
        {
            get { return  bonusCount; }
            set { bonusCount = value; }
        }

        public int[,] BonusBoard
        {
            get { return bonusBoard; }
            set { bonusBoard = value; }
        }

        public void load(ContentManager content, int [,] gameBoard)
        {
            bonus = new GameObject[h, w];
            bonusBoard = new int[h, w];
            int X, Y = 0;
            int random, randomBonus;

            for (int y = 0; y < h; y++)
            {
                X = 0;
                for (int x = 0; x < w; x++)
                {
                    random = rand.Next(1,35);
                    randomBonus = rand.Next(1, 101);
                    bonusBoard[y, x] = 0;
                    if (y < h - 1 && x > 0 && x < w - 1 && gameBoard[y,x] != 20 && gameBoard[y, x] < 30)
                    {
                        if (random == 1)
                        {
                            if (randomBonus < 50)
                            {
                                bonusBoard[y, x] = 1;
                                bonus[y, x] = new GameObject(content.Load<Texture2D>("apple"), new Vector2(X, Y));
                                bonusCount++;
                            }
                            else if (randomBonus >= 50 && randomBonus < 75)
                            {
                                bonusBoard[y, x] = 2;
                                bonus[y, x] = new GameObject(content.Load<Texture2D>("cherries"), new Vector2(X, Y));
                                bonusCount++;
                            }
                            else if (randomBonus >= 75 && randomBonus < 101)
                            {
                                bonusBoard[y, x] = 3;
                                bonus[y, x] = new GameObject(content.Load<Texture2D>("strawberry"), new Vector2(X, Y));
                                bonusCount++;
                            }
                        }
                    }
                    X += 30;
                }
                Y += 30;
            }
        }

        public void Draw()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (bonus[y, x] != null)
                        bonus[y, x].Draw(spriteBatch);
                }
            }
        }
    }
}
