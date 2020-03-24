using System;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Codecool.Quest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class CodecoolQuestGame : Game
    {
        public static CodecoolQuestGame GameSingleton;

        public SpriteBatch SpriteBatch;

        private GameMap _map;
        private TimeSpan _lastMoveTime;

        public const double MoveInterval = 0.1;

        public CodecoolQuestGame()
        {
            GameSingleton = this;

            using var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.AllowUserResizing = true;
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            _lastMoveTime = TimeSpan.Zero;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            
            GUI.Load();
            Tiles.Load();

            _map = MapLoader.LoadMap();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                // Exit the game
                Exit();
                return;
            }

            var deltaTime = gameTime.TotalGameTime - _lastMoveTime;

            if (deltaTime.TotalSeconds < MoveInterval)
                return;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // Move left   
                var neighborCell = _map.Player.Cell.GetNeighbor(-1, 0);
                if (neighborCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Left);
                }
                else
                {
                    var cellHasBeenFreed = _map.Player.CollectItemOrFight(neighborCell);
                    if (cellHasBeenFreed)
                    {
                        _map.Player.MovePlayer(MoveDirection.Left);
                    }
                }
                
                
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                // Move right
                var neighborCell = _map.Player.Cell.GetNeighbor(1, 0);
                if (neighborCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Right);
                }
                else
                {
                    var cellHasBeenFreed = _map.Player.CollectItemOrFight(neighborCell);
                    if (cellHasBeenFreed)
                    {
                        _map.Player.MovePlayer(MoveDirection.Right);
                    }

                }
                

                _lastMoveTime = gameTime.TotalGameTime;

            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                //move up
                var neighborCell = _map.Player.Cell.GetNeighbor(0, -1);
                if (neighborCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Up);
                }
                else
                {
                    var cellHasBeenFreed = _map.Player.CollectItemOrFight(neighborCell);
                    if (cellHasBeenFreed)
                    {
                        _map.Player.MovePlayer(MoveDirection.Up);
                    }

                }
                
                _lastMoveTime = gameTime.TotalGameTime;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                // Move down
                var neighborCell = _map.Player.Cell.GetNeighbor(0, 1);
                if (neighborCell.IsCellFree())
                {
                    _map.Player.MovePlayer(MoveDirection.Down);
                }
                else
                {
                    var cellHasBeenFreed = _map.Player.CollectItemOrFight(neighborCell);
                    if (cellHasBeenFreed)
                    {
                        _map.Player.MovePlayer(MoveDirection.Down);
                    }

                }

                _lastMoveTime = gameTime.TotalGameTime;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.PointClamp);

            for (var x = 0; x < _map.Width; x++)
            {
                for (var y = 0; y < _map.Height; y++)
                {
                    var cell = _map.GetCell(x, y);

                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(SpriteBatch, cell.Actor, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(SpriteBatch, cell, x, y);
                    }
                }
            }



            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
