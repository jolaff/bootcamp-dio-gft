using gameflix.Enum;

namespace gameflix.Models;

public class Game : EntityBase
{
    public Game(int id,
                string title,
                string description,
                string developer,
                int year,
                ERating rating
                )
    {
        this.Id = id;
        this.Title = title;
        this.Genres = new List<EGenre>();
        this.Description = description;
        this.Developer = developer;
        this.Year = year;
        this.Rating = rating;
        this.Removed = false;
    }

    private string Title { get; set; }
    private List<EGenre> Genres { get; set; }
    private string Description { get; set; }
    private string Developer { get; set; }
    private int Year { get; set; }
    private ERating Rating { get; set; }
    private bool Removed { get; set; }

    public int GetId() => Id;
    public string GetTitle() => Title;

    public void AddGenre(params EGenre[] genres)
    {
        foreach (EGenre genre in genres)
        {
            Genres.Add(genre);
        }
    }

    public override string ToString()
    {
        return $@"Title: {Title}
Genre: {Genres.Count}
Description: {BreakLine(Description)}
Developer: {Developer}
Release year: {Year}
Rating: {Rating}";
    }

    public void Remove() => Removed = true;

    private string BreakLine(string textToBreak)
    {
        const int COLUMNS = 12;
        var breakedText = textToBreak.Select((text, size) => ((size + 1) % COLUMNS == 0) ? text + Environment.NewLine : text.ToString());
        return string.Join("", breakedText);
    }
}