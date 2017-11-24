using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    /// initializing some game objects
    /// make sure the attributes are private so in unity we can use a serialized field 
    /// to access private attributes and now they are just private to other classes which will use getters to access them 
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int MaxEnemiesOnScreen;
    [SerializeField]
    private int totalEnemies;
    [SerializeField]
    private int enemiesPerspawn;

    private int enemiesOnScreen = 0;
    const float spawndelay = 0.8f; // every 0.5 secs spawn enemy 


	// Use this for initialization
	void Start () {
        //spawnEnemy();
        StartCoroutine(spawn()); // to start up the routine then it just keeps calling it self
	}
	//method to spawn/.creat enemies 
   

    /// <summary>
    ///  actually gonna use the IEnumerator for the enemy spawn because if its done from the start 
    ///  function we cant add multiple enimies which is obviously an issue 
    ///  and when I added it to update it just spawns all the enimies at once and repawns them after the
    ///  first gorup is destroyed
    /// </summary>
    /// Ienumerator lets us add wait time 
    ///  Coroutine or the IEnumerator way of spwaning the enimies 
    IEnumerator spawn()
    {
        if (enemiesPerspawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerspawn; i++)
            {
                if (enemiesOnScreen < MaxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    //setting the enemy position to spawn point position
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                }
            }
            // basically we need to return from this method  
            yield return new WaitForSeconds(spawndelay);
            // and at the end it calls it self 
            // so basically it runs, waits spawndelay time and calls itself again 
            StartCoroutine(spawn());  
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
