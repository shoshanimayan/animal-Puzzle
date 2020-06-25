using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// script for handling the killded piece
/// </summary>
public class KilledPiece : MonoBehaviour
{
    public bool falling;

    float speed = 16f;
    float gravity = 32f;
    Vector2 moveDir;
    RectTransform rect;
    Image img;

    //generate killedpiece and through it
    public void Initialize(Sprite piece, Vector2 start)
    {
        falling = true;

        moveDir = Vector2.up;
        moveDir.x = Random.Range(-1.0f, 1.0f);
        moveDir *= speed / 2;

        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        img.sprite = piece;
        rect.anchoredPosition = start;
    }

    // piece falls till reaches a certain point
    //could probably be better optomized 
    void Update()
    {
        if (!falling) return;
        moveDir.y -= Time.deltaTime * gravity;
        moveDir.x = Mathf.Lerp(moveDir.x, 0, Time.deltaTime);
        rect.anchoredPosition += moveDir * Time.deltaTime * speed;
        if (rect.position.x < -64f || rect.position.x > Screen.width + 64f || rect.position.y < -64f || rect.position.y > Screen.height + 64f)
            falling = false;
    }
}