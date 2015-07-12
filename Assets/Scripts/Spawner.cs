using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	public GameObject[] enemiesKill;	// Array of enemy kill prefabs.
	private GameObject enemy;
	private GameObject enemyKill;
	private Enemy eScript;
	private FollowTarget fScript;
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		enemy = (GameObject)Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		eScript = enemy.GetComponent<Enemy>();
		enemyKill =(GameObject) Instantiate(enemiesKill[enemyIndex], transform.position, transform.rotation);
		fScript = enemyKill.GetComponent<FollowTarget> ();
		eScript.target = enemyKill.transform;
		fScript.target = enemy.transform;
		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
