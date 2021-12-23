using Microsoft.AspNetCore.Components;

namespace NationalityFindingGame.Components;

public partial class Leaderboard
{
    [Parameter]
    public List<int> HighestPoints { get; set; }
}

