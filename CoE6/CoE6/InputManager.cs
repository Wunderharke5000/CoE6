using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoE6;

public static class InputManager
{
    public static void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.D)) Camera.Position.X++;
        if (Keyboard.GetState().IsKeyDown(Keys.A)) Camera.Position.X--;
    }
}