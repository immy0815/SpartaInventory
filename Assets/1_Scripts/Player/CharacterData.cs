using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string charName;
    public GameObject charPrefab;
    public Sprite portrait;

    public List<StatEntry> stats;
}
