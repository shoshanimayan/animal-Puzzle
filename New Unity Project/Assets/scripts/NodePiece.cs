using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// class for the handling of the actual board pieces, the way they look and behave
/// </summary>
public class NodePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int value;
    public Point index;

    public Vector2 pos;
    public RectTransform rect;
    bool updating;
    Image img;
    MovePieces mp;
    float speed  = 2f;
    float maxRotation = 30f;

    public void Awake()
    {
        mp = GameObject.Find("Match3").GetComponent<MovePieces>();
    }
    public void Initialize(int v, Point p, Sprite piece)
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        mp = MovePieces.instance;
        value = v;
        SetIndex(p);
        img.sprite = piece;
    }

    public void SetIndex(Point p)
    {
        index = p;
        ResetPosition();
        UpdateName();
    }

    public void ResetPosition()
    {
        pos = new Vector2(32 + (64 * index.x), -32 - (64 * index.y));
    }

    public void MovePosition(Vector2 move)
    {
        rect.anchoredPosition += move * Time.deltaTime * 16f;
    }

    public void MovePositionTo(Vector2 move)
    {
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, move, Time.deltaTime * 16f);
    }

    public bool UpdatePiece()
    {
        if (Vector3.Distance(rect.anchoredPosition, pos) > 1)
        {
            MovePositionTo(pos);
            updating = true;
            return true;
        }
        else
        {
            rect.anchoredPosition = pos;
            updating = false;
            return false;
        }
    }

    void UpdateName()
    {
        transform.name = "Node [" + index.x + ", " + index.y + "]";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (updating) return;
        Debug.Log(transform.name);
        mp.MovePiece(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mp.DropPiece();
    }

    public void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, maxRotation * Mathf.Sin(Time.time * speed));
    }
}