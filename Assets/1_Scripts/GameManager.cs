using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                MyDebug.LogError("GameManager Instance Not Found");
                return null;
            }
            return instance;
        }
    }

    public Player player;
    public PlayerData lobbyPlayerData;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Initialization();
    }

    private void Initialization()
    {
        CharacterData characterData = Resources.Load<CharacterData>("CharacterData/BaseCharData");
        lobbyPlayerData = new PlayerData();
        lobbyPlayerData.Init(characterData);
    }

    private void SpawnPlayer()
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GameObject playerObj = Instantiate(playerPrefab, transform.position, Quaternion.identity); // position은 소환 위치로 바꾸기
        player = playerObj.GetComponent<Player>();
        player.Init(lobbyPlayerData);
    }
}
