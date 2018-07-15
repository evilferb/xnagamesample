using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Hero : Characters
    {
        int hp = 20;
        int armor = 20;
        float speed;
        float bushSpeed;

        public int HP
        {
            get { return hp; }
        }

        public int Armor
        {
            get { return armor; }

        }

        public Hero(Texture2D texture, Vector2 position, float speed)
            : base(texture, position)
        {
            this.speed = speed;
            velocity = new Vector2(speed);
            constantSpeed = speed;
        }

        public void Move(Game1.Direction direction, GameLand gameLand, GameObject[,] block, int height, int width, Bonuses bonuses, int[,] bonusBoard, GameTime gameTime)
        {
            bushSpeed = speed - 0.8f;
            if (direction == Game1.Direction.UP)
            {
                Position.Y = Position.Y - velocity.Length();
                CheckLandCollision(direction, gameLand, block, height, width);
                CheckBonuseCollision(bonuses, bonusBoard, height,width, gameTime);
                checkForGameLandAnd(direction, height, width);
            }
            if (direction == Game1.Direction.Down)
            {
                Position.Y = Position.Y + velocity.Length();
                CheckLandCollision(direction, gameLand, block, height, width);
                CheckBonuseCollision(bonuses, bonusBoard, height, width, gameTime);
                checkForGameLandAnd(direction, height, width);
            }
            if (direction == Game1.Direction.Right)
            {
                texture = content.Load<Texture2D>("heroright");
                Position.X = Position.X + velocity.Length();
                CheckLandCollision(direction, gameLand, block, height, width);
                CheckBonuseCollision(bonuses, bonusBoard, height, width, gameTime);
                checkForGameLandAnd(direction, height, width);
            }
            if (direction == Game1.Direction.Left)
            {
                texture = content.Load<Texture2D>("heroleft");
                Position.X = Position.X - velocity.Length();
                CheckLandCollision(direction, gameLand, block, height, width);
                CheckBonuseCollision(bonuses, bonusBoard, height, width, gameTime);
                checkForGameLandAnd(direction, height, width);
            }
        }

        public void CheckLandCollision(Game1.Direction direction, GameLand gameLand, GameObject[,] block, int height, int width)
        {
            int[,] gameBoard = gameLand.GameBoard;
            block = gameLand.Block;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (gameBoard[y, x] == 30)
                    {
                        if (BoundingBox.Intersects(block[y, x].BoundingBox))
                        {
                            if (direction == Game1.Direction.UP)
                            {
                                Position.X = Position.X + 0;
                                Position.Y = Position.Y + velocity.Length();
                            }
                            if (direction == Game1.Direction.Right)
                            {
                                Position.X = Position.X - velocity.Length();
                                Position.Y = Position.Y + 0;
                            }
                            if (direction == Game1.Direction.Down)
                            {
                                Position.X = Position.X + 0;
                                Position.Y = Position.Y - velocity.Length();
                            }
                            if (direction == Game1.Direction.Left)
                            {
                                Position.X = Position.X + velocity.Length();
                                Position.Y = Position.Y + 0;
                            }
                        }
                    }
                    else if (gameBoard[y, x] == 20)
                    {
                        if (BoundingBox.Intersects(block[y, x].BoundingBox))
                        {
                            velocity = new Vector2(bushSpeed);
                        }
                    }
                    else if (gameBoard[y, x] != 30 && gameBoard[y, x] != 20)
                    {
                        if (BoundingBox.Intersects(block[y, x].BoundingBox))
                        {
                            velocity = new Vector2(constantSpeed);
                        }
                    }
                }
            }
        }

        public void checkForGameLandAnd(Game1.Direction direction, int height, int width)
        {
            if (direction == Game1.Direction.UP)
            {
                if (Position.Y < 0)
                {
                    Position.Y = Position.Y + velocity.Length();
                }
            }
            if (direction == Game1.Direction.Down)
            {
                if (Position.Y > height * 30 - 60)
                {
                    Position.Y = Position.Y - velocity.Length();
                }
            }
            if (direction == Game1.Direction.Right)
            {
                if (Position.X > width * 30 - 30)
                {
                    Position.X = Position.X - velocity.Length();
                }
            }
            if (direction == Game1.Direction.Left)
            {
                if (Position.X < 0)
                {
                    Position.X = Position.X + velocity.Length();
                    Position.Y = Position.Y - 0;
                }
            }
        }

        public void CheckBonuseCollision (Bonuses bonuses, int[,] bonusBoard, int height, int width, GameTime gameTime)
        {
            if (bonuses.BonusCount != 0)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (bonusBoard[y, x] > 0)
                        {
                            if (bonusBoard[y, x] == 1)
                            {
                                if (BoundingBox.Intersects(bonuses.Bonus[y, x].BoundingBox))
                                {
                                    if (hp + 15 < 100)
                                        hp = hp + 15;
                                    else hp = 100;
                                    bonusBoard[y, x] = 0;
                                    bonuses.Bonus[y, x] = null;
                                    bonuses.BonusCount--;
                                }
                            }
                            else if (bonusBoard[y, x] == 2)
                            {
                                if (BoundingBox.Intersects(bonuses.Bonus[y, x].BoundingBox))
                                {
                                    if (hp + 10 < 100)
                                        hp = hp + 10;
                                    else hp = 100;
                                    velocity = new Vector2(speed + 0.5f);
                                    speed += 0.5f;
                                    bonusBoard[y, x] = 0;
                                    bonuses.Bonus[y, x] = null;
                                    bonuses.BonusCount--;
                                }
                            }
                            else if (bonusBoard[y, x] == 3)
                            {
                                if (BoundingBox.Intersects(bonuses.Bonus[y, x].BoundingBox))
                                {
                                    if (armor + 30 < 100)
                                        armor = armor + 30;
                                    else armor = 100;
                                    bonusBoard[y, x] = 0;
                                    bonuses.Bonus[y, x] = null;
                                    bonuses.BonusCount--;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void CheckForMonsters (Enemys enemys)
        {
            for (int i = 0; i < enemys.MonsterCount; i++)
            {
                if (enemys.Monster[i] != null)
                {

                    if (BoundingBox.Intersects(enemys.Monster[i].BoundingBox))
                    {
                        if (armor > 0)
                        {
                            if (armor - enemys.Monster[i].Damage < 0)
                                armor = 0;
                            else armor -= enemys.Monster[i].Damage;
                        }
                        else
                        {
                            if (hp - enemys.Monster[i].Damage < 0)
                                hp = 0;
                            else hp -= enemys.Monster[i].Damage;
                        }
                        enemys.Monster[i] = null;
                        enemys.MonsterCount = enemys.MonsterCount - 1;
                    }
                }
                if (enemys.Zombie[i] != null)
                {
                    if (BoundingBox.Intersects(enemys.Zombie[i].BoundingBox))
                    {
                        if (armor > 0)
                        {
                            if (armor - enemys.Zombie[i].Damage < 0)
                                armor = 0;
                            else armor -= enemys.Zombie[i].Damage;
                        }
                        else
                        {
                            if (hp - enemys.Zombie[i].Damage < 0)
                                hp = 0;
                            else hp -= enemys.Zombie[i].Damage;
                        }
                        enemys.Zombie[i] = null;
                        enemys.MonsterCount = enemys.MonsterCount - 1;
                    }
                }
                if (enemys.FlyingMonster[i] != null)
                {
                    if (BoundingBox.Intersects(enemys.FlyingMonster[i].BoundingBox))
                    {
                        if (armor > 0)
                        {
                            if (armor - enemys.FlyingMonster[i].Damage < 0)
                                armor = 0;
                            else armor -= enemys.FlyingMonster[i].Damage;
                        }
                        else
                        {
                            if (hp - enemys.FlyingMonster[i].Damage < 0)
                                hp = 0;
                            else hp -= enemys.FlyingMonster[i].Damage;
                        }
                        enemys.FlyingMonster[i] = null;
                        enemys.MonsterCount = enemys.MonsterCount - 1;
                    }
                }
            }
        }
    }
}
