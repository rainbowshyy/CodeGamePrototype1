using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBlock", menuName = "Block")]
public class Block : ScriptableObject
{
    public string actionKey;
    public int[] param;
}
