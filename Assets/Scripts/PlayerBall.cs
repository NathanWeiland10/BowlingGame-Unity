// This script is used to control the main components of the player's ball, such as the ball's weight and movement:

using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public CameraFollower camFollow;
    public float downwardPushForce;
    public float moveSpeed;
    public Rigidbody ballRB;
    public Camera mainCamera;
    public float powerSliderSpeed;
    public float minLaunchPower;
    public float maxLaunchPower;
    public float turnSpeed;

    GameManager gameManager;

    float timer;
    float launchPower;
    float launchSliderValue;

    bool isLaunching = false;
    bool canLaunch = true;
    bool allowForces = false;

    void Start()
    {
        timer = Mathf.PI / (powerSliderSpeed * 2);
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (isLaunching)
        {
            timer += Time.deltaTime;

            launchSliderValue = (1 - Mathf.Abs(Mathf.Sin(timer * powerSliderSpeed)));
            launchPower = ((1 - Mathf.Abs(Mathf.Sin(timer * powerSliderSpeed))) * maxLaunchPower) + minLaunchPower;

            if (Input.GetKeyDown(KeyCode.Space) && canLaunch)
            {
                FindObjectOfType<AudioManager>().Play("BallThrow1");
                FindObjectOfType<AudioManager>().Play("BallRoll1");
                allowForces = true;
                isLaunching = false;
                canLaunch = false;
                timer = Mathf.PI / (powerSliderSpeed * 2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && canLaunch)
        {
            isLaunching = true;
        }
    }

    private void FixedUpdate()
    {
        if (allowForces)
        {
            ballRB.drag = 0f;
            ballRB.AddForce(Vector3.forward * launchPower);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ballRB.AddForce(Vector3.left * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ballRB.AddForce(Vector3.right * turnSpeed);
        }

    }

    public void stopCameraMovement()
    {
        camFollow.changeFollowTarget(false);
        gameManager.waitForPins();
    }

    public float getLaunchSliderValue()
    {
        return launchSliderValue;
    }

    public void resetLaunch()
    {
        canLaunch = true;
        isLaunching = false;
        allowForces = false;
        launchPower = 0f;
        launchSliderValue = 0f;
        timer = Mathf.PI / (powerSliderSpeed * 2);
        ballRB.drag = 5f;
    }

}
