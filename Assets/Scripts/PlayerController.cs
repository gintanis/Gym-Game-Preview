using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool willLift;
    public bool pullUP;
    public bool Lifted;
    public float lifting; 
    public Vector3 MyPos;
    public Rigidbody myRigid; 
    public GameObject dbmat;
    public GameObject pumat;
    public GameObject bpmat;
    public GameObject scoreManager; 

    public KeyCode Lift; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigid.velocity = MyPos;

        if (willLift == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-.1f, 0, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(.1f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, .1f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -.1f);
            }

            }

        if (pullUP)
        {
            if (Input.GetKey(Lift) && Lifted == false)
            {
                transform.position += new Vector3(0, lifting, 0);
                scoreManager.SendMessage("PullUpWorkout");
                scoreManager.GetComponent<ScoreManager>().PU = true; 
            }

            else if (transform.position.y >= 3.3f)
            {
                Lifted = true;
                MyPos.y = -Mathf.Abs(MyPos.y);
            }
        }
    }






    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Floor")
        {
            Lifted = false; 
        }
        
  
    }


   public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "DBMat")
        {
            transform.position =  dbmat.transform.position + new Vector3(0, 1, 0);
        }
        
        
        if (collision.gameObject.name == "PUMat")
        {
            transform.position =  pumat.transform.position + new Vector3(0, 1, 0);
        }
        
        if (collision.gameObject.name == "BPMat")
        {
            transform.position =  bpmat.transform.position + new Vector3(0, 1, 0);
        }
    }
}
