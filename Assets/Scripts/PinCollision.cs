// This code is used to determine when a pin has collided with the player's ball and plays a sound effect when hit

using UnityEngine;

public class PinCollision : MonoBehaviour
{

    public string[] pinHitBallSounds;
    bool hasBeenHitBall = false;

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player" && !hasBeenHitBall)
        {
            int chosenSound = Random.Range(0, pinHitBallSounds.Length);
            FindObjectOfType<AudioManager>().Play(pinHitBallSounds[chosenSound]);
            hasBeenHitBall = true;
        }
    }


}