// This code is used to determine when a pin falls to perform an action, such as playing a sound effect

using UnityEngine;

public class BowlingPin : MonoBehaviour
{

    public PinFallDetection fallDetector;
    public bool fallen = false;
    public Transform centerOfMass;
    public Rigidbody pinRB;

    public void setPinFallen(bool fall)
    {
        fallen = fall;
    }

    public bool getPinFallen()
    {
        return fallen;
    }

}
