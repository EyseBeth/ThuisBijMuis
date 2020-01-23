using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    /// <summary>
    /// Used on page 3, checks which of the colours has been selected.
    /// </summary>
    public class BoolChanger : MonoBehaviour, IClickable
    {
        [SerializeField] private string boolName;

        private VariableKeeper variableKeeper;

        public void Start() => variableKeeper = GameObject.Find("BookParent").GetComponent<VariableKeeper>();

        public void ExecuteCustomBehaviour() => ChangeBool();

        private void ChangeBool()
        {
            switch (boolName)
            {
                case "red":
                    variableKeeper.ClrSelected = true;
                    variableKeeper.Red = true;
                    variableKeeper.Blue = false;
                    variableKeeper.Yellow = false;
                    break;
                case "blue":
                    variableKeeper.ClrSelected = true;
                    variableKeeper.Blue = true;
                    variableKeeper.Red = false;
                    variableKeeper.Yellow = false;
                    break;
                case "yellow":
                    variableKeeper.ClrSelected = true;
                    variableKeeper.Yellow = true;
                    variableKeeper.Red = false;
                    variableKeeper.Blue = false;
                    break;
            }
        }
    }
}
