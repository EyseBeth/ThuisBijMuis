using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    //Every IDroppable item needs a list of tags it accepts and a function to check the tags
    public interface IDroppable {
        bool CheckTags(List<DroppableTags> tags);
        List<DroppableTags> Tags { get; }

    }
}
