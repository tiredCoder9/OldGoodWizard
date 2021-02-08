using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourcableAttribute
{
    int getCurrent(ActorSkills actor);

    void restoreCurrent(ActorSkills actor);

    void AddToCurrent(ActorSkills actor, int value);

    bool isEmpty(ActorSkills actor);
    
}
