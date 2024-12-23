using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CoE6;

public static class ResourceLoader
{
    // Tools to initialize
    private static ContentManager _contentManager;
    private static GraphicsDevice _graphicsDevice;
    public static Texture2D SolidColorTexture;
    
    // more vars
    public static List<Texture2D> Textures;
    static ResourceLoader()
    {
        Textures = new List<Texture2D>();
    }

    public static void InitialzeResourceLoader(ContentManager contentManager, GraphicsDevice graphicsDevice)
    {
        _contentManager = contentManager;
        _graphicsDevice = graphicsDevice;
        SolidColorTexture = new Texture2D(_graphicsDevice, 1, 1);
        SolidColorTexture.SetData(new[] { Color.White });
    } 
    
}