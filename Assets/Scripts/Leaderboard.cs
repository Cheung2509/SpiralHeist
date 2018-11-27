using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<PlayerInfo> playerInfos;
    _GameSaveLoad save;

    private void Start()
    {
        save = new _GameSaveLoad();
        playerInfos = new List<PlayerInfo>();

        //PlayerInfo info = new PlayerInfo("AAA", 0, 0, 0);
        //AddPlayer(info);
        //Save();
    }

    public void AddPlayer(PlayerInfo player)
    {
        playerInfos.Add(player);
        RankData();

        for (int i = 0; i < playerInfos.Count; i++)
        {
            if (i > 10)
                playerInfos.RemoveAt(i);
        }
        playerInfos.TrimExcess();
    }

    private void RankData()
    {
        Comparison<PlayerInfo> comparer = (PlayerInfo a, PlayerInfo b) => b.score.CompareTo(a.score);
        playerInfos.Sort(comparer);
    }

    public void Save()
    {
        RankData();
        string data = save.SerializeObject(playerInfos);
        save.CreateXML(data);
    }

    public void Load()
    {
        playerInfos = new List<PlayerInfo>((PlayerInfo[])save.DeserializeObject(save.LoadXML()));
    }
    
}