using System;
using UnityEngine;

public interface IGUI
{
    public void Initialization();
    public void Open();
    public void Close();
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                MyDebug.LogError("UIManager Instance Not Found");
                return null;
            }
            return instance;
        }
    }
    
    [SerializeField] UICanvasLobby canvasLobby;

    private void Reset()
    {
        canvasLobby = GetComponentInChildren<UICanvasLobby>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        canvasLobby.Initialization();
    }

    public void UpdateCharNameText() => canvasLobby.UpdateCharNameText();
}
