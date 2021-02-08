using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersistentController : MonoBehaviour
{
    public abstract PersistentControllerData GetControllerData();
    public abstract void SetControllerData(PersistentControllerData data);
    public abstract void CreateControllerData();
}
