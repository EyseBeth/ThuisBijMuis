using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public interface IDroppable {
        void CheckTags(DroppableTags[] tags);
        List<string> Tags { get; }

    }
}
