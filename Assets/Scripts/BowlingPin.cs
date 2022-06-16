// This code is used to determine when a pin falls to perform an action, such as playing a sound effect:

using UnityEngine;

public class BowlingPin : MonoBehaviour
{

    public PinFallDetection fallDetector;
    public Transform centerOfMass;
    public Rigidbody pinRB;
    
    bool fallen;

    public void setPinFallen(bool b)
    {
        fallen = b;
    }

    public bool getPinFallen()
    {
        return fallen;
    }

}
