using UnityEngine;
using System.Collections;

public class MainMenuBG : MonoBehaviour {
	SpriteRenderer menuBG;
	Camera cam;
	void Start(){
		menuBG = transform.GetComponent<SpriteRenderer> ();
		float worldScreenHeight=Camera.main.orthographicSize*1.25f;
		float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
		transform.localScale = new Vector2 (worldScreenWidth / menuBG.bounds.extents.x, worldScreenHeight / menuBG.bounds.extents.y);

	}
}
