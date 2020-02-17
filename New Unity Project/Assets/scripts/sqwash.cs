using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sqwash : MonoBehaviour
{
    
    float speed = 2f;
    float maxRotation = 30f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
      gameObject.transform.rotation = Quaternion.Euler(0, maxRotation * Mathf.Sin(Time.time * speed), 0);

    }
}
