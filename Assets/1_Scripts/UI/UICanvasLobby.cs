using System;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
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

    [SerializeField] private UICharacterBag characterBag;

    private void Reset()
    {
        // Lobby
        btnBack = transform.FindChildByName<Button>("Btn_Back");
        characterBag = transform.FindChildByName<UICharacterBag>("Group_Character");
        
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
        // Lobby
        btnBack.gameObject.SetActive(false);
        characterBag.Initialization();
        
        // Information
        tmpNickName.text = GameManager.Instance.lobbyPlayerData.Nickname;
        UpdateCharNameText();
        tmpLevel.text = $"Lv. {GameManager.Instance.lobbyPlayerData.Level.ToString()}";
        tmpGold.text = $"{GameManager.Instance.lobbyPlayerData.Gold.ToString()} G";
        
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
        btnBack.gameObject.SetActive(true);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(() =>
        {
            statusPopup.Close();
            btnBack.gameObject.SetActive(false);
        });
    }
    
    private void OpenInventoryPopup()
    {
        inventoryPopup.Open();
        btnBack.gameObject.SetActive(true);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(() =>
        {
            inventoryPopup.Close();
            btnBack.gameObject.SetActive(false);
        });
    }

    public void UpdateCharNameText()
    {
        tmpCharName.text = GameManager.Instance.lobbyPlayerData.characterData.charName;
    }
}
