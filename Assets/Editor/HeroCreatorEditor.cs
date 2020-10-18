using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HeroCreator))]
public class HeroCreatorEditor : Editor
{
    HeroCreator creator;
    private void OnEnable()
    {
        creator = (HeroCreator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Create hero"))
        {
            creator.createHero();
            Debug.Log("HERO CREATOR: New hero "+creator.hero.getName()+" id:"+creator.hero.id+" created!");
        }
    }
}
