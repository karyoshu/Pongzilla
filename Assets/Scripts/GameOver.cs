using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	int score;
	public bool gameOver = false;
	public AudioClip GOClip;
	public Texture2D gameOverBG;
	guiSetup getScore;
	public GUISkin skin;
	Pauser pauser;
	int score1, score2, score3, score4;
	void Awake()
	{
		getScore = GameObject.Find ("guiSetup").GetComponent<guiSetup> ();
		pauser = GameObject.Find ("Pauser").GetComponent<Pauser> ();
		score1 = PlayerPrefs.GetInt ("Score1");
		score2 = PlayerPrefs.GetInt ("Score2");
		score3 = PlayerPrefs.GetInt ("Score3");
		score4 = PlayerPrefs.GetInt ("Score4");
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			gameOver = true;
			audio.clip = GOClip;
			audio.Play();
			score = getScore.score;
			pauser.paused = true;
			if(score>score1)
			{
				PlayerPrefs.SetString("ScoreName4", PlayerPrefs.GetString("ScoreName3"));
				PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
				PlayerPrefs.SetString("ScoreName3", PlayerPrefs.GetString("ScoreName2"));
				PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
				PlayerPrefs.SetString("ScoreName2", PlayerPrefs.GetString("ScoreName1"));
				PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score1"));
				PlayerPrefs.SetString("ScoreName1", PlayerPrefs.GetString("UserName"));
				PlayerPrefs.SetInt("Score1", score);
			}else if(score>score2)
			{
				PlayerPrefs.SetString("ScoreName4", PlayerPrefs.GetString("ScoreName3"));
				PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
				PlayerPrefs.SetString("ScoreName3", PlayerPrefs.GetString("ScoreName2"));
				PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
				PlayerPrefs.SetString("ScoreName2", PlayerPrefs.GetString("UserName"));
				PlayerPrefs.SetInt("Score2", score);
			}else if(score>score3)
			{
				PlayerPrefs.SetString("ScoreName4", PlayerPrefs.GetString("ScoreName3"));
				PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score3"));
				PlayerPrefs.SetString("ScoreName3", PlayerPrefs.GetString("UserName"));
				PlayerPrefs.SetInt("Score3", score);
			}else if(score>score4)
			{
				PlayerPrefs.SetString("ScoreName4", PlayerPrefs.GetString("UserName"));
				PlayerPrefs.SetInt("Score4", score);
			}
		}
	}
	void OnGUI()
	{
		float screenSize = Screen.width;
		if(gameOver)
		{
			GUI.skin = skin;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), gameOverBG);
			GUI.Label(new Rect(Screen.width/2-screenSize*0.2f + 2, Screen.height/2-screenSize*0.15f + 4, screenSize*0.4f, screenSize*0.1f), "Your Score is " + score, "labelShadow");
			GUI.Label(new Rect(Screen.width/2-screenSize*0.2f, Screen.height/2-screenSize*0.15f, screenSize*0.4f, screenSize*0.1f), "Your Score is " + score);
			if (GUI.Button (new Rect ((Screen.width - 3*screenSize * 0.12f) / 2, Screen.height / 2 - 50, screenSize * 0.12f, screenSize * 0.04f), "", "RestartButton")) {
				pauser.paused = !pauser.paused;
				float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
				Invoke("reload", fadeTime);
			}
			if (GUI.Button (new Rect ((Screen.width + screenSize * 0.12f) / 2, Screen.height / 2 - 50, screenSize * 0.12f, screenSize * 0.04f), "", "ExitButton")) {
				pauser.paused = !pauser.paused;
				float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
				Invoke("toMenu", fadeTime);
			}
		}
	}
	void toMenu()
	{
		Application.LoadLevel ("Menu");
	}
	void reload()
	{
		Application.LoadLevel ("Scene01");
	}
}
