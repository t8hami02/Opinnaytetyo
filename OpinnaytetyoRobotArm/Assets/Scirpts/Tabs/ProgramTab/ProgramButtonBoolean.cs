using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramButtonBoolean : MonoBehaviour
{
    public bool isSet = false;

    public bool getBooleanValue()
    {
        return isSet;
    }
    public void ChangeBooleanToTrue() { 

        isSet = true;
    }

    public void ChangeBooleanToFalse()
    {
        isSet = false;
    }

}
