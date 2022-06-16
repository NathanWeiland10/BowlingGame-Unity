// This code is used to simulate a majority of the components of the game, such as adding and updating the player's score, adjusting the UI, and determining when the game has ended:

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject resetGameCanvas;
    bool showResetGameCanvas = false;

    public Camera endScreenCamera;
    public Transform endScreenCameraSpawnPoint;

    public Slider powerSlider;

    bool gameEnded = false;

    public TMP_Text[] totalScoresTexts;

    public TMP_Text[] frameFirstThrowTexts;
    public TMP_Text[] frameSecondThrowTexts;
    public TMP_Text tenthFrameThirdThrowText;

    public int totalPinCount = 0;

    public int framePinCount;
    public int twoFramePinCount;

    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    GameObject player;

    public float pinWaitTime;

    bool willHaveThirdThrowInTenth = false;

    float pinTimer = 0f;
    bool timerActive = false;
    bool pinsFinished = false;
    public int frameCounter;

    public int currentFrame = 1;

    bool endTheGame = false;
    bool pastTenth = false;
    bool stopEnding = false;

    FrameScoreCounter[] frameScores = new FrameScoreCounter[10];

    public bool onSpare = false;

    public GameObject pin;
    public float pinSpacingAmount;
    public float yFloorHeight;

    GameObject pin1;
    GameObject pin2;
    GameObject pin3;
    GameObject pin4;
    GameObject pin5;
    GameObject pin6;
    GameObject pin7;
    GameObject pin8;
    GameObject pin9;
    GameObject pin10;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("AlleyAmbience");
        int i = 0;
        foreach (FrameScoreCounter f in frameScores)
        {
            frameScores[i] = gameObject.AddComponent<FrameScoreCounter>();
            i++;
        }

        // Set the player to be in the first frame and instantiate / setup the pins:
        frameCounter = 1;
        player = Instantiate(playerPrefab, new Vector3(playerSpawnPoint.position.x, playerSpawnPoint.position.y, playerSpawnPoint.position.z), Quaternion.identity);
        pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
        pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
        pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
        pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
        pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
        pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
        pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
        pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
        pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
        pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
    }

    void Update()
    {
        if (showResetGameCanvas)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                resetGameCanvas.GetComponent<RestartGame>().restartGame();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<AudioManager>().Stop("AlleyAmbience");
                resetGameCanvas.GetComponent<RestartGame>().loadMainMenu();
            }
        }

        if (player != null) {
            PlayerBall pBall = FindObjectOfType<PlayerBall>();
            powerSlider.value = pBall.getLaunchSliderValue();
        }

        if (endTheGame && !stopEnding)
        {
            timerActive = false;

            if (pin1 != null)
            {
                if (pin1.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin2 != null)
            {
                if (pin2.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin3 != null)
            {
                if (pin3.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin4 != null)
            {
                if (pin4.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin5 != null)
            {
                if (pin5.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin6 != null)
            {
                if (pin6.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin7 != null)
            {
                if (pin7.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin8 != null)
            {
                if (pin8.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin9 != null)
            {
                if (pin9.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }
            if (pin10 != null)
            {
                if (pin10.GetComponent<BowlingPin>().getPinFallen())
                {
                    framePinCount++;
                }
            }

            frameSecondThrowTexts[currentFrame - 1].text = framePinCount.ToString();
            if (framePinCount == 0)
            {
                frameSecondThrowTexts[currentFrame - 1].text = "-";
            }

            frameScores[9].addToTotalPins(framePinCount);

            frameScores[currentFrame - 1].addToTotalPins(framePinCount);

            for (int i = 0; i < currentFrame; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    totalPinCount += frameScores[k].getTotalPins();
                }
                totalScoresTexts[i].text = totalPinCount.ToString();
                totalPinCount = 0;
            }

            Destroy(pin1);
            Destroy(pin2);
            Destroy(pin3);
            Destroy(pin4);
            Destroy(pin5);
            Destroy(pin6);
            Destroy(pin7);
            Destroy(pin8);
            Destroy(pin9);
            Destroy(pin10);

            Instantiate(endScreenCamera, new Vector3(endScreenCameraSpawnPoint.position.x, endScreenCameraSpawnPoint.position.y, endScreenCameraSpawnPoint.position.z), Quaternion.identity);

            resetGameCanvas.SetActive(true);
            showResetGameCanvas = true;

            stopEnding = true;
        }

        if (timerActive) {
            pinTimer -= Time.deltaTime;
            if (pinTimer <= 0)
            {
                pinsFinished = false;
                if (frameCounter == 2 && currentFrame == 10 && !willHaveThirdThrowInTenth && !endTheGame && pastTenth)
                {
                    if (twoFramePinCount + checkForSpare() < 10) {
                        endTheGame = true;
                        frameCounter = 1;
                        timerActive = false;
                    }
                }

                if (!gameEnded) 
                {
                    setUpPins();
                }

                if (currentFrame == 10 && frameCounter == 1 && !willHaveThirdThrowInTenth && !endTheGame)
                {
                    pastTenth = true;
                }

                frameCounter++;

                if (frameCounter == 3 && !willHaveThirdThrowInTenth)
                {
                    frameCounter = 1;
                }
            }
        }
    }

    public void waitForPins()
    {
        pinTimer = pinWaitTime;
        timerActive = true;
    }

    public void setUpPins()
    {
        if (!endTheGame)
        {
            if (!pinsFinished && frameCounter == 1)
            {
                Destroy(player);
                player = Instantiate(playerPrefab, new Vector3(playerSpawnPoint.position.x, playerSpawnPoint.position.y, playerSpawnPoint.position.z), Quaternion.identity);
                if (!pin1.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin1);
                    pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin1);
                }
                if (!pin2.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin2);
                    pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin2);
                }
                if (!pin3.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin3);
                    pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin3);
                }
                if (!pin4.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin4);
                    pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin4);
                }
                if (!pin5.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin5);
                    pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin5);
                }
                if (!pin6.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin6);
                    pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin6);
                }
                if (!pin7.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin7);
                    pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin7);
                }
                if (!pin8.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin8);
                    pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin8);
                }
                if (!pin9.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin9);
                    pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin9);
                }
                if (!pin10.GetComponent<BowlingPin>().getPinFallen())
                {
                    Destroy(pin10);
                    pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                else
                {
                    framePinCount++;
                    twoFramePinCount++;
                    Destroy(pin10);
                }
                int j = 0;
                
                foreach (FrameScoreCounter f in frameScores)
                {
                    if (frameScores[j].hasTimesToAddScore())
                    {
                        frameScores[j].addToTotalPins(framePinCount);
                        frameScores[j].changeTimesToAddScore(-1);
                    }
                    j++;
                }

                frameScores[currentFrame - 1].addToTotalPins(framePinCount);

                for (int i = 0; i < currentFrame; i++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        totalPinCount += frameScores[k].getTotalPins();
                    }
                    totalScoresTexts[i].text = totalPinCount.ToString();
                    totalPinCount = 0;
                }

                if (framePinCount == 10)
                {
                    Destroy(pin1);
                    pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
                    Destroy(pin2);
                    pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin3);
                    pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin4);
                    pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin5);
                    pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin6);
                    pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin7);
                    pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin8);
                    pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin9);
                    pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin10);
                    pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);

                    if (currentFrame != 10)
                    {
                        frameScores[currentFrame - 1].changeTimesToAddScore(2);
                    }
                    if (currentFrame == 10 && frameCounter == 3)
                    {
                        tenthFrameThirdThrowText.text = "X";
                    }
                    else
                    {
                        frameFirstThrowTexts[currentFrame - 1].text = "X";
                    }

                    if (currentFrame == 10)
                    {
                        willHaveThirdThrowInTenth = true;
                    }
                    else
                    {
                        currentFrame++;
                        frameCounter = 0;
                        twoFramePinCount = 0;
                    }
                }

                if (framePinCount != 10)
                {
                    frameFirstThrowTexts[currentFrame - 1].text = framePinCount.ToString();
                }
                if (framePinCount == 0 && frameCounter != 3)
                {
                    frameFirstThrowTexts[currentFrame - 1].text = "-";
                }

                pinsFinished = true;
                pinTimer = pinWaitTime;
                timerActive = false;

                if (!gameEnded) {
                    framePinCount = 0;
                }

            }
            else if (!pinsFinished && frameCounter == 2)
            {
                Destroy(player);
                player = Instantiate(playerPrefab, new Vector3(playerSpawnPoint.position.x, playerSpawnPoint.position.y, playerSpawnPoint.position.z), Quaternion.identity);
                if (pin1 != null)
                {
                    if (!pin1.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin1);
                        pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin1);
                    }
                }
                if (pin2 != null)
                {
                    if (!pin2.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin2);
                        pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin2);
                    }
                }
                if (pin3 != null)
                {
                    if (!pin3.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin3);
                        pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin3);
                    }
                }
                if (pin4 != null)
                {
                    if (!pin4.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin4);
                        pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin4);
                    }
                }
                if (pin5 != null)
                {
                    if (!pin5.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin5);
                        pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin5);
                    }
                }
                if (pin6 != null)
                {
                    if (!pin6.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin6);
                        pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin6);
                    }
                }
                if (pin7 != null)
                {
                    if (!pin7.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin7);
                        pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin7);
                    }
                }
                if (pin8 != null)
                {
                    if (!pin8.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin8);
                        pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin8);
                    }
                }
                if (pin9 != null)
                {
                    if (!pin9.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin9);
                        pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin9);
                    }
                }
                if (pin10 != null)
                {
                    if (!pin10.GetComponent<BowlingPin>().getPinFallen())
                    {
                        Destroy(pin10);
                        pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    }
                    else
                    {
                        framePinCount++;
                        twoFramePinCount++;
                        Destroy(pin10);
                    }
                }

                if (currentFrame != 10)
                {
                    Destroy(pin1);
                    pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
                    Destroy(pin2);
                    pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin3);
                    pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin4);
                    pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin5);
                    pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin6);
                    pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin7);
                    pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin8);
                    pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin9);
                    pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin10);
                    pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                else if (currentFrame == 10 && (framePinCount == 10 || twoFramePinCount == 10))
                {
                    Destroy(pin1);
                    pin1 = Instantiate(pin, new Vector3(0f, yFloorHeight, 0f), Quaternion.identity);
                    Destroy(pin2);
                    pin2 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin3);
                    pin3 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 1f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin4);
                    pin4 = Instantiate(pin, new Vector3(-2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin5);
                    pin5 = Instantiate(pin, new Vector3(0f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin6);
                    pin6 = Instantiate(pin, new Vector3(2f * pinSpacingAmount, yFloorHeight, 2f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin7);
                    pin7 = Instantiate(pin, new Vector3(-3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin8);
                    pin8 = Instantiate(pin, new Vector3(-1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin9);
                    pin9 = Instantiate(pin, new Vector3(1f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                    Destroy(pin10);
                    pin10 = Instantiate(pin, new Vector3(3f * pinSpacingAmount, yFloorHeight, 3f * pinSpacingAmount), Quaternion.identity);
                }
                int j = 0;
                
                foreach (FrameScoreCounter f in frameScores)
                {
                    if (frameScores[j].hasTimesToAddScore())
                    {
                        frameScores[j].addToTotalPins(framePinCount);
                        frameScores[j].changeTimesToAddScore(-1);
                    }
                    j++;
                }

                frameScores[currentFrame - 1].addToTotalPins(framePinCount);

                for (int i = 0; i < currentFrame; i++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        totalPinCount += frameScores[k].getTotalPins();
                    }
                    totalScoresTexts[i].text = totalPinCount.ToString();
                    totalPinCount = 0;
                }

                if (twoFramePinCount != 10)
                {
                    frameSecondThrowTexts[currentFrame - 1].text = framePinCount.ToString();
                }
                else
                {
                    frameSecondThrowTexts[currentFrame - 1].text = "/";
                }

                if (framePinCount == 0 && frameCounter != 3)
                {
                    frameSecondThrowTexts[currentFrame - 1].text = "-";
                }
                if (framePinCount == 10)
                {
                    frameSecondThrowTexts[currentFrame - 1].text = "X"; // Change this to a '/'?
                }

                if (twoFramePinCount == 10)
                {
                    onSpare = true;
                    if (currentFrame != 10)
                    {
                        frameScores[currentFrame - 1].changeTimesToAddScore(1);
                    }
                    if (currentFrame == 10)
                    {
                        willHaveThirdThrowInTenth = true;
                    }
                }

                if (currentFrame != 10)
                {
                    currentFrame++;
                }

                if (!willHaveThirdThrowInTenth)
                {
                    twoFramePinCount = 0;
                }

                pinsFinished = true;
                pinTimer = pinWaitTime;
                timerActive = false;

                framePinCount = 0;
                
            }
            else if (!pinsFinished && frameCounter == 3)
            {
                if (pin1 != null)
                {
                    if (pin1.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin2 != null)
                {
                    if (pin2.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin3 != null)
                {
                    if (pin3.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin4 != null)
                {
                    if (pin4.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin5 != null)
                {
                    if (pin5.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin6 != null)
                {
                    if (pin6.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin7 != null)
                {
                    if (pin7.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin8 != null)
                {
                    if (pin8.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin9 != null)
                {
                    if (pin9.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }
                if (pin10 != null)
                {
                    if (pin10.GetComponent<BowlingPin>().getPinFallen())
                    {
                        framePinCount++;
                    }
                }

                frameScores[9].addToTotalPins(framePinCount);
                tenthFrameThirdThrowText.text = framePinCount.ToString();

                if (framePinCount == 0)
                {
                    tenthFrameThirdThrowText.text = "-";
                }
                if (framePinCount == 10)
                {
                    tenthFrameThirdThrowText.text = "X";
                }
                if (framePinCount < 10 && framePinCount + twoFramePinCount >= 20)
                {
                    tenthFrameThirdThrowText.text = "/";
                }

                for (int i = 0; i < currentFrame; i++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        totalPinCount += frameScores[k].getTotalPins();
                    }
                    totalScoresTexts[i].text = totalPinCount.ToString();
                    totalPinCount = 0;
                }

                Destroy(pin1);
                Destroy(pin2);
                Destroy(pin3);
                Destroy(pin4);
                Destroy(pin5);
                Destroy(pin6);
                Destroy(pin7);
                Destroy(pin8);
                Destroy(pin9);
                Destroy(pin10);

                Destroy(player);

                resetGameCanvas.SetActive(true);

                Instantiate(endScreenCamera, new Vector3(endScreenCameraSpawnPoint.position.x, endScreenCameraSpawnPoint.position.y, endScreenCameraSpawnPoint.position.z), Quaternion.identity);
                showResetGameCanvas = true;

                pinsFinished = true;
            }
        }
    }

    public int checkForSpare()
    {
        int testPinCount = 0;
        if (pin1 != null)
        {
            if (pin1.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin2 != null)
        {
            if (pin2.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin3 != null)
        {
            if (pin3.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin4 != null)
        {
            if (pin4.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin5 != null)
        {
            if (pin5.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin6 != null)
        {
            if (pin6.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin7 != null)
        {
            if (pin7.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin8 != null)
        {
            if (pin8.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin9 != null)
        {
            if (pin9.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        if (pin10 != null)
        {
            if (pin10.GetComponent<BowlingPin>().getPinFallen())
            {
                testPinCount++;
            }
        }
        return testPinCount;
    }

}
