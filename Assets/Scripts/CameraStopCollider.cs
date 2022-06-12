// This code is used to stop the camera from moving forward when the ball reaches close enough to the pins

using UnityEngine;

public class CameraStopCollider : MonoBehaviour
{
    public bool hasCollided;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            hasCollided = true;
            c.gameObject.GetComponent<PlayerBall>().stopCameraMovement();
        }
    }

}
