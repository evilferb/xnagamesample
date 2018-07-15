using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class UserInterface
    {
        SpriteBatch spriteBatch;
        GameObject back;
        SpriteFont score;
        GameObject scoreIcon;
        SpriteFont hp;
        GameObject hpIcon;
        SpriteFont armor;
        GameObject armorIcon;
        SpriteFont endFont;

        public UserInterface(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Load(ContentManager content, int height, int width)
        {
            back = new GameObject(content.Load<Texture2D>("back"), new Vector2(width * 30 / 2 - 150, height * 30 - 22));
            scoreIcon = new GameObject(content.Load<Texture2D>("bonuses"), new Vector2(width * 30 / 2 - 134, height * 30 - 30));
            hpIcon = new GameObject(content.Load<Texture2D>("hp"), new Vector2(width * 30 / 2 - 31, height * 30 - 30));
            armorIcon = new GameObject(content.Load<Texture2D>("armor"), new Vector2(width * 30 / 2 + 58, height * 30 - 30));
            score = content.Load<SpriteFont>("Score");
            hp = content.Load<SpriteFont>("Score");
            armor = content.Load<SpriteFont>("Score");
        }

        public void Draw(int bonusCount, int hp, int armor, int height, int width)
        {
            back.Draw(spriteBatch);
            scoreIcon.Draw(spriteBatch);
            hpIcon.Draw(spriteBatch);
            armorIcon.Draw(spriteBatch);
            spriteBatch.DrawString(score, $"{bonusCount.ToString()} left", new Vector2(width * 30 / 2 - 98, height * 30 - 21), Color.White);
            spriteBatch.DrawString(this.hp, $"{hp.ToString()}%", new Vector2(width * 30 / 2 + 14, height * 30 - 21), Color.White);
            spriteBatch.DrawString(this.armor, $"{armor.ToString()}%", new Vector2(width * 30 / 2 + 98, height * 30 - 21), Color.White);
        }

        public void EndGame(ContentManager content, int width, int height, bool isWin)
        {
            if (isWin == false)
            {
                endFont = content.Load<SpriteFont>("EndGame");
                spriteBatch.DrawString(endFont, "You lose. Maybe next time?", new Vector2(width / 2 - 213, height / 2 - 27), Color.White);
            }
            else
            {
                endFont = content.Load<SpriteFont>("EndGame");
                spriteBatch.DrawString(endFont, "You're a winner. Congratulations!", new Vector2(width / 2 - 230, height / 2 - 25), Color.White);
            }
        }
    }
}
