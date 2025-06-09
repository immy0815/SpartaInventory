using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Data/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public List<StatEntry> stats;
}
