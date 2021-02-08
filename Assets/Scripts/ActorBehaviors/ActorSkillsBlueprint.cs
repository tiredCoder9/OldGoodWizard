using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="DataPattern/ActorSkillSet")]
public class ActorSkillsBlueprint : ScriptableObject
{
    public int Power=5;
    public int Endurance = 5;
    public int Sanity = 5;
    public int Speed = 5;

    public int Health = 500;
    public int Mind = 500;

    public int Luck = 5;
    public int Trade = 5;
    public int Speechcraft = 5;
    public int Wisdom = 5;


    public ActorSkills getClone()
    {
        Power power = new Power(Power);
        Endurance endurance = new Endurance(Endurance);
        Sanity sanity = new Sanity(Sanity);
        Speed speed = new Speed(Speed);

        Health health = new Health(Health);
        Mind mind = new Mind(Mind);

        Luck luck = new Luck(Luck);
        Trade trade = new Trade(Trade);
        Speechcraft speechcraft = new Speechcraft(Speechcraft);
        Wisdom wisdom = new Wisdom(Wisdom);

        List<SkillAttribute> attributes = new List<SkillAttribute>();

        attributes.Add(power);
        attributes.Add(endurance);
        attributes.Add(sanity);
        attributes.Add(speed);

        attributes.Add(luck);
        attributes.Add(trade);
        attributes.Add(speechcraft);
        attributes.Add(wisdom);

        List<ResourceAttribute> resources = new List<ResourceAttribute>();

        resources.Add(health);
        resources.Add(mind);

        return new ActorSkills(attributes, resources);
    }
}
