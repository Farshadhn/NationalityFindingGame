using Microsoft.AspNetCore.Components;


namespace NationalityFindingGame.Components.Game;

public partial class NationalityPlaceHolderComponent
{

    #region ... Parameters ...
    [Parameter]
    public string Content { get; set; }

    [Parameter]
    public Point Position { get; set; }
     

    #endregion



}

