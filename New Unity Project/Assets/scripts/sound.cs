using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// script for managing audio effects for the game board
/// and handling the ui button for muting auto and turning it back on
/// </summary>
public class sound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image mainImage;
    public Sprite off;
    public Sprite on;
    private bool playing;
    private AudioSource AS;

    //turn audio on or off
    public void OnPointerDown(PointerEventData eventData) 
    {
        if (playing)
        {
            AS.mute = true;
            playing = false;
        }
        else
        {
            AS.mute = false;
            playing = true;
        }
    }

    //change button ui image
    public void OnPointerUp(PointerEventData eventData)
    {

        if (playing)
            mainImage.sprite = off;
        else
            mainImage.sprite = on;

    }

    void Awake()
    {
        AS = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        playing = true;
    }

   
}
