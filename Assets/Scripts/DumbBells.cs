using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DumbBells : MonoBehaviour
{
    public Rigidbody DB; 
    public KeyCode Lifting;
    public Vector3 DBPos;
    public bool Lifted;
    public float LiftTime;
    public GameObject gameManager; 

    
    [Header("Timer Shit")]
    public Image Box;
    public Text Timer;
    public float WorkoutTime; 
   
    // Start is called before the first frame update
    void Start()
    {
     
        
        gameManager = GameObject.Find("GameManager");
        Box.GetComponent<Image>().enabled = false;
        Timer.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DB.velocity = DBPos;

        if (Input.GetKey(Lifting) && Lifted == false )
        {
            transform.position += new Vector3(0, LiftTime, 0);
           // transform.Translate(0, .2f, 0);
            gameManager.SendMessage("DumbBellWorkout");
           

        }
 

        if (transform.position.y >= 1.5f)
        {
             
                
            Lifted = true;
            DBPos.y = -Mathf.Abs(DBPos.y);
        }

        if (transform.position.y <= .39f)
        {
            Lifted = false; 
        }


        
    }


   
    


   


 
}
