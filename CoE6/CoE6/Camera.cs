using System.Drawing;
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
        _zoom = 5;
        FullScreen = false;
    }

    public static void Initialize(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        UpdateScreenSize();
    }

    public static void UpdateScreenSize()
    {
        ScreenSize = FullScreen
            ? new Point(_graphicsDevice.DisplayMode.Width, _graphicsDevice.DisplayMode.Height)
            : new Point(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height);
    }
}