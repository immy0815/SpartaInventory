using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasLobby : MonoBehaviour, IGUI
{
    [Header("====[Lobby]")]
    [SerializeField] private Button btnBack;
    
    [Header("====[Information]")]
    [SerializeField] private TextMeshProUGUI tmpNickName;
    [SerializeField] private TextMeshProUGUI tmpCharName;
    [SerializeField] private TextMeshProUGUI tmpLevel;
    [SerializeField] private TextMeshProUGUI tmpGold;

    [Header("====[Status]")]
    [SerializeField] private Button btnStatus;
    [SerializeField] private UIStatus statusPopup;
    
    [Header("====[Inventory]")]
    [SerializeField] private Button btnInventory;
    [SerializeField] private UIInventory inventoryPopup;

    private void Reset()
    {
        // Lobby
        btnBack = transform.FindChildByName<Button>("Btn_Back");
        
        // Information
        tmpNickName = transform.FindChildByName<TextMeshProUGUI>("Tmp_NickName");
        tmpCharName = transform.FindChildByName<TextMeshProUGUI>("Tmp_CharName");
        tmpLevel = transform.FindChildByName<TextMeshProUGUI>("Tmp_Level");
        tmpGold = transform.FindChildByName<TextMeshProUGUI>("Tmp_Gold");
        
        // Status
        btnStatus = transform.FindChildByName<Button>("Btn_Status");
        statusPopup = GetComponentInChildren<UIStatus>();
        
        // Inventory
        btnInventory = transform.FindChildByName<Button>("Btn_Inventory");
        inventoryPopup = GetComponentInChildren<UIInventory>();
    }

    public void Initialization()
    {
        // Information
        tmpNickName.text = GameManager.Instance.lobbyPlayerData.Nickname;
        tmpCharName.text = GameManager.Instance.lobbyPlayerData.characterData.charName;
        tmpLevel.text = GameManager.Instance.lobbyPlayerData.Level.ToString();
        tmpGold.text = GameManager.Instance.lobbyPlayerData.Gold.ToString();
        
        // Status
        btnStatus.onClick.RemoveAllListeners();
        btnStatus.onClick.AddListener(OpenStatusPopup);
        statusPopup.Initialization();
        
        // Inventory
        btnInventory.onClick.RemoveAllListeners();
        btnInventory.onClick.AddListener(OpenInventoryPopup);
        inventoryPopup.Initialization();
        
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
    
    private void OpenInventoryPopup()
    {
        inventoryPopup.Open();
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(inventoryPopup.Close);
    }
}
