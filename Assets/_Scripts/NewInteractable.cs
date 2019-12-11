
using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using UnityEditor;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public static class NewInteractable {
        private const float WindowHeight = 400, WindowWidth = 335;

        public static ref Rect Add(this ref Rect r, float x = 0f, float y = 0f, float w = 0f, float h = 0f) {
            r.x += x;
            r.y += y;
            r.width += w;
            r.height += h;
            return ref r;
        }

        public static ref Rect Set(this ref Rect r, float? x = null, float? y = null, float? w = null, float? h = null) {
            if (x.HasValue) r.x = x.Value;
            if (y.HasValue) r.y = y.Value;
            if (w.HasValue) r.width = w.Value;
            if (h.HasValue) r.height = h.Value;
            return ref r;
        }

        [MenuItem("GameObject/2D Object/Interactable Item", false, 0)]
        private static void Init() {
            EditorWindow window = EditorWindow.GetWindow(typeof(InteractableItem), true, "New Interactable Item");
            window.maxSize = new Vector2(WindowWidth, WindowHeight);
            window.minSize = window.maxSize;
        }
    }


    public class InteractableItem : EditorWindow {
        private Transform parent;
        private Object sprite;
        private const int TextureSize = 65, ButtonWidth = 100, ButtonHeight = 25, LongButtonWidth = 200, DoubleLineHeight = 36, TextWidth = 175, LabelWidth = 145;
        private const float SideOffset = 2.5f, LargeSideOffset = 7.5f;
        private bool click, drag, drop;
        private bool animator, sound;
        private string itemName;

        private void OnGUI() {
            Debug.Log(EditorGUIUtility.singleLineHeight);
            Rect currRect = new Rect(LargeSideOffset, LargeSideOffset, Screen.width / 1.5f, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(currRect, "Choose a Sprite");
            currRect.Set(Screen.width - TextureSize - 5, SideOffset, TextureSize, TextureSize);
            sprite = EditorGUI.ObjectField(currRect, sprite, typeof(Sprite), true);
            if (!sprite) return;
            currRect.Set(SideOffset, EditorGUIUtility.singleLineHeight, w:TextWidth, EditorGUIUtility.singleLineHeight).Add(y: TextureSize);
            EditorGUI.LabelField(currRect,"What is the item name?");
            itemName = EditorGUI.TextField(currRect.Add(LabelWidth),itemName);
            click = EditorGUI.Foldout(currRect.Add(-LabelWidth, y: DoubleLineHeight).Set(h: ButtonHeight, w: ButtonWidth), click, "Clickable Item");
            if (click) {
                drop = drag = false;
                Rect choiceRect = currRect;
                animator = GUI.Toggle(choiceRect.Add(LargeSideOffset, DoubleLineHeight).Set(w:250), animator, "Does the item have an animation?");
                sound = GUI.Toggle(choiceRect.Add(y: DoubleLineHeight).Set(w: 250), sound, "Does the item make a sound?");
                if (GUI.Button(
                    new Rect(Screen.width - LongButtonWidth - 5, Screen.height - ButtonHeight - 5, LongButtonWidth,
                        ButtonHeight), "Create A New Clickable Item")) {
                    GameObject newObject = new GameObject(itemName, typeof(SpriteRenderer), typeof(BoxCollider), typeof(ClickableItem));
                    if (animator) {
                        newObject.AddComponent<Animator>();
                        newObject.AddComponent<ClickableAnimation>();
                    }
                    if (sound) {
                        newObject.AddComponent<AudioSource>();
                        newObject.AddComponent<ClickableAudio>();
                    }
                    newObject.GetComponent<SpriteRenderer>().sprite = sprite as Sprite;
                    newObject.transform.parent = parent;
                    if(animator ^ sound) EditorUtility.DisplayDialog("Attention!",
                        "Do not forget to add a" + (animator ? "n animation" : null) + (sound ? " sound" : null), "Ok");
                    if (animator && sound) EditorUtility.DisplayDialog("Attention!",
                        "Do not forget to add an animation and a sound", "Ok");
                    Close();
                }
            }
            currRect.Set((Screen.width / 2) - (ButtonWidth / 2));
            drag = EditorGUI.Foldout(currRect, drag, "Draggable Item");
            if (drag) {
                click = drop = false;
                if (GUI.Button(
                    new Rect(Screen.width - LongButtonWidth - 5, Screen.height - ButtonHeight - 5, LongButtonWidth,
                        ButtonHeight), "Create A New Draggable Item")) {
                    GameObject newObject = new GameObject(itemName, typeof(SpriteRenderer),
                        typeof(BoxCollider), typeof(Rigidbody), typeof(DraggableItem));
                    newObject.GetComponent<Rigidbody>().isKinematic = true;
                    newObject.GetComponent<SpriteRenderer>().sprite = sprite as Sprite;
                    newObject.transform.parent = parent; 
                    EditorUtility.DisplayDialog("Attention!", "Do not forget to add the draggable tags", "Ok");
                    Close();
                }
            }
            currRect.Set(Screen.width - ButtonWidth - 5f);
            drop = EditorGUI.Foldout(currRect, drop, "Drop Zone");
            if (drop) {
                click = drag = false;
                if (GUI.Button(
                    new Rect(Screen.width - LongButtonWidth - 5, Screen.height - ButtonHeight - 5, LongButtonWidth,
                        ButtonHeight), "Create A New Draggable Item")) {
                    GameObject newObject = new GameObject(itemName, typeof(SpriteRenderer),
                        typeof(BoxCollider), typeof(DropZone));
                    newObject.GetComponent<Rigidbody>().isKinematic = true;
                    newObject.GetComponent<SpriteRenderer>().sprite = sprite as Sprite;
                    newObject.transform.parent = parent;
                    EditorUtility.DisplayDialog("Attention!", "Do not forget to add the accepted draggable tags", "Ok");
                    Close();
                }
            }
        }

        private void OnEnable() {
            parent = Selection.activeTransform;
        }
    }
}