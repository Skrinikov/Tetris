using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace TetrisUI
{
    public class ShapeSprite : DrawableGameComponent
    {
        private IShape shape;
        private Score sc;
        private int counterMoveDown;

        private KeyboardState oldState;
        private int counterInput;
        private int threshold;

        private Game1 game;
        private SpriteBatch spriteBatch;

        //To render;
        private Texture2D filledBlock;


        public ShapeSprite(Game1 game, IShape shape, Score sc) :base(game)
        {
            this.game = game;
            this.sc = sc;
            this.shape = shape;

        }

        /// <summary>
        /// 
        /// </summary>
        private void checkInput(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    shape.MoveDown();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        shape.MoveDown();
                }
            }

            else if (newState.IsKeyDown(Keys.Left))
            {
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    shape.MoveLeft();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        shape.MoveLeft();
                }
            }
            else if (newState.IsKeyDown(Keys.Right))
            {
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    shape.MoveRight();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        shape.MoveRight();
                }
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    shape.Rotate();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        shape.Rotate();
                }
            }
            else if (newState.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    shape.Drop();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        shape.Drop();
                }
            }

            oldState = newState;
        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 10;
            counterInput = 0;
            counterMoveDown = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {

            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < shape.Length; i++)
                sb.Draw(filledBlock, new Vector2(shape[i].Position.Y * filledBlock.Height, shape[i].Position.X * filledBlock.Width), shape[i].Color);

                base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            counterMoveDown += gameTime.ElapsedGameTime.Milliseconds;
            if (counterMoveDown > ((11 - sc.Level) * 0.05) * 1000)
            {
                shape.MoveDown();
                counterMoveDown = 0;
            }
            checkInput(gameTime);
        }
    }
}
