using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManagerScript : Singleton<TowerManagerScript> {

    // for selecting the tower 
    private TowerButton TowerbuttonSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame so how many frames u have is how many times its called 
	void Update () {
        // if user clicks mouse code inside the if statement is executed 
        if (Input.GetMouseButtonDown(0) )/// checks for button press
        {
            // gonna get the 2dvector position of the mouse position at the time ofit being pressed in worldpoint  
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // arraycast just gives us a intersection between camera and whatever comes in its way in the scene
            /// finds the point of the shooting array from 0,0 to where we click coolio
            RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);
            if (hit.collider.tag == "buildsite") // so only build tower if the hit collider ()hit coordinates ae equal to the build site
            {
                placeTower(hit);
            }
        }

	}

    public void placeTower(RaycastHit2D hit)
    {
        // if pointer isn't over the gameobject then you can come into this if statement so this 
        // is here to stop the error since it can hit the buttons panel itself
        if (!EventSystem.current.IsPointerOverGameObject() && TowerbuttonSelected !=null) // null is to stop it from crashing if we hit somewhere on the screen withou selecting something
        {
            // create a tower where mouse clicked or hit, instantiates just creates the object
            GameObject newTower = Instantiate(TowerbuttonSelected.Tower);
            // setting the position of the new tower to the position of the hit 
            newTower.transform.position = hit.transform.position;
        }
       
    }

    public void towerSelect(TowerButton selectedT)
    {
        TowerbuttonSelected = selectedT;
        // to print to the console
        Debug.Log("print check for button ");
    }
}
