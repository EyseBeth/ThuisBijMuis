using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    public static class ExtensionMethods {
        /// <summary>
        /// This extension method modifies the rectangle passed through to increase or decrease the x,y, width or height.
        /// This is used to keep custom inspector/windows clean
        /// By utilizing optional parameters only the requested changes are required to be passed through
        /// </summary>
        /// <param name="r">The rectangle meant to be modified</param>
        /// <param name="x">Modifies the horizontal position</param>
        /// <param name="y">Modifies the vertical position</param>
        /// <param name="w">Modifies the width</param>
        /// <param name="h">Modifies the height</param>
        /// <returns>Returns the modified rectangle</returns>
        public static ref Rect Add(this ref Rect r, float x = 0f, float y = 0f, float w = 0f, float h = 0f) {
            r.x += x;
            r.y += y;
            r.width += w;
            r.height += h;
            return ref r;
        }

        /// <summary>
        /// This extension method sets the rectangle passed through to a specified x,y, width and / or height.
        /// This is used to keep custom inspector/windows clean
        /// By utilizing optional parameters only the requested changes are required to be passed through
        /// Only the parameters given with a value are set
        /// </summary>
        /// <param name="r">The rectangle meant to be modified</param>
        /// <param name="x">Sets the horizontal position</param>
        /// <param name="y">Sets the vertical position</param>
        /// <param name="w">Sets the width</param>
        /// <param name="h">Sets the height</param>
        /// <returns>Returns the modified rectangle</returns>
        public static ref Rect Set(this ref Rect r, float? x = null, float? y = null, float? w = null, float? h = null) {
            if (x.HasValue) r.x = x.Value;
            if (y.HasValue) r.y = y.Value;
            if (w.HasValue) r.width = w.Value;
            if (h.HasValue) r.height = h.Value;
            return ref r;
        }
    }
}
