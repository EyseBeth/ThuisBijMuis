
using UnityEditor;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public static class NewInteractable {
        private static float windowHeight = 500, windowWidth = 335;

        public static ref Rect Add(this ref Rect r, float x = 0f, float y = 0f, float w = 0f, float h = 0f) {
            r.x += x;
            r.y += y;
            r.width += w;
            r.height += h;
            return ref r;
        }

        public static ref Rect AddMinMax(this ref Rect r, float xMin = 0f, float xMax = 0f, float yMin = 0f,
            float yMax = 0f) {
            r.xMin += xMin;
            r.xMax += xMax;
            r.yMin += yMin;
            r.yMax += yMax;
            return ref r;
        }

        public static ref Rect Set(this ref Rect r, float? x = null, float? y = null, float? w = null, float? h = null) {
            if (x.HasValue) r.x = x.Value;
            if (y.HasValue) r.y = y.Value;
            if (w.HasValue) r.width = w.Value;
            if (h.HasValue) r.height = h.Value;
            return ref r;
        }

        [MenuItem("GameObject/2D Object/New Interactable Item", false, 0)]
        static void Init() {
            EditorWindow window = EditorWindow.GetWindow(typeof(InteractableItem), true, "New Interactable Item");
            window.maxSize = new Vector2(windowWidth, windowHeight);
            window.minSize = window.maxSize;
        }
    }


    public class InteractableItem : EditorWindow {
        private Transform parent;
        private Object sprite;
        private const int TextureSize = 65, ButtonWidth = 100, ButtonHeight = 25, LongButtonWidth = 200;
        private bool click, drag, drop;

        void OnGUI() {
            Rect currRect = new Rect(7.5f, 7.5f, Screen.width / 1.5f, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(currRect, "Choose a Sprite");
            currRect.Set(Screen.width - TextureSize - 5, 2.5f, TextureSize, TextureSize);
            sprite = EditorGUI.ObjectField(currRect, sprite, typeof(Sprite), true);
            //currRect.Set(Screen.width / 1.5f + 7.5f, 2.5f, TextureSize, TextureSize);
            if (!sprite) return;
            currRect.Set(2.5f, 5, h: ButtonHeight, w: ButtonWidth).Add(y: TextureSize);
            click = EditorGUI.Foldout(currRect, click, "Clickable Item");
            if (click) {
                drop = drag = false;
            }
            currRect.Set((Screen.width / 2) - (ButtonWidth / 2));
            drag = EditorGUI.Foldout(currRect, drag, "Draggable Item");
            if (drag) {
                click = drop = false;
                if (GUI.Button(
                    new Rect(Screen.width - LongButtonWidth - 5, Screen.height - ButtonHeight - 5, LongButtonWidth,
                        ButtonHeight), "Create A New Draggable Item")) {
                    GameObject newObject = new GameObject("New Draggable Item", typeof(SpriteRenderer), typeof(BoxCollider), typeof(Rigidbody), typeof(DraggableItem));
                    newObject.GetComponent<Rigidbody>().isKinematic = true;
                    newObject.GetComponent<SpriteRenderer>().sprite = sprite as Sprite;
                    newObject.transform.parent = parent;
                }
            }
            currRect.Set(Screen.width - ButtonWidth - 5f);
            drop = EditorGUI.Foldout(currRect, drop, "Droppable Item");
            if (drop) {
                click = drag = false;
            }
            //    GUILayout.BeginHorizontal();
            //    var temp = AssetPreview.GetAssetPreview(sprite);
            //    EditorGUI.DrawPreviewTexture(currRect, temp);
            //    GUILayout.EndHorizontal();
            //
            //    EditorGUILayout.Separator();
            //} else {
            //    GUILayout.BeginHorizontal();
            //    EditorGUI.HelpBox(currRect, "Please select a texture.", MessageType.Error);
            //    GUILayout.EndHorizontal();
            //    EditorGUILayout.Separator();
            //}

        }

        private void OnEnable() {
            parent = Selection.activeTransform;
        }
    }
}