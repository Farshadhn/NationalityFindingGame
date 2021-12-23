using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NationalityFindingGame.Models.Game;

namespace NationalityFindingGame.Components.Game;

public partial class NationalityPlaceHolderComponent
{

    #region ... Parameters ...
    [Parameter]
    public string Content { get; set; }

    [Parameter]
    public Point Position { get; set; }


    [CascadingParameter]
    public ImagePlaceHolderModel SelectedImage { get; set; }

    [Parameter]
    public EventCallback<int> OnStatusUpdated { get; set; }

    #endregion

 

    #region ... Events ....

    private async Task FindDropedItem(DragEventArgs args)
    {
        var IfItIsMatched = SelectedImage.Nationality == Content;
        int point = (IfItIsMatched) ? 20 : -5;
        await OnStatusUpdated.InvokeAsync(point);
    }
    #endregion


}

