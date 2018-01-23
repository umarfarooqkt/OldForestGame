using System.Collections;
using UnityEngine;

public class TowerButton : MonoBehaviour {

    [SerializeField]
    private GameObject tower;
    // the private is lower case and public is capital which is basically the getter
    // this is what a getter looks like here
    [SerializeField]
    private Sprite dragSprite;
    public GameObject Tower
    {
        // returning the private attribute 
        get
        {
            return tower;
        }
    }

    public Sprite DragSprite
    {
        // returning the private attribute 
        get
        {
            return dragSprite;
        }
    }
}
