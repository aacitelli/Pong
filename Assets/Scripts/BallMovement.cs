using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private bool movingUp, movingRight;
    private float speed;

    Vector3 position;

	// Use this for initialization
	void Start ()
    {
        // The ball starts moving up and to the right at 45 degrees
        movingUp = true;
        movingRight = true;

        // Always travels at 45 degree angles, just with varying speed
        speed = 1.0f;

        gameObject.AddComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Collision
        CheckCollisionWithWalls();

        // Upping the speed every frame by a very small amount - May need balanced in the future
        speed += .002f;

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
        position = new Vector3(transform.position.x + (.1f * speed), transform.position.y + (.1f * speed));
        transform.position = position;
    }

    void MoveDownRight()
    {
        position = new Vector3(transform.position.x + (.1f * speed), transform.position.y - (.1f * speed));
        transform.position = position;
    }

    void MoveUpLeft()
    {
        position = new Vector3(transform.position.x - (.1f * speed), transform.position.y + (.1f * speed));
        transform.position = position;
    }

    void MoveDownLeft()
    {
        position = new Vector3(transform.position.x - (.1f * speed), transform.position.y - (.1f * speed));
        transform.position = position;
    }

    void CheckCollisionWithWalls()
    {
        // If it hits the top wall
        if (transform.position.y >= 4f)
            movingUp = false;
        if (transform.position.y <= -4f)
            movingUp = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // If it collides with the left player
        if (other.gameObject.tag.Equals("LeftPlayer"))
        {
            movingRight = true;
        }

        // If it collides with the right player
        if (other.gameObject.tag.Equals("RightPlayer"))
        {
            movingRight = false;
        }
    }
}
