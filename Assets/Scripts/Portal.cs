﻿using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public Transform target;
	public bool rcvr = false;
	Portal portal;
	// Use this for initialization
	void Start () {
		portal = target.GetComponent<Portal>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(!rcvr){

			if(col.tag == "Player" || col.tag == "Enemy"|| col.tag == "EnemyKill"){
				portal.rcvr = true;
				col.transform.position = target.position;
			}
			Invoke("rcvrFalse", 0.3f);
		}

	}
	void rcvrFalse(){
		portal.rcvr = false;
	}
}
