using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

[CreateAssetMenu][System.Serializable]
public class AdventureTextPattern : ScriptableObject, Identifyable
{
    public enum DescriptionType { encounter, ending }

    [JsonProperty] private Id _id;

    [SerializeField] [JsonIgnore] private string text;
    [JsonIgnore] public Id Id { get { return _id; } }
    [JsonIgnore] public DescriptionType type;
    [JsonIgnore] public string Text { get { return text; } }


}
