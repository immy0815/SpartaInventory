using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class MyDebug
{
    public static void Log(string msg)
    {
#if UNITY_EDITOR
        Debug.Log(msg);
#endif
    }
    public static void LogWarning(string msg)
    {
#if UNITY_EDITOR
        Debug.LogWarning(msg);
#endif
    }
    public static void LogError(string msg)
    { 
#if UNITY_EDITOR
        Debug.LogError(msg);
#endif
    }
}

public class DebugSystem : EditorWindow  
{
    private string itemTypeName;
    
    [MenuItem("Window/My Debug Tool")]
    public static void ShowWindow()    
    {
        GetWindow<DebugSystem>("Debug Tool");
    }

    void OnGUI()
    {
        if (GUILayout.Button("AddItem"))
        {
            List<ItemData> itemList = new List<ItemData>();
            
            itemList.Add(Resources.Load<ItemData>("ItemData/ArmorData"));
            itemList.Add(Resources.Load<ItemData>("ItemData/BootsData"));
            itemList.Add(Resources.Load<ItemData>("ItemData/GlovesData"));
            itemList.Add(Resources.Load<ItemData>("ItemData/HelmetData"));
            itemList.Add(Resources.Load<ItemData>("ItemData/SwordData"));

            foreach (ItemData data in itemList)
            {
                Item item = new Item(data);
                GameManager.Instance.lobbyPlayerData.AddItem(item);
            }
        }
    }
}
