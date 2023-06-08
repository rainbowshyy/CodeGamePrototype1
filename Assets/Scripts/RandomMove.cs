using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    IEnumerator WalkRandom()
    {
        while (true)
        {
            Playermovement.Instance.Move(Mathf.RoundToInt(Random.Range(-1f, 1f)), Mathf.RoundToInt(Random.Range(-1f, 1f)));
            yield return new WaitForSeconds(1f);
        }
    }

    private void Start()
    {
        StartCoroutine(WalkRandom());
    }
}
