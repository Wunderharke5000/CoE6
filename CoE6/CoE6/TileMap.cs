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
        for (int x = -1; x < drawarea.Width; x++)
        for (int y = -1; y < drawarea.Height; y++)
        {
            if(x + drawarea.X < Map.GetLength(0) && y + drawarea.Y < Map.GetLength(1) && drawarea.X + x >= 0 && drawarea.Y + y >= 0)
            {
                if (x % 2 != y % 2)
                    spriteBatch.Draw(_tileTextures[Map[drawarea.X + x, drawarea.Y + y, 0]],
                        new Rectangle(bounds.X + x * tileSize, bounds.Y + y * tileSize, tileSize, tileSize),
                        Color.DarkGreen);
                else
                    spriteBatch.Draw(_tileTextures[Map[drawarea.X + x, drawarea.Y + y, 0]],
                        new Rectangle(bounds.X + x * tileSize, bounds.Y + y * tileSize, tileSize, tileSize),
                        Color.Green);
            }
            else
                spriteBatch.Draw(ResourceLoader.SolidColorTexture,
                new Rectangle(bounds.X + x * tileSize, bounds.Y + y * tileSize, tileSize, tileSize),
                Color.Red);
        }
        
    }

    private void InitTileTextures()
    {
        _tileTextures.Add(ResourceLoader.SolidColorTexture);
    }
}