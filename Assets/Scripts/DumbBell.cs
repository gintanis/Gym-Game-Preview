using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbBell : MonoBehaviour
{
    public Rigidbody DB; 
    public KeyCode Lift;
    public Vector3 DBPos;
    public bool Lifted;
    public float LiftTime;
    public GameObject scoreManager; 

 
 
    public void Awake()
    {
      
        
    }

    // Start is called before the first frame update
    void Start()
    {

   
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DB.velocity = DBPos;
        //RightLifted = Lifting == KeyCode.D; 
  
        if (Input.GetKey(Lift) && Lifted == false )
        {
            scoreManager.SendMessage("DumbBellWorkout");
           // scoreManager.GetComponent<ScoreManager>().DB= true;                     
            transform.position += new Vector3(0, LiftTime, 0);
            Debug.Log(DBPos.y);       
        }

        if (transform.position.y >= 3.3f)
        {                            
            Lifted = true;
            DBPos.y = -Mathf.Abs(DBPos.y);
        }

    }
    
    public void OnCollisionEnter (Collision other){
        if (other.gameObject.name == "Floor")
        {
            Lifted = false;
        }
    }
}


