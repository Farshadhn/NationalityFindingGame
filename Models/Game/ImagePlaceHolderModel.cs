namespace NationalityFindingGame.Models.Game;

public record class ImagePlaceHolderModel
{
    public string ImageAddress { get; set; }
    public ImagePlaceHolderModel()
    {

    }
    public ImagePlaceHolderModel(string imageAddress, string nationality)
    {
        ImageAddress = imageAddress;
        Nationality = nationality;
    }

    public string Nationality { get; set; }
    public bool Checked { get; set; } = false;
    public bool Computed { get; set; } = false;

}