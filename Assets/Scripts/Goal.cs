using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	private guiSetup score;
	// Use this for initialization
	void Awake () {
		score = GameObject.Find("guiSetup").GetComponent<guiSetup>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "EnemyKill"||col.tag == "Enemy") {
			Destroy(col.gameObject);
			score.score = score.score - 100;
		}
	}
}
