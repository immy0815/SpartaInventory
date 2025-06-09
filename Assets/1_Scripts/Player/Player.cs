using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform prefabRoot;
    public PlayerData PlayerData { get; private set; }

    public void Init(PlayerData data)
    {
        PlayerData = data;
        GameObject model = Instantiate(PlayerData.characterData.charPrefab, transform);
        model.transform.localPosition = prefabRoot.position;
    }
}
