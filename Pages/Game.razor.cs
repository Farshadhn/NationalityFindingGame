using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NationalityFindingGame.Models.Game;

namespace NationalityFindingGame.Pages;

public partial class Game
{

    #region ... Injects ...


    [Inject] IJSRuntime ijs { get; set; }
    [Inject] NavigationManager nav { get; set; }

    [Inject] Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }


    #endregion

    #region ... Properties ...

    public int Points { get; set; } = 0; // Used To Collect User Point

    List<NationalityPlaceHolderModel> nationalityPlaceHolderModels = new();
    DotNetObjectReference<Game> dotNetReference; // Used to Call Dotnet From JS
    ImagePlaceHolderModel SelectedImage = new();
    List<ImagePlaceHolderModel> ListOfImages = new();

    #endregion


    #region ... Events ...
    public async Task SetPoints(int point)
    {
        Points += point;

        await ijs.InvokeVoidAsync("stopAnimation", dotNetReference, "ImagePlaceHolderId");
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

            dotNetReference = DotNetObjectReference.Create(this);
            SeedData();
            SelectNewFacePhoto();
            await base.OnAfterRenderAsync(firstRender);
        }
    }

   


    [JSInvokable("NextFacePhoto")]
    public void NextFacePhoto()
    {
        SelectNewFacePhoto();
        StateHasChanged();
    }
    #endregion


    #region ... Functions ...

    private void SeedData()
    {
        nationalityPlaceHolderModels.Add(new NationalityPlaceHolderModel("Japanese"));
        nationalityPlaceHolderModels.Add(new NationalityPlaceHolderModel("Chinese", new Point(0, 75)));
        nationalityPlaceHolderModels.Add(new NationalityPlaceHolderModel("Korean", new Point(55, 0)));
        nationalityPlaceHolderModels.Add(new NationalityPlaceHolderModel("Thai", new Point(55, 75)));
        ListOfImages.Add(new("Face1.jpg", "Japanese"));
        ListOfImages.Add(new("Face2.jpg", "Korean"));
        ListOfImages.Add(new("Face3.jpg", "Thai"));
        ListOfImages.Add(new("Face4.jpg", "Japanese"));
        ListOfImages.Add(new("Face5.jpg", "Chinese"));
        ListOfImages.Add(new("Face6.jpg", "Korean"));
        ListOfImages.Add(new("Face7.jpg", "Japanese"));
        ListOfImages.Add(new("Face8.jpg", "Chinese"));
        ListOfImages.Add(new("Face9.jpg", "Japanese"));
        ListOfImages.Add(new("Face10.jpg", "Chinese"));
    }

    

    private async void SelectNewFacePhoto()
    {

        SelectedImage = ListOfImages.FirstOrDefault(x => !x.Checked) ?? default;

        if (SelectedImage is null)
        {
            var lst = await localStorage.GetItemAsync<List<int>>("NFG_Top") ?? new List<int>();
            lst.Add(Points);
            await InsertNewHighScore(lst);

            nav.NavigateTo("\\");
            return;
        }

        SelectedImage.Checked = true; // Because Class is a reference type, when you change an object, its collection will see its new value. Therefore we do not need to update collection.
        StateHasChanged();
        await StartnewFacePhoto();
    }

    private async Task InsertNewHighScore(List<int> lst)
    {
        lst.Sort();
        lst.Reverse();
        int count = (lst.Count > 5) ? 5 : lst.Count;
        lst = lst.Take(count).ToList();
        await StoreInLocalStorage(lst);

    }
    private async Task StoreInLocalStorage(List<int> lst)
    {
        await localStorage.SetItemAsync("NFG_Top", lst);
    }
    private async Task StartnewFacePhoto()
        => await ijs.InvokeVoidAsync("StartAnimation", dotNetReference, "ImagePlaceHolderId", 3000);
    #endregion



}
