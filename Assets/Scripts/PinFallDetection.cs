// This code is used to determine when a pin has collided with the floor

using UnityEngine;

public class PinFallDetection : MonoBehaviour
{

    public BowlingPin pin;
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Floor")
        {
            pin.setPinFallen(true);
        }
    }

}
