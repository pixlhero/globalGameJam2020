using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMapping : MonoBehaviour
{
    public enum BeaverType
    {
        RED,
        GREEN,
        BLUE,
        YELLOW
    }

    private Dictionary<int, BeaverType> mappingDict = new Dictionary<int, BeaverType>();
    private Dictionary<BeaverType, int> reverseDict = new Dictionary<BeaverType, int>();

    public void SetMapping(int controllerID, BeaverType beaverType)
    {
        mappingDict.Add(controllerID, beaverType);
        reverseDict.Add(beaverType, controllerID);
    }

    public bool HasMapping(int controllerID)
    {
        return mappingDict.ContainsKey(controllerID);
    }

    public bool HasMapping(BeaverType beaverType)
    {
        return reverseDict.ContainsKey(beaverType);
    }

    public bool TryGetBeaver(int controllerID, out BeaverType beaverType)
    {
        return mappingDict.TryGetValue(controllerID, out beaverType);
    }

    public bool TryGetID(BeaverType beaverType, out int controllerID)
    {
        return reverseDict.TryGetValue(beaverType, out controllerID);
    }
}
