// This code is used to determine individual frame scores and simulates adding additional pin counts from spares and strikes

using UnityEngine;

public class FrameScoreCounter : MonoBehaviour
{

    public int timesToAddScore = 0;
    public int totalFrameScore = 0;

    public FrameScoreCounter()
    {
    }

    public void changeTimesToAddScore(int amount)
    {
        timesToAddScore += amount;
    }

    public int getTimesToAddScore()
    {
        return timesToAddScore;
    }

    public bool hasTimesToAddScore()
    {
        if (timesToAddScore >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addToTotalPins(int pins)
    {
        totalFrameScore += pins;
    }

    public int getTotalPins()
    {
        return totalFrameScore;
    }

}
