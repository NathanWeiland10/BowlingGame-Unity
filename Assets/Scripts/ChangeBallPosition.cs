// This code is used to reset the position of the ball

using UnityEngine;

public class ChangeBallPosition : MonoBehaviour
{

    public GameObject playerBall;

    public void resetBallPosition()
    {
        playerBall.transform.position = new Vector3(0f,2f,-51f);
        playerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
