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
        JorneyData data = new JorneyData(jorneyToCreate);

        FileNameFormat format = new FileNameFormat("dt_", string.Empty);
        JsonTool.save<JorneyData>(data, data.Id.get(), Application.persistentDataPath + "/" + typeof(JorneyData).Name + "s", new FileNameFormat("dt_", string.Empty, "JorneyData"));
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
