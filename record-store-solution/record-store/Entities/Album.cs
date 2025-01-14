namespace record_store.Entities
{
    public record Album
    {
        public int Id;
        public string Title = "";
        public string Artist = "";
        public string Label = "";
        public DateOnly ReleaseDate;
        public IEnumerable<Genre> Genres = [];
    }
}
