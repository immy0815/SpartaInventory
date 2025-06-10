using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] private Transform prefabRoot;
    private GameObject modelObj;
    
    public PlayerData PlayerData { get; private set; }

    public void Init(PlayerData data)
    {
        ChangeCharacter(data);
    }

    public void ChangeCharacter(PlayerData data)
    {
        PlayerData = data;
        Destroy(modelObj);
        modelObj = Instantiate(PlayerData.characterData.charPrefab, transform);
        modelObj.transform.localPosition = transform.position;
    }
}
