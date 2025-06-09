using System;
using System.Collections.Generic;
using UnityEngine;

public class UIStatus : MonoBehaviour, IGUI
{
    [SerializeField] private CanvasGroup canvasGroup;
    
    [SerializeField] private Transform inventoryRoot;
    [SerializeField] private GameObject origin;
    
    private void Reset()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        inventoryRoot = transform.FindChildByName<Transform>("Layout_Stat");
        origin = transform.FindChildByName<GUIStat>("GUI_Stat").gameObject;
    }

    public void Initialization()
    {
        canvasGroup.SetActive(false);
        UpdateStatusGUI();
    }

    public void Open()
    {
        UpdateStatusGUI();
        canvasGroup.SetActive(true);
    }

    public void Close()
    {
        canvasGroup.SetActive(false);
    }

    void UpdateStatusGUI()
    {
        // GameManager에 저장된 로비 플레이어 데이터로 불러오기
        var stats = GameManager.Instance.lobbyPlayerData.playerStat.GetStats();
        
        foreach (var stat in stats)
        {
            GameObject statObj = Instantiate(origin, inventoryRoot);
            GUIStat statSlot = statObj.GetComponent<GUIStat>();
            statSlot.Show(stat.Key.ToKor(), stat.Value.ToString("N2"));
        }
    }
}
