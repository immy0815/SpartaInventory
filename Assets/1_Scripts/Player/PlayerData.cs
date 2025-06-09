// 모든 씬에서 사용 될 플레이어의 데이터
public class PlayerData
{
    public string Nickname { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }

    public CharacterData characterData;
    public Stat playerStat;
    
    // 초기 세팅
    public void Init(CharacterData data, string nickname, int level, int gold)
    {
        characterData = data;
        playerStat = new Stat();
        playerStat.AddStats(data.stats);
        
        Nickname = nickname;
        Level = level;
        Gold = gold;
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
    }
    
    public void AddGold(int amount) => Gold += amount;
    public bool SpendGold(int amount)
    {
        if (Gold < amount) return false;
        Gold -= amount;
        return true;
    }
    
    public void LevelUp() => Level++;
}
