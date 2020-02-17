using System.Collections;
using UnityEngine;
[System.Serializable]
public class ArrayLayout
{
    [System.Serializable]
    public struct rowdata{public bool[] row;}

    public Grid grid;
    public rowdata[] rows=new rowdata[14];
}
