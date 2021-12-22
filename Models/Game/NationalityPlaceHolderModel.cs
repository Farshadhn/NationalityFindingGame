using System.Drawing;

namespace NationalityFindingGame.Models.Game;

public struct NationalityPlaceHolderModel
{
    public Point Position { get; set; } = new Point(0, 0); 
    public string Content { get; set; } = "Content";

    public NationalityPlaceHolderModel(string content)  
    {
        Content = content;
    }

    public NationalityPlaceHolderModel(string content, Point position)  
    {
        Content = content;
        Position = position;
    }
}

