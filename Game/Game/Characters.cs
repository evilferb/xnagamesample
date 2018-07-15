using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game
{
    public class Characters : GameObject
    {
        protected ContentManager content;

        public ContentManager Content
        {
            set { content = value; }
        }

        public Characters(Texture2D texture, Vector2 position)
            :base (texture, position)
        {

        }
    }
}
