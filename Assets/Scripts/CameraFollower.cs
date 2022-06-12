// This code will take in a transform and set this transform to another transform

using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    bool followTarget = true;

    void Update()
    {
        if (followTarget) {
            transform.position = target.position;
        }
    }

    public void changeFollowTarget(bool b)
    {
        followTarget = b;
    }

}