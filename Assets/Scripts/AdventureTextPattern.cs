using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "NewText", menuName = "Content/Text/AdventureText")][System.Serializable]
public class AdventureTextPattern : ScriptableObject, Identifyable
{
    public enum DescriptionType { encounter, ending }

    [JsonProperty] private Id _id;

    [SerializeField] [JsonIgnore] [TextArea] private string text;
    [JsonIgnore] public Id Id { get { return _id; } }
    [JsonIgnore] public DescriptionType type;
    [JsonIgnore] public string Text { get { return text; } }

    public string GenerateText(Entity[] entities, JorneyData data)
    {
        if (text.Contains("%enemies%"))
        {
            string entitiesEnum=string.Empty;
            
            for(int i=0; i< entities.Length; i++)
            {
                entitiesEnum += entities[i].EntityName;
                if (i != entities.Length - 1) entitiesEnum += ", ";
            }

            text.Replace("%enemies%", entitiesEnum);
        }
        return text;
    }
}
