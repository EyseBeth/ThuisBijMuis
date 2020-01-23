namespace ThuisBijMuis.Games.Interactables
{
    public interface IDropBehaviour
    {
        bool IsActive { get; set; }

        void FixedUpdate();
        void EndBehaviour();
    }
}
