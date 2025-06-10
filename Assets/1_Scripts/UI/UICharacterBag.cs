using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICharacterBag : MonoBehaviour
{
    [SerializeField] private Transform bagRoot;
    [SerializeField] private GameObject origin;
    
    private void Reset()
    {
        bagRoot = transform.FindChildByName<Transform>("Layout_Character");
        origin = transform.FindChildByName<GUICharSlot>("GUI_CharSlot").gameObject;
    }
    
    public void Initialization()
    {
        Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);

        var characters = Resources.LoadAll<CharacterData>("CharacterData");
        
        foreach (var character in characters)
        {
            GameObject slotObj = Instantiate(origin, bagRoot);
            GUICharSlot slot = slotObj.GetComponent<GUICharSlot>();
            slot.Show(character);
        }
    }

    public void Close()
    {
    }
}
