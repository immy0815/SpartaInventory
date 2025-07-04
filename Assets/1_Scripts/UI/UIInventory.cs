using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour, IGUI
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private TextMeshProUGUI tmpInventoryCount;
    
    [SerializeField] private Transform inventoryRoot;
    [SerializeField] private GameObject origin;
    
    
    private List<GUISlot> inventorySlots;
    
    private void Reset()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        tmpInventoryCount = transform.FindChildByName<TextMeshProUGUI>("Tmp_Count");
        inventoryRoot = transform.FindChildByName<Transform>("Layout_Inventory");
        origin = transform.FindChildByName<GUISlot>("GUI_Slot").gameObject;
    }
    
    public void Initialization()
    {
        canvasGroup.SetAlpha(false);
        inventorySlots = new List<GUISlot>();
    }

    public void Open()
    {
        UpdateInventoryGUI();
        canvasGroup.OpenPopupAnimation(rectTransform, RectTransform.Axis.Horizontal, 500f, -50f);
    }

    public void Close()
    {
        canvasGroup.ClosePopupAnimation(rectTransform, RectTransform.Axis.Horizontal, -50f, 500f);
    }

    private void UpdateInventoryGUI()
    {
        // 비우기 => 이후 DynamicObjectPool로 변경하기
        foreach (var slot in inventorySlots)
        {
            Destroy(slot.gameObject);
        }
        inventorySlots.Clear();
        
        // GameManager에 저장된 로비 플레이어 데이터로 불러오기
        var inventoryItems = GameManager.Instance.lobbyPlayerData.GetInventoryItems();
        
        foreach (var item in inventoryItems)
        {
            GameObject slotObj = Instantiate(origin, inventoryRoot);
            GUISlot slot = slotObj.GetComponent<GUISlot>();
            slot.Show(item);
            slot.SetButtonClick(UpdateInventoryGUI);
            inventorySlots.Add(slot);
        }

        tmpInventoryCount.text = $"<color=#484848>{inventorySlots.Count.ToString("D2")}</color><color=#DEA313>/{GameManager.Instance.lobbyPlayerData.MaxInventorySize.ToString("D2")}</color>";
    }
}
