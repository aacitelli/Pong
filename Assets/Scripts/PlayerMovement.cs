using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 position, wrld;
    public static float halfHeight;
    public static float halfWidth;

	// Use this for initialization
	void Start ()
    {
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        gameObject.AddComponent<BoxCollider2D>();

        if (name == "RightPlayer")
        {
            position = transform.position;
            position.x = wrld.x - halfWidth;
            transform.position = position;
        }

        else if (name == "LeftPlayer")
        {
            position = transform.position;
            position.x = -wrld.x + halfWidth;
            transform.position = position;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Right Player Controls
        if (gameObject.tag.Equals("RightPlayer"))
        {
            // Move Up
            if (Input.GetKey(KeyCode.UpArrow) /* && transform.position.y < (4.5 - halfHeight) */)
            {
                position.x = GameObject.FindWithTag("RightPlayer").transform.position.x;
                position.y = GameObject.FindWithTag("RightPlayer").transform.position.y + (.025f * wrld.y);
                GameObject.FindWithTag("RightPlayer").transform.position = position;
            }
            
            // Move Down
            if (Input.GetKey(KeyCode.DownArrow) /* && transform.position.y > (-4.5 + halfHeight) */)
            {
                position.x = GameObject.FindWithTag("RightPlayer").transform.position.x;
                position.y = GameObject.FindWithTag("RightPlayer").transform.position.y - (.025f * wrld.y);
                GameObject.FindWithTag("RightPlayer").transform.position = position;
            }
        }

        // Left Player Controls
        else
        {
            // Move Up
            if (Input.GetKey(KeyCode.W) /* && transform.position.y < (4.5 - halfHeight) */)
            {
                position.x = GameObject.FindWithTag("LeftPlayer").transform.position.x;
                position.y = GameObject.FindWithTag("LeftPlayer").transform.position.y + (.025f * wrld.y);
                GameObject.FindWithTag("LeftPlayer").transform.position = position;
            }

            // Move Down
            if (Input.GetKey(KeyCode.S) /* && transform.position.y > (-4.5 + halfHeight) */)
            {
                position.x = GameObject.FindWithTag("LeftPlayer").transform.position.x;
                position.y = GameObject.FindWithTag("LeftPlayer").transform.position.y - (.025f * wrld.y);
                GameObject.FindWithTag("LeftPlayer").transform.position = position;
            }
        }
	}
}
