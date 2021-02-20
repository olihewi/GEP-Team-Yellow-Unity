using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct FirePattern
{
    public List<FireSequence> sequences;
}
[System.Serializable]
public struct FireSequence
{
    public List<FirePatternElement> elements;
    public float duration;
}
[System.Serializable]
public struct FirePatternElement
{
    [Range(0, 360)] public float rotation;
    public float time;
    public BasicProjectile projectile;
}