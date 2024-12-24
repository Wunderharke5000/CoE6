using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoE6;

public static class Camera
{
    // Initialized Attributes
    private static GraphicsDevice _graphicsDevice;
    public static Point ScreenSize;
    
    // Attributes
    private static uint _zoom;  // Tile/Screen (Width)
    public static Point Position;   // Position of Camera
    public static bool FullScreen;  // True if Fullscreen
    
    static Camera()
    {
        _zoom = 20;
        FullScreen = false;
    }

    // Inizializes stuff
    public static void Initialize(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        UpdateScreenSize();
    }

    // Methods
    
    public static void UpdateScreenSize()
    {
        ScreenSize = FullScreen
            ? new Point(_graphicsDevice.DisplayMode.Width, _graphicsDevice.DisplayMode.Height)
            : new Point(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height);
    }
    
    public static void RenderView(SpriteBatch spriteBatch, TileMap tileMap)
    {
        Rectangle dimensions = new Rectangle((Position.ToVector2() / Ratio).ToPoint(),
            new Point((int)_zoom + 1, (int)VerticalZoomValue + 1));
        tileMap.Draw(spriteBatch, dimensions, DrawScreenFillingTiles());
    }

    private static Rectangle DrawScreenFillingTiles()
    {
        Vector2 topLeftCorner = new Vector2(-(Position.X % Ratio),
            -(Position.Y % Ratio));
        return new Rectangle
        (
            topLeftCorner.ToPoint(),
            new Point((int)((_zoom + 1) * Ratio), (int)((VerticalZoomValue + 1) * Ratio))
        );
    }
    
    // Calculation Methods
    private static float Ratio => (float)ScreenSize.X / _zoom;  // Pixels per Tile Horizontal
    private static Point ScreenToMap(Point point) => ((Position.ToVector2() + point.ToVector2()) / Ratio).ToPoint();
    private static Point MapToScreen(Point point) => (point.ToVector2() * Ratio - Position.ToVector2()).ToPoint();
    private static uint VerticalZoomValue => (uint)(Math.Ceiling(ScreenSize.Y / Ratio));
    public static Point ScreenPositionInTiles() => ScreenToMap(Position);
}