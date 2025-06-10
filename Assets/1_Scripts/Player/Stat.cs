using System;
using System.Collections.Generic;

public enum StatType
{
    Hp,
    Atk,
    Def
}

[System.Serializable]
public class StatEntry
{
    public StatType type;
    public float value;
}

// 공용 스탯 클래스
public class Stat
{ 
    private Dictionary<StatType, float> stats = new();

    // 해당 타입의 Stat 가져오기
    public float GetStat(StatType type)
    {
        return stats.GetValueOrDefault(type, 0f);
    }
    public Dictionary<StatType, float> GetStats() => stats; 
 
    // 스탯 추가
    public void AddStat(StatType type, float delta)
    {
        if (!stats.TryAdd(type, delta))
            stats[type] += delta;

        // 0이면 삭제
        if (stats[type] == 0)
            stats.Remove(type);
    }

    // ====================================================
    // StatEntry에 따른 Stat 추가
    public void AddStats(List<StatEntry> entries)
    {
        foreach (var entry in entries)
        {
            AddStat(entry.type, entry.value);
        }
    }

    public void RemoveStats(List<StatEntry> entries)
    {
        foreach (var entry in entries)
        {
            AddStat(entry.type, -entry.value);
        }
    }
    // ====================================================
}
