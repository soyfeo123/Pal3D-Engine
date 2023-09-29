using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pal3DEngine
{
    public class RendererSettings
    {
        public bool isFullscreen;
        public int resX;
        public int resY;
        public bool vSync;
    }
    public enum GameState
    {
        Cutscene,
        Menu,
        TDView
    }
    public class MainGameComponent
    {
        public virtual void FrameDraw() { }
        public virtual void LogicUpdate() { }
    }
    public class MainGameRenderer : Game
    {
        private GraphicsDeviceManager _graphics;
        public RendererSettings gameRenderSettings;
        public GameState gameState = GameState.Menu;
        private SpriteBatch _spriteBatch;

        public MainGameRenderer()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameRenderSettings = new RendererSettings();
            gameRenderSettings.isFullscreen = true;
            gameRenderSettings.resX = 1366;
            gameRenderSettings.resY = 768;
            base.Initialize();
            ApplyGameRenderSettings();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        public void ApplyGameRenderSettings()
        {
            _graphics.IsFullScreen = gameRenderSettings.isFullscreen;
            _graphics.PreferredBackBufferWidth = gameRenderSettings.resX;
            _graphics.PreferredBackBufferHeight = gameRenderSettings.resY;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}