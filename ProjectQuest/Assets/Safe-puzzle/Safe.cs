using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] int[] code;
    [SerializeField] Dial dial;
    [SerializeField] float[] wheelPack = {0f,0f,0f,0f};
    [SerializeField] float[] wheelPackGradians = {0f,0f,0f,0f};
    [SerializeField] int stage = 0;

    void Start()
    {
    }
    void Update()
    {
        wheelPack[0] = dial.fullRotations * 360f + dial.transform.eulerAngles.z;
        for (int i = 0; i < wheelPack.Length - 1; i++)
        {
            if (wheelPack[i] > wheelPack[i+1] + 360f)
            {
                wheelPack[i+1] = wheelPack[i] - 360f;
            }
            else if (wheelPack[i] < wheelPack[i+1] - 360f)
            {
                wheelPack[i+1] = wheelPack[i] + 360f;
            }
        }

        // for (int i = 0; i < wheelPack.Length; i++)
        // {
        //     wheelPackGradians[i] = wheelPack[i] * 100f/360f;
        // }

        bool cracked = true;
        for (int i = 0; i < wheelPack.Length; i++)
        {
            if (Mathf.Round(wheelPack[i] * 100f/360f) != code[i])
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
}
