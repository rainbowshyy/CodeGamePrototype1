using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public static Playermovement Instance { get; private set; }

    private Transform tf;

    public int xPos;
    public int yPos;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            yPos = 1;
            xPos = 4;
            tf = GetComponent<Transform>();

            VisualizePosition();
        }
    }

    public void Move(int x, int y)
    {
        xPos += x;
        xPos = KeepInRange(xPos, 1, 7);
        yPos += y;
        yPos = KeepInRange(yPos, 1, 7);

        VisualizePosition();
    }

    private void VisualizePosition()
    {
        tf.position = new Vector3(-3.5f + (float)xPos - 1f, -3.5f + (float)yPos - 1f, 0f);
    }

    public int KeepInRange(int num, int min, int max)
    {
        if (num < min)
        {
            num = min;
        }
        else if (num > max)
        {
            num = max;
        }
        return num;
    }
}
