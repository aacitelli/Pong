using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private bool movingUp, movingRight;
    private float speed;
    private static float halfWidth;

    Vector3 position;
    private Vector3 wrld;

	// Use this for initialization
	void Start ()
    {
        // The ball starts moving up and to the right at 45 degrees
        movingUp = true;
        movingRight = true;

        // Always travels at 45 degree angles, just with varying speed
        speed = 1.0f;

        gameObject.AddComponent<BoxCollider2D>();
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Collision
        CheckCollisionWithWalls();

        // Upping the speed every frame by a very small amount - May need balanced in the future
        speed += .00175f;

        // Determines which of the four movement functions are called
        if (movingUp && movingRight)
            MoveUpRight();
        else if (!movingUp && movingRight)
            MoveDownRight();
        else if (movingUp && !movingRight)
            MoveUpLeft();
        else
            MoveDownLeft();
	}

    void MoveUpRight()
    {
        position = new Vector3(transform.position.x + (wrld.x * .01f * speed), transform.position.y + (wrld.x * .01f * speed));
        transform.position = position;
    }

    void MoveDownRight()
    {
        position = new Vector3(transform.position.x + (wrld.x * .01f * speed), transform.position.y - (wrld.x * .01f * speed));
        transform.position = position;
    }

    void MoveUpLeft()
    {
        position = new Vector3(transform.position.x - (wrld.x * .01f * speed), transform.position.y + (wrld.x * .01f * speed));
        transform.position = position;
    }

    void MoveDownLeft()
    {
        position = new Vector3(transform.position.x - (wrld.x * .01f * speed), transform.position.y - (wrld.x * .01f * speed));
        transform.position = position;
    }

    void CheckCollisionWithWalls()
    {
        // If it hits the top wall
        if (transform.position.y >= wrld.y - PlayerMovement.halfHeight)
            movingUp = false;
        if (transform.position.y <= -wrld.y + PlayerMovement.halfHeight)
            movingUp = true;

        if (transform.position.x > wrld.x || transform.position.x < wrld.x)
        {
            //Application.Quit();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If it collides with the left player
        if (other.gameObject.name.Equals("LeftPlayer"))
        {
            movingRight = true;
        }

        // If it collides with the right player
        if (other.gameObject.name.Equals("RightPlayer"))
        {
            movingRight = false;
        }
    }
}
