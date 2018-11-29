using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	

	public static ScoreManager instance;
	public int score;
	public int highScore;
	public int liveScore;



	public void Awake(){
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		score = 0;
		liveScore = 0;
		PlayerPrefs.SetString ("highScoreChecker", "F");
		PlayerPrefs.SetString ("highScoreCheckerTick", "F");
		PlayerPrefs.SetInt("liveScore",liveScore);
		PlayerPrefs.SetInt("score",score);
	}
	
	// Update is called once per frame
	void Update () {
		int checkerHigh=PlayerPrefs.GetInt ("highScore");
		int checkerLive = PlayerPrefs.GetInt ("liveScore");
		if (PlayerPrefs.GetString ("highScoreChecker").Equals("F") && PlayerPrefs.GetString ("highScoreCheckerTick").Equals("F")) {
				if (checkerLive > checkerHigh) {
				PlayerPrefs.SetString ("highScoreChecker", "T");
				}
				
		}
	}

	void incrementScore(){
		score += 1;
		PlayerPrefs.SetInt ("liveScore", score);

	}

	public void incrementScore(string diamond){
		if (diamond.Equals ("Diamond")) {
			score += 10;
		}
		PlayerPrefs.SetInt ("liveScore", score);
	}

	public void startScore(){
		InvokeRepeating("incrementScore", 0.1f , 0.5f);

	}

	public void stopScore(){
		CancelInvoke ("incrementScore");
		PlayerPrefs.SetInt ("score", score);

		if (PlayerPrefs.HasKey ("highScore")) {
			if(score>PlayerPrefs.GetInt("highScore")){
				PlayerPrefs.SetInt ("highScore", score);
			}

		} else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}


}
