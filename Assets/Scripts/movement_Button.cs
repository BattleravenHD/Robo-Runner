using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_Button : MonoBehaviour {

    public bool Is_Move;
    public bool TouchController;
    public GameObject Player;

    Vector3 distance;

    Vector3 touchPosWorld;

    Vector2 screenmax;

    // Use this for initialization
    void Start () {
        distance.x = Player.transform.position.x - transform.position.x;
        distance.y = Player.transform.position.y - transform.position.y;
        screenmax = new Vector2(Screen.height, Screen.width);
    }
	
	// Update is called once per frame
	void Update () {

        if (Is_Move == false)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3( 0, screenmax.y, 0)).x + 1.4f, Camera.main.ScreenToWorldPoint(new Vector3(screenmax.x, 0, 0)).y + 1.4f, 0);
        }else
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, screenmax.y, 0)).x - 1.4f, Camera.main.ScreenToWorldPoint(new Vector3(screenmax.x, 0, 0)).y + 1.4f, 0);
        }

        if (TouchController == true)
        {
            foreach (Touch iPhoneTouch in Input.touches)
            {
                if (iPhoneTouch.phase != TouchPhase.Ended && iPhoneTouch.phase != TouchPhase.Canceled)
                {
                    //We transform the touch position into word space from screen space and store it.
                    touchPosWorld = Camera.main.ScreenToWorldPoint(iPhoneTouch.position);

                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                    //We now raycast with this information. If we have hit something we can process it.
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                    if (hitInformation.collider != null)
                    {
                        //We should have hit something with a 2D Physics collider!
                        GameObject touchedObject = hitInformation.transform.gameObject;

                        if (touchedObject.tag == "GameController")
                        {
                            if (Is_Move == true && touchedObject.GetComponent<movement_Button>().Is_Move == true)
                            {
                                Player.SendMessage("Move");
                            }
                            else if (Is_Move == false && touchedObject.GetComponent<movement_Button>().Is_Move == false)
                            {
                                Player.SendMessage("Jump");
                            }
                            else
                            {
                                touchedObject.SendMessage("Trigger");
                            }
                        }
                    }
                }
            
            }   
        }        
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (Is_Move == true)
            {
                Player.SendMessage("Move");
            }else
            {
                Player.SendMessage("Jump");
            }
        }
    }
}
