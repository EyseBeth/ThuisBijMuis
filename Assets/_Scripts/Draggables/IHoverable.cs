using System.Collections.Generic;

namespace ThuisBijMuis.Games.Interactables
{
    public interface IHoverable
    {
        List<DroppableTags> Tags { get; }

        void ActivateHover(List<DroppableTags> tags);
    }
}
