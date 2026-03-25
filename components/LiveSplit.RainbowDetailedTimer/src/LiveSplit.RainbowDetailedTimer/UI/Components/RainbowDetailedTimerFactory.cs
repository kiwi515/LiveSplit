using System;

using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(RainbowDetailedTimerFactory))]

namespace LiveSplit.UI.Components;

public class RainbowDetailedTimerFactory : IComponentFactory
{
    public string ComponentName => "Rainbow Detailed Timer";

    public string Description => "Displays the run timer, segment timer, and segment times for up to two comparisons. Turns rainbow when you PB!";

    public ComponentCategory Category => ComponentCategory.Timer;

    public IComponent Create(LiveSplitState state)
    {
        return new RainbowDetailedTimer(state);
    }

    public string UpdateName => ComponentName;

    public string XMLURL => "";

    public string UpdateURL => "";

    public Version Version => Version.Parse("1.0.0");
}
