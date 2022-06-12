// This code is used to determine when a pin has collided with the floor and plays a sound effect when collided with

using UnityEngine;

public class PinCollisionFloor : MonoBehaviour
{

    public string[] pinRollSounds;
    bool hasHitFloor = false;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Floor" && !hasHitFloor)
        {
            int chosenSound = Random.Range(0, pinRollSounds.Length);
            FindObjectOfType<AudioManager>().Play(pinRollSounds[chosenSound]);
            hasHitFloor = true;
        }
    }
}
