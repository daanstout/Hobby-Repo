using System;
using System.CodeDom;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Roguelike.ECS.Components;
using Roguelike.ECS.Entities;
using Roguelike.Graphics;
using Roguelike.GridSystem;
using Roguelike.Utils.SpriteBatchExtensions;

namespace Roguelike {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        readonly Grid cave;
        readonly Player player;
        readonly Camera camera;
        Texture2D border;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentLibrary.Initialize(Services);

            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 800;

            cave = new Grid(new Vector2(30, 30));
            player = new Player(new Vector2(400.0f, 400.0f));
            camera = new Camera(graphics);
            
            camera.SetResolution(new Vector2(1500, 800));

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            ServiceLocator.Initialize();

            cave.Initialize();
            player.AddComponent(new PlayerMovingComponent());
            player.AddComponent(cave.GenerateMapHitbox());
            player.AddComponent(new StaffComponent());
            camera.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ServiceLocator.Load();

            player.Load();

            cave.LoadContent();

            border = Content.Load<Texture2D>("BorderBlack");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
            ContentLibrary.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ServiceLocator.Update(gameTime);

            // TODO: Add your update logic here
            player.Update(gameTime);
            camera.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            //GraphicsDevice.Clear(new Color(10, 0, 10));
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            var drawData = new DrawData(spriteBatch, camera.View);

            cave.DrawGrid(drawData);
            player.Draw(drawData);
            ServiceLocator.Draw(drawData);
            
            foreach(var cell in cave.grid) {
                if (!cell.isWall)
                    continue;
                var rect = cell.ViewRectangle;
                rect.Offset(-camera.View.Location.X, -camera.View.Location.Y);
                spriteBatch.Draw(border, rect, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
