using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Figures;

    private PlayerInfo playerInfo;

    private int windows_smashed = 0;

    private float time_taken;

    private void Start()
    {

    }


    void addScore(int score)
    {
        playerInfo.score += score;

        string temp = playerInfo.score.ToString();
        while(temp.Length < 5)
        {
            temp = "0" + temp;
        }

        int i = 0;
        foreach (GameObject figure in Figures)
        {
            figure.GetComponent<Text>().text = temp[i].ToString();
            i++;
        }
    }

    void WindowSmashed()
    {
        playerInfo.windowsSmashed++;
    }

    private void Update()
    {
        addScore(15);
    }

    public void GameOver()
    {
        playerInfo.timePlayed = time_taken;

        Leaderboard leaderboard = new Leaderboard();
        leaderboard.Load();
        leaderboard.AddPlayer(playerInfo);
        leaderboard.Save();
    }
}
