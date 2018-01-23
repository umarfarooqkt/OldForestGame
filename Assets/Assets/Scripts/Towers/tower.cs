using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour {

	[SerializeField]// remember serialization is for accessing through unity
	private float attackinterval;
	[SerializeField]
	private float attackdistance; 
	private Projectiles projectile;
	private Enemy target = null;
	private float attackCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
