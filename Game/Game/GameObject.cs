using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class GameObject
    {
        public Texture2D texture;
        public Vector2 Position;
        protected Vector2 velocity;
        protected float constantSpeed;

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    texture.Width,
                    texture.Height);
            }
        }

        public GameObject(Texture2D text, Vector2 position)
        {
            texture = text;
            Position = position;
        }

        public GameObject(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.texture = texture;

            Position = position;

            this.velocity = velocity;
        }


    public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
