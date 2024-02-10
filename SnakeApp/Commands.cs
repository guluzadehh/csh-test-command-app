using CommandApp.Command;
using CommandApp.App;
using CommandApp.Feature;

namespace SnakeApp;

public class StartGameCommand : ICommand
{
    public string Value { get; } = "start";

    public string Description { get; } = "Start game";

    public void Execute(IApp app)
    {
        SnakeGame.Core.IDisplay display = new SnakeAppDisplay(app);
        SnakeGame.Game game = new(display);

        if (app.Context.TryGetValue("width", out object? width))
        {
            game.Width = (int)width;
        }

        if (app.Context.TryGetValue("size", out object? height))
        {
            game.Height = (int)height;
        }

        game.Start();
    }
}

public class SetArenaSizeCommand : BaseCommand
{
    public override string Value { get; } = "set size";

    public override string Description { get; } = "Set arena size (width and height)";

    public override IFeature Feature { get; } = new SetArenaSizeFeature();
}
