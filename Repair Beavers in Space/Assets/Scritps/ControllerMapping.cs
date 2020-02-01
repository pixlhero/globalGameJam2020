using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerMapping
{
    public enum BeaverType
    {
        RED,
        GREEN,
        BLUE,
        YELLOW
    }

    [HideInInspector]
    public static int NumberOfRegisteredPlayers = 0;

    private static Dictionary<int, BeaverType> mappingDict = new Dictionary<int, BeaverType>();
    private static Dictionary<BeaverType, int> reverseDict = new Dictionary<BeaverType, int>();

    public static void SetMapping(int controllerID, BeaverType beaverType)
    {
        NumberOfRegisteredPlayers++;
        mappingDict.Add(controllerID, beaverType);
        reverseDict.Add(beaverType, controllerID);
    }

    public static BeaverType GetNextAvailableType()
    {
        return (BeaverType)NumberOfRegisteredPlayers;
    }

    public static bool HasMapping(int controllerID)
    {
        return mappingDict.ContainsKey(controllerID);
    }

    public static bool HasMapping(BeaverType beaverType)
    {
        return reverseDict.ContainsKey(beaverType);
    }

    public static bool TryGetBeaver(int controllerID, out BeaverType beaverType)
    {
        return mappingDict.TryGetValue(controllerID, out beaverType);
    }

    public static bool TryGetID(BeaverType beaverType, out int controllerID)
    {
        return reverseDict.TryGetValue(beaverType, out controllerID);
    }
}
