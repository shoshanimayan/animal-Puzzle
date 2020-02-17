using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour, IPointerDownHandler
{
    public enum button {endless,timed }
    public button btn;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (btn) {
            case (button.endless):
                SceneManager.LoadScene(1);
                break;
            case (button.timed):
                SceneManager.LoadScene(2);
                break;

        }
    }

   
}
