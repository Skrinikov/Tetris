using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisUI
{
    public class BoardSprite : DrawableGameComponent
    {

        private IBoard board;
        private Game1 game;
        private SpriteBatch spriteBatch;

        //To Render
        private Texture2D emptyBlock;
        private Texture2D filledBlock;

        public BoardSprite(Game1 game, IBoard board) :base(game)
        {
            this.board = board;
            this.game = game;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            emptyBlock = game.Content.Load<Texture2D>("EmptyBlock");
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
            base.LoadContent();
        }

   

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();


            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Color.Transparent)
                        spriteBatch.Draw(emptyBlock, new Vector2(j * emptyBlock.Width, (19 - i) * emptyBlock.Height), Color.White);
                    else
                        spriteBatch.Draw(filledBlock, new Vector2(j * filledBlock.Width, (19 - i) * filledBlock.Height), board[i, j]);
                }

            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
