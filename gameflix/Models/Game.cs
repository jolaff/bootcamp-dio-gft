using gameflix.Enum;

namespace gameflix.Models;

public class Game : EntityBase
{
    public Game(int id,
                string title,
                List<EGenre> genres,
    string description,
                string developer,
                int year,
                ERating rating,
                string alias
                )
    {
        this.Id = id;
        this.Title = title;
        this.Genres = genres;
        this.Description = description;
        this.Developer = developer;
        this.Year = year;
        this.Rating = rating;
        this.Alias = alias;
        this.Removed = false;
    }

    private string Title { get; set; }
    private List<EGenre> Genres { get; set; }
    private string Description { get; set; }
    private string Developer { get; set; }
    private int Year { get; set; }
    private ERating Rating { get; set; }
    private bool Removed { get; set; }
    private string Alias { get; set; }

    public int GetId() => Id;
    public string GetTitle() => Title;

    public string GetAlias() => Alias;

    public void AddGenre(params EGenre[] genres)
    {
        foreach (EGenre genre in genres)
        {
            Genres.Add(genre);
        }
    }

    public void Remove() => Removed = true;

    public string Details()
    {
        return $@"+--------------------------------------------------------------------------------------------------------------------+
     |{"",15} {"",-100}|        
     |{Alias,15} {Title,-100}|
     |{"",15} {"",-100}|
     |{"Genre:",15} {inlineGenres(),-100}|
     |{"",15} {"",-100}|
     |{"Description:",15} {BreakLine(Description, 100)}|
     |{"",15} {"",-100}|
     |{"Developer:",15} {Developer,-100}|
     |{"",15} {"",-100}|
     |{"Release year:",15} {Year,-100}|
     |{"",15} {"",-100}|
     |{"Rating:",15} {Rating,-100}|
     |{"",15} {"",-100}|     
     +--------------------------------------------------------------------------------------------------------------------+";
    }

    public override string ToString()
    {
        return $@" | Id: {Id,-2} > Alias: {Alias,-10} > Title: {Title,-30} > Genres: {inlineGenres(),-60} |";
    }

    private string inlineGenres() => String.Join(", ", Genres);

    private string BreakLine(string textToBreak, int columns)
    {
        var breakedText = textToBreak.Select((text, size) =>
        {
            if ((size + 1) % columns == 0)
            {
                columns += 116;
                return $"{text}|{Environment.NewLine}     |";
            }
            else
            {
                if (size == (textToBreak.Length - 1))
                {
                    int remainingSpace = (columns - textToBreak.Length) + 1;
                    return "".PadRight(remainingSpace, ' ');
                }
                return text.ToString();
            }
        });

        return string.Join("", breakedText);
    }
}