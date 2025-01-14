namespace record_store.Entities
{
    public record AlbumDTO
    {
        string Title = "";
        string Artist = "";
        string Label = "";
        DateOnly ReleaseDate;
        IEnumerable<Genre> Genres = [];
    }
}
