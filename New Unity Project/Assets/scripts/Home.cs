using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour, IPointerDownHandler
{
    //return home button
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);

   }
}
