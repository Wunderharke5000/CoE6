using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoE6;

public class TileMap
{
    // TileMap x y and layers
    public byte[,,] Map;
    private List<Texture2D> _tileTextures;
    
    public TileMap(int width, int height)
    {
        Map = new byte[width, height, 2];
        _tileTextures = new List<Texture2D>();
        InitTileTextures();
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle drawarea, Rectangle bounds) // Bounds.Height is useless. Draws tiles of area in certain dimensions
    {
        int tileSize = bounds.Width / drawarea.Width;
        for (int x = 0; x < drawarea.Width; x++)
        for (int y = 0; y < drawarea.Height; y++)
        {
            spriteBatch.Draw(_tileTextures[Map[drawarea.X + x, drawarea.Y + y, 0]],
                new Rectangle(bounds.X + drawarea.X * tileSize, bounds.Y + drawarea.Y * tileSize, tileSize, tileSize),
                Color.Green);
        }
        
    }

    private void InitTileTextures()
    {
        _tileTextures.Add(ResourceLoader.SolidColorTexture);
    }
}