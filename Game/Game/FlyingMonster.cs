using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class FlyingMonster : Characters
    {
        int damage = 40;
        float speedX;
        float speedY;
        float speed;

        public FlyingMonster(Texture2D texture, Vector2 position, float speed, int startmove)
            : base(texture, position)
        {
            this.speed = speed;
            if (startmove == 1)
            {
                speedX = speed * -1;
                speedY = speed;
            }
            if (startmove == 2)
            {
                speedX = speed;
                speedY = speed * -1;
            }
        }

        public int Damage
        {
            get { return damage; }
        }

        public void Move(GameLand gameLand, GameObject[,] block, int height, int width, Hero hero)
        {
            if (speedX > 0)
                texture = content.Load<Texture2D>("Flyingmonster");
            else
                texture = content.Load<Texture2D>("Flyingmonsterleft");
            Position.X += speedX;
            Position.Y += speedY;
            checkForGameLandAnd(height, width);
        }

        public void checkForGameLandAnd(int height, int width)
        {
            if (Position.X < 3 || Position.X > width * 30 - 30)
                speedX *= -1;
            if (Position.Y < 3 || Position.Y > height * 30 - 60)
                speedY *= -1;
        }
    }
}
