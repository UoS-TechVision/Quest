using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] int num;
    [SerializeField] int[] code; //4 digit code (0-99)
    [SerializeField] Dial dial;
    [SerializeField] float[] wheelPack; //angle of each wheel
    [SerializeField] int[] wheelPackNGradians; //value of each wheel
    [SerializeField] bool unlocked = false;

    void Start()
    {
        wheelPack = new float[code.Length];
        wheelPackNGradians = new int[code.Length];
        for (int i = 0; i < num; i++)
        {
            wheelPack[i] = 0.0f;
            wheelPackNGradians[i] = 0;
        }
    }
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
            wheelPackNGradians[i] = n_gradians(wheelPack[i], num); //convert angle to dial value
        }

        bool cracked = true;
        for (int i = 0; i < wheelPack.Length; i++) //compare to code
        {
            if (wheelPackNGradians[i] != code[wheelPack.Length - 1 - i])
            {
                cracked = false;
                break;
            }
        }
        if (cracked && !unlocked)
        {
            unlocked = true;
            Debug.Log("You Win!"); //REPLACE HERE!!!!!!!!!!!
        }
    }

    int n_gradians(float a, int n)
    {
        return mod_n(Mathf.RoundToInt(a * (float)n/360f), n);
    }
    int mod_n(int a, int n)
    {
        return (Mathf.Abs(a * n) + a) % n;
    }
}
