using UnityEngine;
using UnityEngine.UI;

public class GUICharSlot : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private Image imgSelectMark;
    [SerializeField] private Button btnEquip;

    private CharacterData thisCharData;
    
    private void Reset()
    {
        imgIcon = transform.FindChildByName<Image>("Img_Icon");
        imgSelectMark = transform.FindChildByName<Image>("Img_SelectMark");
        btnEquip = GetComponent<Button>();
    }
    
    public void Show(CharacterData data)
    {
        gameObject.SetActive(true);

        thisCharData = data;
        imgIcon.sprite = thisCharData.portrait;
        imgSelectMark.enabled = false;
        
        btnEquip.onClick.RemoveAllListeners();
        btnEquip.onClick.AddListener(Select);
    }

    public void Select()
    {
        // imgSelectMark.enabled = !imgSelectMark.enabled;
        GameManager.Instance.lobbyPlayerData.ChangeCharacter(thisCharData);
    }
}
