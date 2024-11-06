namespace KRM_Events_API.Interfaces
{
    public interface IEventRepository
    {

        Task<bool> EventExists(int id);

    }
}
