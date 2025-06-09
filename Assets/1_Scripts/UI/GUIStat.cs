using System;
using TMPro;
using UnityEngine;

public class GUIStat : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpTitle;
    [SerializeField] private TextMeshProUGUI tmpValue;

    private void Reset()
    {
        tmpTitle = transform.FindChildByName<TextMeshProUGUI>("Tmp_Title");
        tmpValue = transform.FindChildByName<TextMeshProUGUI>("Tmp_Value");
    }

    public void Show(string title, string value)
    {
        gameObject.SetActive(true);
        tmpTitle.text = title;
        tmpValue.text = value;
    }
}
