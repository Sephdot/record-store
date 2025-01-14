namespace record_store.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Label { get; set; } = "";
        public DateOnly ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; } = [];
    }
}
