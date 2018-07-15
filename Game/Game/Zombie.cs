using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Zombie : Characters
    {
        int damage = 30;
        float speedX;
        float speedY;
        float speed;

        public Zombie(Texture2D texture, Vector2 position, float speed)
            : base(texture, position)
        {
            this.speed = speed;
            speedX = speed * -1;
            speedY = 0;
        }

        public int Damage
        {
            get { return damage; }
        }

        public void Move(GameLand gameLand, GameObject[,] block, int height, int width, Hero hero)
        {
            if (speedX > 0)
                texture = content.Load<Texture2D>("Zombie");
            else
                texture = content.Load<Texture2D>("Zombieleft");
            Position.X += speedX;
            Position.Y += speedY;
            CheckLandCollision(gameLand, block, height, width);
            CheckForGameLandAnd(height, width);
        }

        public void CheckLandCollision(GameLand gameLand, GameObject[,] block, int height, int width)
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
                            speedX *= -1;
                        }
                    }
                }
            }
        }

        public void CheckForGameLandAnd(int height, int width)
        {
            if (Position.X < 5 || Position.X > width * 30 - 20)
                speedX *= -1;
        }
    }
}
