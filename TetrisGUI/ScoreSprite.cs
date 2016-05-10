using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject;

namespace TetrisGUI
{
    public class ScoreSprite : DrawableGameComponent
    {
        private Score score;
        private Game1 game;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        /// <summary>
        /// 2 params constructor.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="score"></param>
        public ScoreSprite(Game1 game, Score score)
            : base(game)
        {
            this.score = score;
            this.game = game;
        }

        /// <summary>
        /// Overrided Initialize method, doesnt do anything special.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Overrided LoadContent method that loads the needed content to draw the score.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("ScoreFont");
            base.LoadContent();
        }

        /// <summary>
        /// Override Update method, doesnt do anything special.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Override Draw method that draws out the Scores.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Level: " + score.Level, new Vector2(220, 100), Color.Gray);
            spriteBatch.DrawString(font, "Score: " + score.GameScore, new Vector2(220, 120), Color.Gray);
            spriteBatch.DrawString(font, "Lines Cleared: " + score.Lines, new Vector2(220, 140), Color.Gray);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
