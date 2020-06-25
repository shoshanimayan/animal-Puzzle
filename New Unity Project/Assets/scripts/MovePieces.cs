using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    /// <summary>
    /// script for handling movement based on mouse or finger position
    /// </summary>
    public static MovePieces instance;
    Match3 game;

    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        game = GetComponent<Match3>();
    }

    void Update()
    {
        if (moving != null)
        {
            Vector2 dir = ((Vector2)Input.mousePosition - mouseStart);
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.clone(moving.index);
            Point add = Point.zero;
            if (dir.magnitude > 32) // if moved mouse or finger enough
            {
                //only move in 4 possible direction no diagnol
                if (aDir.x > aDir.y)
                    add = (new Point((nDir.x > 0) ? 1 : -1, 0));
                else if (aDir.y > aDir.x)
                    add = (new Point(0, (nDir.y > 0) ? -1 : 1));
            }
            newIndex.add(add);

            Vector2 pos = game.getPositionFromPoint(moving.index);
            if (!newIndex.Equals(moving.index))
                pos += Point.mult(new Point(add.x, -add.y), 16).ToVector();
            moving.MovePositionTo(pos);
        }
    }
    //sets piece to be moved
    public void MovePiece(NodePiece piece)
    {
        if (moving != null) return;
        moving = piece;
        mouseStart = Input.mousePosition;
    }

    //drop the piece and reset it
    public void DropPiece()
    {
        if (moving == null) return;
        if (!newIndex.Equals(moving.index))
            game.FlipPieces(moving.index, newIndex, true);
        else
            game.ResetPiece(moving);
        moving = null;
    }
}