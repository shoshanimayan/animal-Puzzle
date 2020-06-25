using System.Collections;
using UnityEngine;
[System.Serializable]
public class ArrayLayout
{
    /// <summary>
    /// stores layout of game board and contents
    /// </summary>
    [System.Serializable]
    public struct rowdata{public bool[] row;}

    public Grid grid;
    public rowdata[] rows=new rowdata[14];
}
