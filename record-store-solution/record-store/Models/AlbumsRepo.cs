namespace record_store.Models
{
    public interface IAlbumsRepo
    {
        IEnumerable<Album>
    }
    public class AlbumsRepo : IAlbumsRepo
    {
    }
}
