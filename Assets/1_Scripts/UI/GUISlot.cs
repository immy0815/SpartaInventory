using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUISlot : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Image imgEquipMark;
    [SerializeField] private Button btnEquip;
    
    private Item thisItem;

    private void Reset()
    {
        imgIcon = transform.FindChildByName<Image>("Img_Icon");
        imgEquipMark = transform.FindChildByName<Image>("Img_EquipMark");
        btnEquip = GetComponent<Button>();
    }

    public void Show(Item item)
    {
        gameObject.SetActive(true);

        thisItem = item;
        imgIcon.sprite = item.itemData.icon;
        imgEquipMark.enabled = item.isEquipped;
    }

    public void SetButtonClick(UnityAction callback)
    {
        btnEquip.onClick.RemoveAllListeners();
        btnEquip.onClick.AddListener(Select);
        btnEquip.onClick.AddListener(callback);
    }
    
    private void Select()
    {
        if (thisItem.isEquipped)
        {
            GameManager.Instance.lobbyPlayerData.UnequipItem(thisItem);
        }
        else
        {
            GameManager.Instance.lobbyPlayerData.EquipItem(thisItem);
        }
    }
}
