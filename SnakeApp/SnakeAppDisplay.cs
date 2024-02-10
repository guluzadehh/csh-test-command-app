using CommandApp.App;
using SnakeGame.Core;

namespace SnakeApp
{
    public class SnakeAppDisplay(IApp app) : IDisplay
    {
        public IApp App { get; } = app;

        public void Draw(object Element, Position position)
        {
            App.Output.WriteAt(Element.ToString(), position.X, position.Y);
        }
    }
}