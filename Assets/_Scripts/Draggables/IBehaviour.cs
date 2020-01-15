using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public interface IDropBehaviour
    {
        void FixedUpdate();
        bool IsActive { get; set; }

        void EndBehaviour();
    }
}
