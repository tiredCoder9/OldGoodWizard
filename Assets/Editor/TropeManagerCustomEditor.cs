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
        tropeManager = (TropeManager)target;


        if (GUILayout.Button("Update tropes IDs"))
        {
            availableIDs = string.Empty;
            Trope[] tropes = Resources.FindObjectsOfTypeAll<Trope>();

            Debug.Log("TROPE_MANAGER: all tropes list");
            long i = 1;
            foreach (var trope in tropes.OrderBy(trope => trope.id))
            {
                Debug.Log(trope.id + "-" + i);
                while (i != trope.id)
                {
                    availableIDs += string.Format(", [{0}]", i);
                    i++;
                }

                i++;
            }
            availableIDs += string.Format(", [{0}]", tropeManager.lastTropeId);



        }
        EditorGUILayout.LabelField("Available ID: " + availableIDs);
        this.Repaint();
    }
}
