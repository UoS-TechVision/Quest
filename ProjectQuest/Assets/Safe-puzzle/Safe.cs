using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] int[] code; //4 digit code (0-99)
    [SerializeField] Dial dial;
    [SerializeField] float[] wheelPack = {0f,0f,0f,0f}; //angle of each wheel
    [SerializeField] int[] wheelPackGradians = {0,0,0,0}; //value of each wheel
    void Update()
    {
        wheelPack[0] = dial.fullRotations * 360f + dial.transform.eulerAngles.z; //first wheel follows the dial
        for (int i = 0; i < wheelPack.Length - 1; i++) //loop through other wheels
        {
            if (wheelPack[i] > wheelPack[i+1] + 360f)
            {
                wheelPack[i+1] = wheelPack[i] - 360f;
            }
            else if (wheelPack[i] < wheelPack[i+1])
            {
                wheelPack[i+1] = wheelPack[i];
            }
        }

        for (int i = 0; i < wheelPack.Length; i++)
        {
            wheelPackGradians[i] = gradians(wheelPack[i]); //convert angle to dial value
        }

        bool cracked = true;
        for (int i = 0; i < wheelPack.Length; i++) //compare to code
        {
            if (wheelPackGradians[i] != code[wheelPack.Length - 1 - i])
            {
                cracked = false;
                break;
            }
        }
        if (cracked)
        {
            Debug.Log("You Win!");
        }
    }

    int gradians(float a)
    {
        return mod100(Mathf.RoundToInt(a * 100f/360f));
    }
    int mod100(int a)
    {
        return (Mathf.Abs(a * 100) + a) % 100;
    }
}
