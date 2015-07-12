using UnityEngine;
using System.Collections;

public class MenuSetup : MonoBehaviour {
	SpriteRenderer mmenubg;
	Animator anim;
	private bool IsMenuOn = true;
	private bool IsLevelOn = false;
	private bool IsShopOn = false;
	private bool IsScoreOn = false;
	private bool IsOptionsOn = false;
	private bool IsAboutOn = false;
	public GUISkin skin;
	string textFieldString ;
	float soundLevel;
	// Use this for initialization
	void Awake () {
		anim = transform.GetComponent<Animator> ();
		textFieldString = PlayerPrefs.GetString("UserName");
		soundLevel = PlayerPrefs.GetFloat ("SoundLevel");
	}
	void Start(){
		//mmenubg.bounds.size = new Vector2 (Screen.width, Screen.height);
	}
	// Update is called once per frame
	void Update () {
		anim.SetBool("IsMenuOn", IsMenuOn);
		PlayerPrefs.SetFloat("SoundLevel", soundLevel);
	}
	void OnGUI(){
		GUI.skin = skin;
		float screenSize = Screen.width;
		GUIStyle label = GUI.skin.GetStyle ("label");
		label.fontSize = (int)(screenSize * 0.05f);
		GUIStyle slabel = GUI.skin.GetStyle ("LabelShadow");
		slabel.fontSize = (int)(screenSize * 0.05f);
		GUIStyle txtfield = GUI.skin.GetStyle ("textfield");
		txtfield.fontSize = (int)(screenSize * 0.05f);

		if(IsMenuOn){
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 - 3*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "StartButton")) {
				float fadeTime = GameObject.Find("GM").GetComponent<Fading>().BeginFade(1);
				Invoke("ChangeLevel", fadeTime);
				IsMenuOn = false;
				IsLevelOn = true;
			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 - Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "AboutButton")) {
				IsAboutOn = true;
				IsMenuOn = false;

			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "ShopButton")) {
				IsShopOn = true;
				IsMenuOn = false;
				
			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 3*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "OptionsButton")) {
				IsOptionsOn = true;
				IsMenuOn = false;

			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 5*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "HiScoreButton")) {
				IsScoreOn = true;
				IsMenuOn = false;

			}
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "ExitButton")) {
				Application.Quit();
			}
		}
		else if(IsShopOn){
			GUI.Label(new Rect (Screen.width/2-screenSize*0.3f+2, Screen.height/2-46, screenSize*0.6f, screenSize*0.2f), "Shop is closed for time being. Come back later.", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.3f, Screen.height/2-50, screenSize*0.6f, screenSize*0.2f), "Shop is closed for time being. Come back later.");	
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "BackButton")) {
				IsMenuOn = true;
				IsShopOn = false;
			}
		}
		else if(IsScoreOn){
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f+2, screenSize*0.08f+4, screenSize*0.5f, screenSize*0.2f), "Hi Scores", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f, screenSize*0.08f, screenSize*0.5f, screenSize*0.2f), "Hi Scores");

			GUI.TextField(new Rect(Screen.width/2 - screenSize*0.2f, screenSize*0.2f, screenSize*0.4f, screenSize*0.3f),
			              PlayerPrefs.GetString("ScoreName1") + ": " + PlayerPrefs.GetInt("Score1") + "\n" +
			              PlayerPrefs.GetString("ScoreName2") + ": " + PlayerPrefs.GetInt("Score2") + "\n" +
			              PlayerPrefs.GetString("ScoreName3") + ": " + PlayerPrefs.GetInt("Score3") + "\n" +
			              PlayerPrefs.GetString("ScoreName4") + ": " + PlayerPrefs.GetInt("Score4") + "\n");
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "BackButton")) {
				IsMenuOn = true;
				IsScoreOn = false;
			}
			if (GUI.Button (new Rect ( screenSize * 0.10f, Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "ResetButton")) {
				PlayerPrefs.SetString("ScoreName1", "Player");PlayerPrefs.SetInt("Score1", 0);
				PlayerPrefs.SetString("ScoreName2", "Player");PlayerPrefs.SetInt("Score2", 0);
				PlayerPrefs.SetString("ScoreName3", "Player");PlayerPrefs.SetInt("Score3", 0);
				PlayerPrefs.SetString("ScoreName4", "Player");PlayerPrefs.SetInt("Score4", 0);
			}
		}
		else if(IsOptionsOn){
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f+2, screenSize*0.08f+4, screenSize*0.5f, screenSize*0.2f), "Options", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f, screenSize*0.08f, screenSize*0.5f, screenSize*0.2f), "Options");
			GUI.Label(new Rect(Screen.width/2 - screenSize*0.225f+2, screenSize*0.15f+4, screenSize*0.3f, screenSize*0.1f),"User: ", "LabelShadow");
			GUI.Label(new Rect(Screen.width/2 - screenSize*0.225f, screenSize*0.15f, screenSize*0.3f, screenSize*0.1f),"User: ");
			textFieldString = GUI.TextField (new Rect ( Screen.width/2, screenSize*0.16f, screenSize*0.25f, screenSize*0.06f), textFieldString);	
			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "BackButton")) {
				IsMenuOn = true;
				IsOptionsOn = false;
			}
			if (GUI.Button (new Rect (Screen.width/2 + screenSize * 0.25f, screenSize*0.16f, screenSize * 0.18f, screenSize * 0.06f), "", "ChangeButton")) {
				PlayerPrefs.SetString("UserName", textFieldString);
			}
			GUI.Label(new Rect(Screen.width/2 - screenSize*0.225f+2, screenSize*0.2f+4, screenSize*0.3f, screenSize*0.1f),"Sound: ", "LabelShadow");
			GUI.Label(new Rect(Screen.width/2 - screenSize*0.225f, screenSize*0.2f, screenSize*0.3f, screenSize*0.1f),"Sound: ");
			soundLevel = GUI.HorizontalSlider(new Rect(Screen.width/2, screenSize*0.23f, screenSize*0.25f, screenSize*0.1f), soundLevel, 0, 1);
		}
		else if(IsAboutOn){
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f+2, screenSize*0.08f+4, screenSize*0.5f, screenSize*0.2f), "About Pongzilla", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.25f, screenSize*0.08f, screenSize*0.5f, screenSize*0.2f), "About Pongzilla");

			GUI.Label(new Rect (Screen.width/2-screenSize*0.30f+2, screenSize*0.15f+4, screenSize*0.6f, screenSize*0.2f), 
			          "Developed by Himanshu Mittal\nMail: himanshu-mittal@live.com", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.30f, screenSize*0.15f, screenSize*0.6f, screenSize*0.2f), 
			          "Developed by Himanshu Mittal\nMail: himanshu-mittal@live.com");

			GUI.Label(new Rect (Screen.width/2-screenSize*0.5f+2, screenSize*0.27f+4, screenSize*0.7f, screenSize*0.2f), 
			          "Music by Roald Strauss\n(from www.indiegamemusic.com)", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.5f, screenSize*0.27f, screenSize*0.7f, screenSize*0.2f), 
			          "Music by Roald Strauss\n(from www.indiegamemusic.com)");

			GUI.Label(new Rect (Screen.width/2+screenSize*0.0f+2, screenSize*0.27f+4, screenSize*0.5f, screenSize*0.2f), 
			          "Sprites by Unity", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2+screenSize*0.0f, screenSize*0.27f, screenSize*0.5f, screenSize*0.2f), 
			          "Sprites by Unity");

			GUI.Label(new Rect (Screen.width/2-screenSize*0.45f+2, screenSize*0.4f+4, screenSize*0.9f, screenSize*0.2f), 
			          "To move:Tilt phone/WASD/Arrow Keys, To Jump:Space Bar/On Screen button", "LabelShadow");	
			GUI.Label(new Rect (Screen.width/2-screenSize*0.45f, screenSize*0.4f, screenSize*0.9f, screenSize*0.2f), 
			          "To move:Tilt phone/WASD/Arrow Keys, To Jump:Space Bar/On Screen button");

			if (GUI.Button (new Rect ((Screen.width - screenSize * 0.20f), Screen.height / 2 + 7*Screen.height * 0.05f, screenSize * 0.18f, screenSize * 0.06f), "", "BackButton")) {
				IsMenuOn = true;
				IsAboutOn = false;
			}
		}
	}
	void ChangeLevel(){
		Application.LoadLevel ("Scene01");
	}
}
