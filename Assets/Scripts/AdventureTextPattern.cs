using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu][System.Serializable]
public class AdventureTextPattern : ScriptableObject, Identifyable
{
    //TODO: переписать
    [SerializeField] private Id _id;
    public Id Id { get { return _id; } }

    public enum DescriptionType { encounter, ending}
    public DescriptionType type;


    [SerializeField][TextArea] private string text;

    public string getText()
    {
        return text;
    }
    

}
