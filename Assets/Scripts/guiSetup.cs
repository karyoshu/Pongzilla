using UnityEngine;
using System.Collections;

public class guiSetup : MonoBehaviour
{
	public int score = 0;					// The player's score.
	public GUISkin skin;
	private BallControl playerControl;	// Reference to the player control script.
	private Pauser pauser;
	public Texture2D menuBG;
	GameOver gameOver;
	void Awake(){
		pauser = GameObject.Find("Pauser").GetComponent<Pauser>();
		gameOver = GameObject.Find ("GM").GetComponent<GameOver> ();
	}
	void OnGUI(){
		GUI.skin = skin;
		float screenSize = Screen.width;
		GUI.Label(new Rect(Screen.width/2 - screenSize * 0.15f + 2, screenSize * 0.02f + 4, screenSize * 0.3f, screenSize * 0.1f), "Score:" + score, "LabelShadow");
		GUI.Label(new Rect(Screen.width/2 - screenSize * 0.15f + 2, screenSize * 0.02f, screenSize * 0.3f, screenSize * 0.1f), "Score:" + score);
		if (!pauser.paused) {
			if (GUI.Button (new Rect (screenSize * 0.04f, 10, screenSize * 0.04f, screenSize * 0.04f), "", "cogButton")) {
				pauser.paused = !pauser.paused;
			}
		} else if (!gameOver.gameOver){
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), menuBG);
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.12f) / 2, Screen.height / 2 - screenSize * 0.04f, screenSize * 0.12f, screenSize * 0.04f), "", "ResumeButton")) {
				pauser.paused = !pauser.paused;
			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.12f) / 2, Screen.height / 2 + screenSize * 0.04f, screenSize * 0.12f, screenSize * 0.04f), "", "ExitButton")) {
				pauser.paused = !pauser.paused;
				float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
				Invoke("ChangeLevel", fadeTime);
			}
		}
	}
	
	void ChangeLevel(){
		Application.LoadLevel ("Menu");
	}
}
