namespace ThuisBijMuis.Games.PageSliding
{
    public interface IPageActivatable
    {
        int PageNumber { get; set; }

        void CheckPage(int pageNumber);
    }
}