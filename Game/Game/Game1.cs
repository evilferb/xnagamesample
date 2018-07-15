using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState;

        GameLand gameLand;
        Bonuses bonuses;
        UserInterface userInterface;
        Enemys enemys;
        Hero hero;

        int height = 20;
        int width = 40;

        public enum Direction
        {
            UP,
            Right,
            Down,
            Left
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = height * 30;
            graphics.PreferredBackBufferWidth = width * 30;

            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameLand = new GameLand(spriteBatch, height, width);
            gameLand.load(Content);


            bonuses = new Bonuses(spriteBatch, gameLand.H, gameLand.W);
            bonuses.load(Content, gameLand.GameBoard);


            enemys = new Enemys(Content, spriteBatch, 12, gameLand.H, gameLand.W);
            enemys.load(gameLand.GameBoard);

            hero = new Hero(Content.Load<Texture2D>("heroright"), new Vector2(3, 3), 1.7f);
            hero.Content = Content;

            userInterface = new UserInterface(spriteBatch);
            userInterface.Load(Content, height, width);
        }

        protected override void UnloadContent()
        {
            //
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (hero.HP > 0)
            {
                enemys.Move(gameLand, gameLand.Block, hero);

                hero.CheckForMonsters(enemys);

                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    hero.Move(Direction.UP, gameLand, gameLand.Block, gameLand.H, gameLand.W, bonuses, bonuses.BonusBoard, gameTime);
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    hero.Move(Direction.Down, gameLand, gameLand.Block, gameLand.H, gameLand.W, bonuses, bonuses.BonusBoard, gameTime);
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    hero.Move(Direction.Right, gameLand, gameLand.Block, gameLand.H, gameLand.W, bonuses, bonuses.BonusBoard, gameTime);
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    hero.Move(Direction.Left, gameLand, gameLand.Block, gameLand.H, gameLand.W, bonuses, bonuses.BonusBoard, gameTime);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (hero.HP > 0)
            {
                if (bonuses.BonusCount > 0)
                {
                    gameLand.Draw();

                    bonuses.Draw();

                    enemys.Draw();

                    hero.Draw(spriteBatch);
                }
                else
                {
                    userInterface.EndGame(Content, gameLand.W * 30, gameLand.H * 30, true);
                    GraphicsDevice.Clear(Color.FromNonPremultiplied(39, 174, 96, 1));
                }
            }
            else
            {
                userInterface.EndGame(Content, gameLand.W * 30, gameLand.H * 30, false);
                GraphicsDevice.Clear(Color.FromNonPremultiplied(39, 174, 96, 1));
            }

            userInterface.Draw(bonuses.BonusCount, hero.HP, hero.Armor, height, width);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
