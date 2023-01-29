using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlock : Block
{
    [HideInInspector] public Block Next;
    [HideInInspector] public Block Previous;

    public type Type;
    public enum type
    {
        Line,
        L
    }
}
