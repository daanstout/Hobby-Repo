using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResourceGathererMono.GameWorld;

namespace ResourceGathererMono {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public sealed class ResourceGatherer : Game {
        World world;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ResourceGatherer() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
        }

        /// <summary>
        /// Set the window to Full Screen
        /// </summary>
        /// <param name="sender">The sender of the Event</param>
        /// <param name="e">The Preparing Device Settings Event Args for the Event</param>
        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e) {
            DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            e.GraphicsDeviceInformation.PresentationParameters.BackBufferFormat = displayMode.Format;
            e.GraphicsDeviceInformation.PresentationParameters.BackBufferWidth = displayMode.Width;
            e.GraphicsDeviceInformation.PresentationParameters.BackBufferHeight = displayMode.Height;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            // Set the game to be borderless and prevent the user from resizing the game
            Window.IsBorderless = true;
            Window.AllowUserResizing = false;

            base.Initialize();

            world = new World(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            BaseTile.RegisterTexture(Content.Load<Texture2D>("Land_01"), BaseTile.plainsMask);
            BaseTile.RegisterTexture(Content.Load<Texture2D>("Land_01"), BaseTile.waterMask);
            BaseTile.RegisterTexture(Content.Load<Texture2D>("Land_01"), BaseTile.stoneMask);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here

            spriteBatch.Begin();

            world.Render(spriteBatch);

            //Vector2 centre = new Vector2(200, 200);

            //BaseTile[] tiles = TileSystem.instance.GetNeighboursAll(TileSystem.instance.GetTileFromPos(centre));

            //SimpleTileRenderer renderer = new SimpleTileRenderer();

            //foreach (BaseTile tile in tiles) {
            //    renderer.RenderTile(tile, spriteBatch, Color.Red);
            //}

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing) {
            graphics.Dispose();
            spriteBatch.Dispose();

            base.Dispose(disposing);
        }
    }
}
