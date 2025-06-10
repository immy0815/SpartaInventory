// 모든 씬에서 사용 될 플레이어의 데이터

using System.Collections.Generic;
using System.Linq;

public class PlayerData
{
    public string Nickname { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }

    public CharacterData characterData;
    public Stat playerStat;
    
    public List<Item> inventoryItems = new();
    public int MaxInventorySize { get; private set; } = 20;

    // 초기 세팅
    public void Init(CharacterData data, string nickname, int level, int gold)
    {
        characterData = data;
        playerStat = new Stat();
        playerStat.AddStats(data.stats);
        
        Nickname = nickname;
        Level = level;
        Gold = gold;

        inventoryItems = new List<Item>();
    }
    
    // UI에서 캐릭터 변경 시 불러오기
    // 캐릭터 바꾸고 세팅
    public void ChangeCharacter(CharacterData data)
    {
        // 기존 캐릭터 기본 능력치 스탯 제거
        playerStat.RemoveStats(characterData.stats);
        
        // 변경 캐릭터 기본 능력치 스탯 추가
        playerStat.AddStats(data.stats);
        characterData = data;
        
        // instance 캐릭터에 반영
        GameManager.Instance.player.ChangeCharacter(this);

        // UI Update
        UIManager.Instance.UpdateCharNameText();
    }
    
    // Information
    public void AddGold(int amount) => Gold += amount;
    public bool SpendGold(int amount)
    {
        if (Gold < amount) return false;
        Gold -= amount;
        return true;
    }
    
    public void LevelUp() => Level++;
    
    
    // Inventory 
    public List<Item> GetInventoryItems()
    {
        SortInventoryByEquipped();
        return inventoryItems;
    }
    
    public void SortInventoryByEquipped()
    {
        inventoryItems.Sort((a, b) => b.isEquipped.CompareTo(a.isEquipped));
    }
    
    public void AddItem(Item item)
    {
        if(inventoryItems.Count >= MaxInventorySize)      
            return;
        
        inventoryItems.Add(item);
    }

    public void EquipItem(Item item)
    {
        if (!inventoryItems.Contains(item)) return;

        item.isEquipped = true;
        playerStat.AddStats(item.itemData.stats);
    }

    public void UnequipItem(Item item)
    {
        item.isEquipped = false;
    }

    public void RemoveItem(Item item)
    {
        if(inventoryItems.Contains(item))
            inventoryItems.Remove(item);
    }
}