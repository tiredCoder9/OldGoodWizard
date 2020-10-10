using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class JorneyDataCreator : MonoBehaviour
{
    [SerializeField]
    public JorneyData jorneyToCreate;
    public void create()
    {
        string saveJson = JsonUtility.ToJson(jorneyToCreate);
        DataController.tryWriteSaveInFile(jorneyToCreate.id+".jor", JorneyDataManager.jorneysFolderPath, saveJson);
    }


    
}

[CustomEditor(typeof(JorneyDataCreator))]
public class JorneyDataCreatorEditor : Editor 
{
    JorneyDataCreator creator;
    private void OnEnable()
    {
        creator = (JorneyDataCreator)target;

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create jorney data"))
        {
            creator.create();
        }
    }
}
