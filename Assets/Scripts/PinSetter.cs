// This code was previously used to set up 10 pins in an organized manner for testing and debugging purposes

using UnityEngine;

public class PinSetter : MonoBehaviour
{
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

}
