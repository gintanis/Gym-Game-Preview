using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else  if (Input.GetMouseButton(1))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }   
}
