// This code is used to determine when the player ball has collided with a stop wall and will stop a sound effect when collided with

using UnityEngine;

public class RollStopWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Stop("BallRoll1");
        }
    }
}