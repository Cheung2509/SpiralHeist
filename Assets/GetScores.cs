using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScores : MonoBehaviour
{
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject ScoreNum;

    [SerializeField]
    private GameObject TimeScoreNum;

    [SerializeField]
    private GameObject WindowsMultiplierNum;

    [SerializeField]
    private GameObject TotalScoreNum; 

    // Use this for initialization
    void Start ()
	{
	    scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

	    ScoreNum.GetComponent<Text>().text = Mathf.RoundToInt(scoreManager.playerInfo.score).ToString();
	    TimeScoreNum.GetComponent<Text>().text = Mathf.RoundToInt(scoreManager.playerInfo.timePlayed).ToString();
	    WindowsMultiplierNum.GetComponent<Text>().text = scoreManager.playerInfo.windowsSmashed.ToString();
	    TotalScoreNum.GetComponent<Text>().text =
	        Mathf.RoundToInt((scoreManager.playerInfo.score + scoreManager.playerInfo.timePlayed) *
	         scoreManager.playerInfo.windowsSmashed).ToString();

	}
}
