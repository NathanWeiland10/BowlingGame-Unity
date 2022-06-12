// This code is used to play a custom sound effect whenever a UI button is clicked

using UnityEngine;
public class ButtonClickSound : MonoBehaviour
{

    public string soundEffect;

    public void playSoundEffect()
    {
        // Play the sound effect:
        FindObjectOfType<AudioManager>().Play(soundEffect);
    }

}
