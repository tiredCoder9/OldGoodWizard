using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(TropeManager))]
public class TropeManagerCustomEditor : Editor
{
    private TropeManager tropeManager;
    string availableIDs;
    public override void OnInspectorGUI()
    {

    }
}
