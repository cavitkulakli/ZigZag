using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tabText;
	public Text score;
	public Text highscore1;
	public Text highscore2;
	public Text liveScore;
	public Text newHighScore;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		liveScore.gameObject.SetActive(false);
		highscore1.text = "High Score: " +PlayerPrefs.GetInt ("highScore").ToString();
	}

	public void GameStart(){
		liveScore.gameObject.SetActive(true);
		tabText.SetActive (false);
		zigzagPanel.GetComponent<Animator>().Play ("panelUp");
	}

	public void GameOver(){
		liveScore.gameObject.SetActive(false);
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highscore2.text = PlayerPrefs.GetInt ("highScore").ToString();
		gameOverPanel.SetActive (true);

	}

	public void Reset(){
		SceneManager.LoadScene (0);
	}



	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString("highScoreChecker").Equals("T") && PlayerPrefs.GetString ("highScoreCheckerTick").Equals("F")){
			newHighScore.gameObject.SetActive (true);
			PlayerPrefs.SetString ("highScoreCheckerTick", "T");
		}
		liveScore.text = "Score: " +PlayerPrefs.GetInt ("liveScore").ToString();
	}
}
