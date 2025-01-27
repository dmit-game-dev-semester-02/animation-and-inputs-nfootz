using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01;

public class Assignment01 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _cloud;
    private float _mummyX = 0, _mummyY = 300, _mummyXSpeed = 3;
    private float _hollowKnightX = 500, _hollowKnightY = 100, _hollowKnightXSpeed = 3;
    private const int _WindowWidth = 612;
    private const int _WindowHeight = 367;
    private const int _GroundHeight = 293;
    CelAnimationPlayer _mummyAnimation, _hollowKnightAnimation;
    CelAnimationSequence _mummySequence, _hollowKnightSequence;
    private KeyboardState _kbPreviousState;
    private SpriteEffects _mummySpriteEffect = SpriteEffects.None, _hollowKnightSpriteEffect = SpriteEffects.None;

    public Assignment01()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("pixelbackground");
        _cloud = Content.Load<Texture2D>("pixelcloud");

        Texture2D mummySpriteSheet = Content.Load<Texture2D>("mummy");
        _mummySequence = new CelAnimationSequence(mummySpriteSheet, 74, 0, 0, 1/6f);
        _mummyAnimation = new CelAnimationPlayer();
        _mummyAnimation.Play(_mummySequence);

        Texture2D hollowKnightSpriteSheet = Content.Load<Texture2D>("hollowknight");
        _hollowKnightSequence = new CelAnimationSequence(hollowKnightSpriteSheet, 80, 75, 9, 1/9f);
        _hollowKnightAnimation = new CelAnimationPlayer();
        _hollowKnightAnimation.Play(_hollowKnightSequence);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState kbCurrentState = Keyboard.GetState();

        _mummyAnimation.Update(gameTime);
        _hollowKnightAnimation.Update(gameTime);

        #region Mummy Movement
        if (_mummyY > _GroundHeight - _mummySequence.CelHeight)
            _mummyY = _GroundHeight - _mummySequence.CelHeight;

        if (kbCurrentState.IsKeyDown(Keys.Left))
        {
            _mummyX -= _mummyXSpeed;
            _mummySpriteEffect = SpriteEffects.None;
        }
        if (kbCurrentState.IsKeyDown(Keys.Right))
        {
            _mummyX += _mummyXSpeed;
            _mummySpriteEffect = SpriteEffects.FlipHorizontally;
        }

        if (_mummyX < 0)
            _mummyX = 0;
        if (_mummyX > _WindowWidth - _mummySequence.CelWidth)
            _mummyX = _WindowWidth - _mummySequence.CelWidth;
        #endregion

        _kbPreviousState = kbCurrentState;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_cloud, new Vector2(300, 50), Color.White);
        _mummyAnimation.Draw(_spriteBatch, new Vector2(_mummyX, _mummyY), _mummySpriteEffect);
        _hollowKnightAnimation.Draw(_spriteBatch, new Vector2(_hollowKnightX, _hollowKnightY), _hollowKnightSpriteEffect);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
