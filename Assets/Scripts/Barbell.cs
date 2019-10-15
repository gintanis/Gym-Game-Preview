using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbell : MonoBehaviour
{
    public Rigidbody BB;
    public GameObject Bench; 
    public Vector3 BBPos;
    public bool Lift;
 
    public bool PlayerOnBench;
    public float PushForce;
    public GameObject gameManager; 
   
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BB.velocity = BBPos;
        
        
       

        if (Input.GetKey(KeyCode.UpArrow) && Lift == false)
        {
            transform.position += new Vector3(0, PushForce, 0);
          
           gameManager.SendMessage("BenchPressWorkout");
        }


        if (transform.position.y >= 4.5f)
        {

            Lift = true; 
            BBPos.y = -Mathf.Abs(BBPos.y);
        }

        if (transform.position.y <= 3.0f)
        {
            Lift = false; 
        }

        if (PlayerOnBench == false)
        {
            transform.position = Bench.transform.position + new Vector3(0f, 1.3f, -2f);
        }


    }


    public void StartWorkout()
    {
       transform.position = Bench.transform.position + new Vector3(0f, 1.3f, -1f);
        PlayerOnBench = true; 
        Lift = false; 

    }

    public void EndWorkout()
    {
        PlayerOnBench = false;

    }


 
}

