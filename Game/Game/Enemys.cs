using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game
{
    public class Enemys
    {
        SpriteBatch spriteBatch;
        ContentManager content;

        Monster[] monster;
        Zombie[] zombie;
        FlyingMonster[] flyingMonster;

        Random rand = new Random();

        int h, w;
        int monsterCount = 0;
        int zombieCount = 0;
        int flyingMonsterCount = 0;
        int count;

        public Enemys(ContentManager content, SpriteBatch spriteBatch,  int count, int boardHeight, int BoardWidth)
        {
            this.count = count;
            this.content = content;
            this.spriteBatch = spriteBatch;
            this.h = boardHeight;
            this.w = BoardWidth;
        }

        public Monster[] Monster
        {
            get { return monster; }
            set { monster = value; }
        }

        public Zombie[] Zombie
        {
            get { return zombie; }
            set { zombie = value; }
        }

        public FlyingMonster[] FlyingMonster
        {
            get { return flyingMonster; }
            set { flyingMonster = value; }
        }

        public int MonsterCount
        {
            get { return count; }
            set { count = value; }
        }

        public void load(int[,] gameBoard)
        {
            int X, Y = 0;
            int random, randomMonster, randomMove;
            monster = new Monster[count];
            zombie = new Zombie[count];
            flyingMonster = new FlyingMonster[count];

            for (int y = 0; y < h / 2; y++)
            {
                X = 0;
                for (int x = 0; x < w / 2; x++)
                {
                    random = rand.Next(1, 20);
                    randomMonster = rand.Next(1, 4);
                    if (y < h - 3 && y > 3 && x > 3 && x < w - 3 &&  gameBoard[y, x] < 30 && count / 2 > monsterCount + zombieCount + flyingMonsterCount )
                    {
                        if (random == 1)
                        {
                            if (randomMonster == 1)
                            {
                                monster[monsterCount] = new Monster(content.Load<Texture2D>("Monster"), new Vector2(X, Y), 2.4f);
                                monster[monsterCount].Content = content;
                                monsterCount++;
                            }
                            else if (randomMonster == 2)
                            {
                                zombie[zombieCount] = new Zombie(content.Load<Texture2D>("Zombie"), new Vector2(X, Y), 2.8f);
                                zombie[zombieCount].Content = content;
                                zombieCount++;
                            }
                            else if (randomMonster == 3)
                            {
                                randomMove = rand.Next(1, 3);
                                flyingMonster[flyingMonsterCount] = new FlyingMonster(content.Load<Texture2D>("Flyingmonster"), new Vector2(X, Y), 1.8f, randomMove);
                                flyingMonster[flyingMonsterCount].Content = content;
                                flyingMonsterCount++;
                            }
                        }
                    }
                    X += 30;
                }
                Y += 30;
            }
            Y = h / 2 * 30;
            for (int y = h / 2; y < h; y++)
            {
                X = w / 2 * 30;
                for (int x = w / 2; x < w; x++)
                {
                    random = rand.Next(1, 2);
                    randomMonster = rand.Next(1, 4);
                    if (y < h - 3 && y > 3 && x > 3 && x < w - 3 && gameBoard[y, x] < 30 && count > monsterCount + zombieCount + flyingMonsterCount)
                    {
                        if (random == 1)
                        {
                            if (randomMonster == 1)
                            {
                                monster[monsterCount] = new Monster(content.Load<Texture2D>("Monster"), new Vector2(X, Y), 2.4f);
                                monster[monsterCount].Content = content;
                                monsterCount++;
                            }
                            else if (randomMonster == 2)
                            {
                                zombie[zombieCount] = new Zombie(content.Load<Texture2D>("Zombie"), new Vector2(X, Y), 2.8f);
                                zombie[zombieCount].Content = content;
                                zombieCount++;
                            }
                            else if (randomMonster == 3)
                            {
                                randomMove = rand.Next(1, 3);
                                flyingMonster[flyingMonsterCount] = new FlyingMonster(content.Load<Texture2D>("Flyingmonster"), new Vector2(X, Y), 1.8f, randomMove);
                                flyingMonster[flyingMonsterCount].Content = content;
                                flyingMonsterCount++;
                            }
                        }
                    }
                    X += 30;
                }
                Y += 30;
            }

        }

        public void Move(GameLand gameLand, GameObject[,] block, Hero hero)
        {
            for (int i = 0; i < count; i++)
            {
                if (monster[i] != null)
                    monster[i].Move(gameLand, block, h, w, hero);
                if (zombie[i] != null)
                    zombie[i].Move(gameLand, block, h, w, hero);
                if (flyingMonster[i] != null)
                    flyingMonster[i].Move(gameLand, block, h, w, hero);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < count; i++)
            {
                if (monster[i] != null)
                    monster[i].Draw(spriteBatch);
                if (zombie[i] != null)
                    zombie[i].Draw(spriteBatch);
                if (flyingMonster[i] != null)
                    flyingMonster[i].Draw(spriteBatch);
            }
        }
    }
}
