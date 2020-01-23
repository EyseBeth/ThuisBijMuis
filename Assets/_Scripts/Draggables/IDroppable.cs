using System.Collections.Generic;

namespace ThuisBijMuis.Games.Interactables
{
    // Every IDroppable item needs a list of tags it accepts and a function to check the tags.
    public interface IDroppable
    {
        List<DroppableTags> Tags { get; }

        bool CheckTags(List<DroppableTags> tags);
    }
}
