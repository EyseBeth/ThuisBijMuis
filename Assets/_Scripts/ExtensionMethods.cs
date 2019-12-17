using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public static class ExtensionMethods
    {
        public static ref Rect Add(this ref Rect r, float x = 0f, float y = 0f, float w = 0f, float h = 0f)
        {
            r.x += x;
            r.y += y;
            r.width += w;
            r.height += h;
            return ref r;
        }

        public static ref Rect Set(this ref Rect r, float? x = null, float? y = null, float? w = null, float? h = null)
        {
            if (x.HasValue) r.x = x.Value;
            if (y.HasValue) r.y = y.Value;
            if (w.HasValue) r.width = w.Value;
            if (h.HasValue) r.height = h.Value;
            return ref r;
        }
    }
}
