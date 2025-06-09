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
    [SerializeField] UICanvasLobby canvasLobby;

    private void Reset()
    {
        canvasLobby = GetComponent<UICanvasLobby>();
    }

    void Awake()
    {
        canvasLobby.Initialization();
    }
}
