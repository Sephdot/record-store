namespace record_store.Entities
{
    public record Album
    {
        int Id;
        string Title = "";
        string Artist = "";
        string Label = "";
        DateOnly ReleaseDate;
        IEnumerable<Genre> Genres = [];
    }
}
