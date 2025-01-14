namespace record_store.Entities
{
    public record AlbumDTO
    {
        public string Title = "";
        public string Artist = "";
        public string Label = "";
        public DateOnly ReleaseDate;
        public List<Genre> Genres = [];
    }
}
