using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TetrisProject;

namespace TetrisGUI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BoardSprite boardSprite;
        private ShapeSprite shapeSprite;
        private ScoreSprite scoreSprite;
        private SpriteFont font;
        private bool GameIsOver = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IBoard board = new Board();
            Score score = new Score(board);
            boardSprite = new BoardSprite(this, board);
            scoreSprite = new ScoreSprite(this, score);
            shapeSprite = new ShapeSprite(this, board.Shape, score);
            board.GameOver += GameOver;

            Components.Add(boardSprite);
            Components.Add(scoreSprite);
            Components.Add(shapeSprite);

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            this.Content.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 350;
            graphics.ApplyChanges();

            if (GameIsOver)
            {
                font = this.Content.Load<SpriteFont>("ScoreFont");
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "GAME OVER!", new Vector2(220, 200), Color.Tomato);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }

        /// <summary>
        /// The GameOver method that is call when the game is over to set the game's state to GameIsOver.
        /// </summary>
        private void GameOver()
        {
            Components.Remove(shapeSprite);
            GameIsOver = true;
        }
    }
}
