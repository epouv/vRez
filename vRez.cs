using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace vRez;

public class VRezManager
{
    public RenderTarget2D VirtualTarget { get; private set; }
    public Rectangle RenderRectangle { get; private set; }
    public int VirtualWidth { get; }
    public int VirtualHeight { get; }

    private GraphicsDevice _graphicsDevice;
    private GameWindow _window;
    private float _aspectRatio;

    public VRezManager(GraphicsDevice graphicsDevice, GameWindow window, int virtualWidth, int virtualHeight)
    {
        _graphicsDevice = graphicsDevice;
        _window = window;
        VirtualWidth = virtualWidth;
        VirtualHeight = virtualHeight;
        _aspectRatio = virtualWidth / (float)virtualHeight;

        VirtualTarget = new RenderTarget2D(graphicsDevice, virtualWidth, virtualHeight);
        _window.ClientSizeChanged += (_, _) => HandleResize();
        HandleResize();
    }

    public void HandleResize()
    {
        int windowWidth = _window.ClientBounds.Width;
        int windowHeight = _window.ClientBounds.Height;
        float windowAspect = windowWidth / (float)windowHeight;

        if (windowAspect > _aspectRatio)
        {
            int presentWidth = (int)(windowHeight * _aspectRatio);
            int barWidth = (windowWidth - presentWidth) / 2;
            RenderRectangle = new Rectangle(barWidth, 0, presentWidth, windowHeight);
        }
        else
        {
            int presentHeight = (int)(windowWidth / _aspectRatio);
            int barHeight = (windowHeight - presentHeight) / 2;
            RenderRectangle = new Rectangle(0, barHeight, windowWidth, presentHeight);
        }
    }

    public Vector2 ScreenToVirtual(Point screenPoint)
    {
        if (!RenderRectangle.Contains(screenPoint))
            return Vector2.One * -1;

        float normX = (screenPoint.X - RenderRectangle.X) / (float)RenderRectangle.Width;
        float normY = (screenPoint.Y - RenderRectangle.Y) / (float)RenderRectangle.Height;

        return new Vector2(normX * VirtualWidth, normY * VirtualHeight);
    }

    public void BeginDraw(GraphicsDevice gd)
    {
        gd.SetRenderTarget(VirtualTarget);
        gd.Clear(Color.Transparent);
    }

    public void EndDraw(SpriteBatch spriteBatch, GraphicsDevice gd)
    {
        gd.SetRenderTarget(null);
        gd.Clear(Color.Black);

        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        spriteBatch.Draw(VirtualTarget, RenderRectangle, Color.White);
        spriteBatch.End();
    }
}
