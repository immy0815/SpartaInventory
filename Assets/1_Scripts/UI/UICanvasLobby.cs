using System;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasLobby : MonoBehaviour, IGUI
{
    [SerializeField] private UIStatus statusPopup;

    [SerializeField] private Button btnStatus;
    [SerializeField] private Button btnInventory;
    
    [SerializeField] private Button btnBack;

    private void Reset()
    {
        statusPopup = GetComponentInChildren<UIStatus>();

        btnStatus = transform.FindChildByName<Button>("Btn_Status");
        btnInventory = transform.FindChildByName<Button>("Btn_Inventory");
        
        btnBack = transform.FindChildByName<Button>("Btn_Back");
    }

    public void Initialization()
    {
        statusPopup.Initialization();
        
        btnStatus.onClick.RemoveAllListeners();
        btnStatus.onClick.AddListener(OpenStatusPopup);
        
        // 인벤토리 추가해
        // 플레이어 추가해
    }
    
    public void Open() {}
    public void Close() {}

    private void OpenStatusPopup()
    {
        statusPopup.Open();
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(statusPopup.Close);
    }
    
}
