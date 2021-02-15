using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Command
{
    public BezierCurve movement;
    public float duration;
}

[System.Serializable]
public struct CommandSequence
{
    public bool looping;
    public List<Command> commands;
}
