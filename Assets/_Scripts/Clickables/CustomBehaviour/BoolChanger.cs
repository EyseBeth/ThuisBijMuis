﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Used on page 3, checks which of the colours has been selected.
/// </summary>
namespace ThuisBijMuis.Games.Interactables.CustomBehaviours {
#pragma warning disable 0649
    public class BoolChanger : MonoBehaviour, IClickable
    {
        public string boolName;
        VariableKeeper variableKeeper;

        public void Start()
        {
            variableKeeper = GameObject.Find("BookParent").GetComponent<VariableKeeper>();
        }
        public void ExecuteCustomBehaviour()
        {
            ChangeBool();
        }

        private void ChangeBool()
        {
            if (boolName == "red")
            {
                variableKeeper.clrSelected= true;
                variableKeeper.red = true;
                variableKeeper.blue = false;
                variableKeeper.yellow = false;
            }
            if (boolName == "blue")
            {
                variableKeeper.clrSelected = true;
                variableKeeper.blue = true;
                variableKeeper.yellow = false;
                variableKeeper.red = false;
            }
            if (boolName == "yellow")
            {
                variableKeeper.clrSelected = true;
                variableKeeper.yellow = true;
                variableKeeper.red = false;
                variableKeeper.blue = false;
            }
        }
    }
}
