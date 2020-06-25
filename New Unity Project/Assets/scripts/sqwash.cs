using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// script for ui effect to squash text or image
/// </summary>

public class sqwash : MonoBehaviour
{
    
    float speed = 2f;
    float maxRotation = 30f;


    // Update is called once per frame
    void Update()
    {
      gameObject.transform.rotation = Quaternion.Euler(0, maxRotation * Mathf.Sin(Time.time * speed), 0);

    }
}
