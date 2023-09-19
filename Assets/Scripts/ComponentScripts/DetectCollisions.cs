using UnityEngine;

/*  DETECT COLLISION COMPONENT SCRIPT
 *  
 *  VERSION: 2021.11.02 AUTHOR: T. Smith
 *  
 *  DESCRIPTION
 *  
 *  Script is used for detecting collisions in-game
 *  Script will detect when player collides with game object
 *  Script is modular for any collision detection
 *  
 *  DIRECTIONS FOR USE:
 *  
 *  1. Inside script, set whatever event will be initialized from a collision
 *
*/

public class DetectCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name + " collided with " + gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name + " collided with " + gameObject.name);
        }
    }
}
