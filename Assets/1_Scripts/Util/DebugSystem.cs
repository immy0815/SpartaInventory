using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyDebug
{
#if UNITY_EDITOR
    public static void Log(string msg) => Debug.Log(msg);
    public static void LogWarning(string msg) => Debug.LogWarning(msg);
    public static void LogError(string msg) => Debug.LogError(msg);
#endif
}

public class DebugSystem : MonoBehaviour
{
    
}
