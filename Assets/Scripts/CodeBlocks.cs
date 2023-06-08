using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CodeBlocks : MonoBehaviour
{
    Dictionary<string, Delegate> actions;
    List<Block> program;
    [SerializeField]
    Block[] blocks;
    [SerializeField]
    TextMeshProUGUI text;

    int step = 0;

    private void Start()
    {
        actions = new Dictionary<string, Delegate>();
        program = new List<Block>();

        actions["move"] = new Action<int, int>(Playermovement.Instance.Move);

        //StartCoroutine(WalkRandom());
        StartCoroutine(InitProgram());
    }

    private void ProgramStep()
    {
        if (step >= program.Count)
        {
            step = 0;
        }
        if (program[step].actionKey != "null")
        {
            actions[program[step].actionKey].DynamicInvoke(program[step].param[0], program[step].param[1]);
        }
        DrawProgram();
        step += 1;
    }

    public void AddBlock(int id)
    {
        program.Add(blocks[id]);
        DrawProgram();
    }

    public void ResetProgram()
    {
        program.Clear();
        DrawProgram();
    }

    private void DrawProgram()
    {
        text.text = "current program: ";
        for (int i = 0; i < program.Count; i++)
        {
            text.text += "\n" + program[i].actionKey.ToUpper() + "(" + program[i].param[0] + ", " + program[i].param[1] + ");";
            if (step == i || (step == program.Count && i == 0))
            {
                text.text += " <==";
            }
        }
    }

    IEnumerator InitProgram()
    {
        while (true)
        {
            if (program.Count != 0)
            {
                ProgramStep();
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator WalkRandom()
    {
        while (true)
        {
            actions["move"].DynamicInvoke(Mathf.RoundToInt(UnityEngine.Random.Range(-1f, 1f)), Mathf.RoundToInt((UnityEngine.Random.Range(-1f, 1f))));
            yield return new WaitForSeconds(1f);
        }
    }
}

public class Scope
{
    public List<Block> blocks;
}

public class IfBlock : Block
{
    public Scope ifTrue;
    public Scope ifFalse;
}