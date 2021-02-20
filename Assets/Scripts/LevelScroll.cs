using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    public Vector2 scroll;
    void Update()
    {
        transform.position += new Vector3(scroll.x,scroll.y,0) * Time.deltaTime;
    }
}
