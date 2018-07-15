using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game
{
    public class GameLand
    {
        SpriteBatch spriteBatch;

        GameObject[,] blockGrass;
        GameObject[,] blockWater;
        GameObject[,] blockBush;
        GameObject[,] block;

        Random rand = new Random();

        int[,] gameBoard;
        int h, w;

        public GameLand(SpriteBatch spriteBatch, int boardHeight, int boardWidth)
        {
            this.spriteBatch = spriteBatch;
            h = boardHeight;
            w = boardWidth;
        }

        public GameObject[,] Block
        {
            get { return block; }
        }

        public int[,] GameBoard
        {
            get { return gameBoard; }
        }

        public int H
        {
            get { return h; }
        }

        public int W
        {
            get { return w; }
        }

        public void load(ContentManager content)
        {
            blockGrass = new GameObject[h, w];
            blockWater = new GameObject[h, w];
            blockBush = new GameObject[h, w];
            block = new GameObject[h, w];
            gameBoard = new int[h, w];
            int X, Y = 0;
            int random, waterRandom;

            for (int y = 0; y < h; y++)
            {
                X = 0;
                for (int x = 0; x < w; x++)
                {
                    random = rand.Next(1, 3);
                    waterRandom = rand.Next(1, 25);
                    if (gameBoard[y, x] < 30)
                    {
                        if (y < h - 1 && x > 0 && x < w - 1)
                        {
                            if (random == 2)
                            {
                                gameBoard[y, x] = 20;
                                blockGrass[y, x] = new GameObject(content.Load<Texture2D>("grass"), new Vector2(X, Y));
                                blockBush[y, x] = new GameObject(content.Load<Texture2D>("bush"), new Vector2(X, Y));
                                block[y, x] = new GameObject(content.Load<Texture2D>("bush"), new Vector2(X, Y));
                            }
                            else
                            {
                                gameBoard[y, x] = 1;
                                blockGrass[y, x] = new GameObject(content.Load<Texture2D>("grass"), new Vector2(X, Y));
                                block[y, x] = new GameObject(content.Load<Texture2D>("grass"), new Vector2(X, Y));
                            }
                        }
                        else if (y == h - 1 && x == 0)
                        {
                            gameBoard[y, x] = 13;
                            blockGrass[y, x] = new GameObject(content.Load<Texture2D>("gld"), new Vector2(X, Y));
                            block[y, x] = new GameObject(content.Load<Texture2D>("gld"), new Vector2(X, Y));
                        }
                        else if (y == h - 1 && x == w - 1)
                        {
                            gameBoard[y, x] = 16;
                            blockGrass[y, x] = new GameObject(content.Load<Texture2D>("grd"), new Vector2(X, Y));
                            block[y, x] = new GameObject(content.Load<Texture2D>("grd"), new Vector2(X, Y));
                        }
                        else if (y == h - 1 && x != 0 && x != w - 1)
                        {
                            gameBoard[y, x] = 14;
                            blockGrass[y, x] = new GameObject(content.Load<Texture2D>("gcd"), new Vector2(X, Y));
                            block[y, x] = new GameObject(content.Load<Texture2D>("gcd"), new Vector2(X, Y));
                        }
                        else if (y != h - 1 && x == 0)
                        {
                            gameBoard[y, x] = 11;
                            blockGrass[y, x] = new GameObject(content.Load<Texture2D>("gl"), new Vector2(X, Y));
                            block[y, x] = new GameObject(content.Load<Texture2D>("gl"), new Vector2(X, Y));
                        }
                        else if (y != h - 1 && x == w - 1)
                        {
                            gameBoard[y, x] = 12;
                            blockGrass[y, x] = new GameObject(content.Load<Texture2D>("gr"), new Vector2(X, Y));
                            block[y, x] = new GameObject(content.Load<Texture2D>("gr"), new Vector2(X, Y));
                        }
                    }
                    try
                    {
                        if (x > 0 && x < w && y < h)
                        {
                            if (waterRandom == 4)
                            {
                                if (x < w + 5)
                                {
                                    if (y < h + 5
                                        && gameBoard[y, x] < 30 && gameBoard[y - 1, x - 1] < 30 && gameBoard[y - 1, x] < 30 && gameBoard[y - 1, x + 1] < 30 && gameBoard[y - 1, x + 2] < 30 && gameBoard[y - 1, x + 3] < 30 && gameBoard[y - 1, x + 4] < 30
                                        && gameBoard[y + 1, x - 1] < 30 && gameBoard[y + 1, x + 4] < 30
                                        && gameBoard[y + 2, x - 1] < 30 && gameBoard[y + 2, x + 4] < 30
                                        && gameBoard[y + 3, x - 1] < 30 && gameBoard[y + 3, x + 4] < 30
                                        && gameBoard[y + 4, x - 1] < 30 && gameBoard[y + 4, x] < 30 && gameBoard[y + 4, x + 1] < 30 && gameBoard[y + 4, x + 2] < 30 && gameBoard[y + 4, x + 3] < 30 && gameBoard[y + 4, x + 4] < 30)
                                    {
                                        #region top
                                        gameBoard[y, x] = 31;
                                        block[y, x] = new GameObject(content.Load<Texture2D>("gwtl"), new Vector2(X, Y));
                                        blockWater[y, x] = new GameObject(content.Load<Texture2D>("gwtl"), new Vector2(X, Y));

                                        gameBoard[y, x + 1] = 32;
                                        block[y, x + 1] = new GameObject(content.Load<Texture2D>("gwt"), new Vector2(X + 30, Y));
                                        blockWater[y, x + 1] = new GameObject(content.Load<Texture2D>("gwt"), new Vector2(X + 30, Y));

                                        gameBoard[y, x + 2] = 32;
                                        block[y, x + 2] = new GameObject(content.Load<Texture2D>("gwt"), new Vector2(X + 60, Y));
                                        blockWater[y, x + 2] = new GameObject(content.Load<Texture2D>("gwt"), new Vector2(X + 60, Y));

                                        gameBoard[y, x + 3] = 33;
                                        block[y, x + 3] = new GameObject(content.Load<Texture2D>("gwtr"), new Vector2(X + 90, Y));
                                        blockWater[y, x + 3] = new GameObject(content.Load<Texture2D>("gwtr"), new Vector2(X + 90, Y));
                                        #endregion

                                        #region center
                                        gameBoard[y + 1, x] = 38;
                                        block[y + 1, x] = new GameObject(content.Load<Texture2D>("gwl"), new Vector2(X, Y + 30));
                                        blockWater[y + 1, x] = new GameObject(content.Load<Texture2D>("gwl"), new Vector2(X, Y + 30));

                                        gameBoard[y + 1, x + 1] = 30;
                                        block[y + 1, x + 1] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 30, Y + 30));
                                        blockWater[y + 1, x + 1] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 30, Y + 30));

                                        gameBoard[y + 1, x + 2] = 30;
                                        block[y + 1, x + 2] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 60, Y + 30));
                                        blockWater[y + 1, x + 2] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 60, Y + 30));

                                        gameBoard[y + 1, x + 3] = 34;
                                        block[y + 1, x + 3] = new GameObject(content.Load<Texture2D>("gwr"), new Vector2(X + 90, Y + 30));
                                        blockWater[y + 1, x + 3] = new GameObject(content.Load<Texture2D>("gwr"), new Vector2(X + 90, Y + 30));

                                        /////////////////////////////////////////////////////////////////////////////////////////////////////

                                        gameBoard[y + 2, x] = 38;
                                        block[y + 2, x] = new GameObject(content.Load<Texture2D>("gwl"), new Vector2(X, Y + 60));
                                        blockWater[y + 2, x] = new GameObject(content.Load<Texture2D>("gwl"), new Vector2(X, Y + 60));

                                        gameBoard[y + 2, x + 1] = 30;
                                        block[y + 2, x + 1] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 30, Y + 60));
                                        blockWater[y + 2, x + 1] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 30, Y + 60));

                                        gameBoard[y + 2, x + 2] = 30;
                                        block[y + 2, x + 2] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 60, Y + 60));
                                        blockWater[y + 2, x + 2] = new GameObject(content.Load<Texture2D>("water"), new Vector2(X + 60, Y + 60));

                                        gameBoard[y + 2, x + 3] = 34;
                                        block[y + 2, x + 3] = new GameObject(content.Load<Texture2D>("gwr"), new Vector2(X + 90, Y + 60));
                                        blockWater[y + 2, x + 3] = new GameObject(content.Load<Texture2D>("gwr"), new Vector2(X + 90, Y + 60));
                                        #endregion

                                        #region bottom
                                        gameBoard[y + 3, x] = 37;
                                        block[y + 3, x] = new GameObject(content.Load<Texture2D>("gwbl"), new Vector2(X, Y + 90));
                                        blockWater[y + 3, x] = new GameObject(content.Load<Texture2D>("gwbl"), new Vector2(X, Y + 90));

                                        gameBoard[y + 3, x + 1] = 36;
                                        block[y + 3, x + 1] = new GameObject(content.Load<Texture2D>("gwb"), new Vector2(X + 30, Y + 90));
                                        blockWater[y + 3, x + 1] = new GameObject(content.Load<Texture2D>("gwb"), new Vector2(X + 30, Y + 90));

                                        gameBoard[y + 3, x + 2] = 36;
                                        block[y + 3, x + 2] = new GameObject(content.Load<Texture2D>("gwb"), new Vector2(X + 60, Y + 90));
                                        blockWater[y + 3, x + 2] = new GameObject(content.Load<Texture2D>("gwb"), new Vector2(X + 60, Y + 90));

                                        gameBoard[y + 3, x + 3] = 35;
                                        block[y + 3, x + 3] = new GameObject(content.Load<Texture2D>("gwbr"), new Vector2(X + 90, Y + 90));
                                        blockWater[y + 3, x + 3] = new GameObject(content.Load<Texture2D>("gwbr"), new Vector2(X + 90, Y + 90));
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {

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
                    if (blockGrass[y, x] != null)
                        blockGrass[y, x].Draw(spriteBatch);
                    if (blockWater[y, x] != null)
                        blockWater[y, x].Draw(spriteBatch);
                    if (blockBush[y, x] != null)
                        blockBush[y, x].Draw(spriteBatch);
                }
            }
        }

    }
}
