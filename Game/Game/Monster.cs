using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Monster : Characters
    {

        int damage = 35;
        float speedX;
        float speedY;
        float speed;

        public Monster(Texture2D texture, Vector2 position, float speed)
            : base(texture, position)
        {
            this.speed = speed;
            speedX = 0;
            speedY = speed * -1;
        }

        public int Damage
        {
            get { return damage; }
        }

        public void Move(GameLand gameLand, GameObject[,] block, int height, int width, Hero hero)
        {
            Position.X += speedX;
            Position.Y += speedY;
            CheckLandCollision(gameLand, block, height, width);
            checkForGameLandAnd(height, width);
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
                            speedY *= -1;
                        }
                    }
                }
            }
        }

        public void checkForGameLandAnd(int height, int width)
        {
            if (Position.Y < 5 || Position.Y > height * 30 - 50)
                speedY *= -1;
        }
    }
}
