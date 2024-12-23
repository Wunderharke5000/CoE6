using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace CoE6;

public static class ContentLoader
{
    public static List<Texture2D> textures;
    static ContentLoader()
    {
        textures = new List<Texture2D>();
    }
}