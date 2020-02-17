using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class sound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image mainImage;
    public Sprite off;
    public Sprite on;
    private bool playing;
    private AudioSource AS;
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

    public void OnPointerUp(PointerEventData eventData)
    {

        if (playing)
            mainImage.sprite = off;
        else
            mainImage.sprite = on;

    }

    // Start is called before the first frame update
    void Awake()
    {
        AS = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
