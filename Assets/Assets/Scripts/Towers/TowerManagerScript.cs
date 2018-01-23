using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManagerScript : Singleton<TowerManagerScript> {

    // for selecting the tower 
    private TowerButton TowerbuttonSelected;
    // for making a tower vsible while being dragged
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            //In the if statement I just check what the collider tag equles to and change it inside the 
            if (hit.collider.tag == "buildsite") // so only build tower if the hit collider ()hit coordinates ae equal to the build site
            {
                hit.collider.tag = "siteinuse";
                placeTower(hit);
            }

            
        }
        if (spriteRenderer.enabled)
            {
                followMouse();
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
            dragSpriteDisable();
        }
       
    }

    public void towerSelect(TowerButton selectedT)
    {
        TowerbuttonSelected = selectedT;
        // to print to the console
        dragSpriteEnable(TowerbuttonSelected.DragSprite);
    }

    // to make the mini tower icon follow the mouse 
    public void followMouse()
    {
        // kind of like using cxamera to find point earlier
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        // this line of code makes sure everythings on the top of the page 
        transform.position = new Vector2(transform.position.x,transform.position.y);
    }
    // to enable the sprite's rendering being dragged by the mouse
    public void dragSpriteEnable(Sprite s)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = s;
    }

    // to diable the sprite dragging 
    public void dragSpriteDisable()
    {
        spriteRenderer.enabled = false;
    }


}
