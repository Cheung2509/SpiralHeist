using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreChecking : MonoBehaviour
{
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject LeaderboardGO;

    private Leaderboard leaderboard;

    [SerializeField]
    private GameObject HighscoreInterface;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

        leaderboard = LeaderboardGO.GetComponent<Leaderboard>();

        if (scoreManager.playerInfo.score > leaderboard.playerInfos[(leaderboard.playerInfos.Count - 1)].score)
        {
            HighscoreInterface.SetActive(true);
        }
    }
}
