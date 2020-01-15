using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public interface IHoverable
    {
        List<DroppableTags> Tags { get; }
        void ActivateHover(List<DroppableTags> tags);
    }
}
