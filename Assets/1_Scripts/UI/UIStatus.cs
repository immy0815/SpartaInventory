using System;
using System.Collections.Generic;
using UnityEngine;

public class UIStatus : MonoBehaviour, IGUI
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;
    
    [SerializeField] private Transform slotRoot;
    [SerializeField] private GameObject origin;

    private List<GUIStat> statSlots;
    
    private void Reset()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        slotRoot = transform.FindChildByName<Transform>("Layout_Stat");
        origin = transform.FindChildByName<GUIStat>("GUI_Stat").gameObject;
    }

    public void Initialization()
    {
        canvasGroup.SetAlpha(false);
        statSlots = new List<GUIStat>();
    }

    public void Open()
    {
        UpdateStatusGUI();
        canvasGroup.OpenPopupAnimation(rectTransform, RectTransform.Axis.Horizontal, 500f, -50f);
    }

    public void Close()
    {
        canvasGroup.ClosePopupAnimation(rectTransform, RectTransform.Axis.Horizontal, -50f, 500f);
    }

    private void UpdateStatusGUI()
    {
        // 비우기 => 이후 DynamicObjectPool로 변경하기
        foreach (var slot in statSlots)
        {
            Destroy(slot.gameObject);
        }
        statSlots.Clear();
        
        // GameManager에 저장된 로비 플레이어 데이터로 불러오기
        var stats = GameManager.Instance.lobbyPlayerData.playerStat.GetStats();
        
        foreach (var stat in stats)
        {
            GameObject statObj = Instantiate(origin, slotRoot);
            GUIStat statSlot = statObj.GetComponent<GUIStat>();
            statSlot.Show(stat.Key.ToKor(), stat.Value.ToString("N2"));
            statSlots.Add(statSlot);
        }
    }
}
