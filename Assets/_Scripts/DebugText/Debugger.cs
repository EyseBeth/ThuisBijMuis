using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ThuisBijMuis.Games
{
#pragma warning disable 0649
    public class Debugger : MonoBehaviour
    {
        [SerializeField] private Text debugText;

        private List<object> messages = new List<object>();

        public static Debugger Singleton { get; private set; }

        private void Awake() => Singleton = this;

        private void ChangeText(object message) => debugText.text = message.ToString();
        
        public void AddText(object message)
        {
            MessageCheck();
            messages.Add(message.ToString() + "\n");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in messages) sb.AppendLine(item.ToString());

            ChangeText(sb.ToString());
        }

        private void MessageCheck()
        {
            if (messages.Count > 9) messages.RemoveAt(0);
        }
    } 
}
