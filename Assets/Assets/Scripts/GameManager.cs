using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// initializing some game objects
    public static GameManager instance = null;
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int MaxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerspawn;

    private int enemiesOnScreen = 0;

	void Awake(){
		if (instance== null){
			instance = this;
		}
		else if (instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		spawnEnemy();
	}
	//method to spawn/.creat enemies
	void spawnEnemy(){
		if (enemiesPerspawn > 0 && enemiesOnScreen < totalEnemies)
		{
			for(int i=0; i < enemiesPerspawn; i++){
				if(enemiesOnScreen < MaxEnemiesOnScreen){
					GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
					//setting the enemy position to spawn point position
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen+=1; 
				}
			}
		}
	}

	//method for decrementing enemies on screen
	public void removeEnemyFromScreen(){
		if(enemiesOnScreen > 0){ enemiesOnScreen-=1;}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
