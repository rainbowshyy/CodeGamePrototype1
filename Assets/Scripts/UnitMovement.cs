using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Transform tf;

    public int xPos;
    public int yPos;

    void Awake()
    {
        xPos = Mathf.RoundToInt(tf.position.x);
        yPos = Mathf.RoundToInt(tf.position.y);
        VisualizePosition();
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

    private int KeepInRange(int num, int min, int max)
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
