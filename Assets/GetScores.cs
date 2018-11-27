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

    private float score;
    private float timeScore;
    private float windowsSmashed;
    private float finalScore;

    // Use this for initialization
    void Start ()
	{
	    scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

	    score = scoreManager.playerInfo.score;
	    timeScore = scoreManager.playerInfo.timeRemaining * 10;
	    windowsSmashed = scoreManager.playerInfo.score;

	    finalScore = (score + timeScore) * windowsSmashed;

	    ScoreNum.GetComponent<Text>().text = Mathf.RoundToInt(score).ToString();
	    TimeScoreNum.GetComponent<Text>().text = Mathf.RoundToInt(timeScore).ToString();
	    WindowsMultiplierNum.GetComponent<Text>().text = Mathf.RoundToInt(windowsSmashed).ToString();
	    TotalScoreNum.GetComponent<Text>().text = Mathf.RoundToInt(finalScore).ToString();
    }
}
