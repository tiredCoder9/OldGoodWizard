using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    bool getDirty();
    void setDirty(bool value);

    void save();
    void delete();
}
