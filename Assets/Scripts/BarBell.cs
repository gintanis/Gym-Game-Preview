using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBell : MonoBehaviour
{
    public Rigidbody BB;
   
    public Vector3 BBPos;
    public bool Lifted;
    public float LiftTime;
    public KeyCode Lift;
    public GameObject scoreManager; 
  

    private void Start()
    {
      
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       BB.velocity = BBPos;

      
  
        if (Input.GetKey(Lift)  && Lifted == false )

        {
            scoreManager.SendMessage("BenchPressWorkout");
            scoreManager.GetComponent<ScoreManager>().BB = true; 
            transform.position += new Vector3(0, LiftTime, 0);
            
            Debug.Log(BBPos.y);
            
            if (transform.position.y >= 4.5f)
            {
             
                
                Lifted = true;
                BBPos.y = -Mathf.Abs(BBPos.y);
                Debug.Log(BBPos);
            }

        }
      
      

    }
    
    public void OnCollisionEnter (Collision other){
        if (other.gameObject.name == "Floor")
        {
            Lifted = false; 
        }
    }
}
