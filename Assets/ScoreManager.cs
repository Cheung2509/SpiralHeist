using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Figures;

    private PlayerInfo playerInfo;

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

    private void Update()
    {
        addScore(15);
    }
}
