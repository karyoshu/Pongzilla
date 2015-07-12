using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	GUITexture menuBG;
	public bool IsMenuOn = true;
	Animator anim;
	// Use this for initialization
	void Awake () {
		menuBG = transform.GetComponent<GUITexture> ();
		anim = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		menuBG.pixelInset = new Rect(Screen.width/2, Screen.height/2, Screen.width/10, Screen.height/10);
		anim.SetBool ("IsMenuOn", IsMenuOn);
	}
}
