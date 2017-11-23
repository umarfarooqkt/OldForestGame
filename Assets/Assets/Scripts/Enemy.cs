using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int target =0;
	public Transform exitPoint;// for tthe exit from the game, hopefully player cant exit
	public Transform[] waypoints; // this is actually the reference check points we are going to use to move our enemy
	public float navigationUpdate; // for 

	private Transform enemy; // gonna be the enemys movement
	private float navigationTime = 0; 
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Transform>();
		//get componets lets us address the properties of tranform 
	}
	
	// Update is called once per frame
	void Update () {
		if(waypoints != null) {
			// keeping track since time past since navigation tiem started 
			navigationTime= navigationTime + Time.deltaTime;
			if(navigationTime > navigationUpdate){
				if(target < waypoints.Length){
					enemy.position =Vector2.MoveTowards(enemy.position, waypoints[target].position, navigationTime);
				}
				else{
					enemy.position = Vector2.MoveTowards(enemy.position,exitPoint.position,navigationTime);
				}
				navigationTime=0;
			}
		}
	}
	// so this is for when we run into our colliders as in the reference points I beleive
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Checkpoint"){
			target +=1;
		}
		// so if the enemy runs into the finish as in exit it will be destroyed boi
		else if (other.tag == "Finish"){
			GameManager.Instance.removeEnemyFromScreen(); // basically by destroy i mean taek of screen
			Destroy(gameObject);// and now destroy it
		} 
	}
}
