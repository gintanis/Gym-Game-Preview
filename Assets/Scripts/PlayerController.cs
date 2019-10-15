using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Game Stuff", order = 0)]       
    public Rigidbody MyRB;

    public GameObject gameManager; 
  //  public Image Meter;
  //  public float Fill; 
    
    [Header("Start DumbBells", order = 1)] public GameObject DbOne;
    public GameObject DbTwo;
    public bool startdb;


    [Header("Start Bench", order = 2)] public GameObject bench;
    public bool startbp;
    public GameObject barbell;

    [Header("Start Pull Ups", order = 3)] 
    public bool Grounded;
    public Vector3 RBPos; 
   

   
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DbOne = GameObject.Find("DumbBell");
        DbTwo = GameObject.Find("DumbBellTwo");
        barbell = GameObject.Find("Barbell");

        
        
        DbOne.GetComponent<DumbBells>().enabled = false; 
        DbTwo.GetComponent<DumbBells>().enabled = false;

        startbp = false;
        startdb = false;
        Grounded = false; 
    }

    
    void Update()
    {

        
        
        
        MyRB.velocity = RBPos; 

        if (Input.GetKey(KeyCode.A) && startdb == false && startbp == false)
        {
            transform.Rotate(0f, -1.5f, 0f);
        }

        if (Input.GetKey(KeyCode.D) && startdb == false && startbp == false)
        {
            transform.Rotate(0f, 1.5f, 0f);
        }

        if (Input.GetKey(KeyCode.W) && startdb == false  && startbp == false)
        {
            transform.Translate(0, 0, .1f);
        }

        if (Input.GetKey(KeyCode.S) &&  startdb == false && startbp == false )
        {
            transform.Translate(0, 0, -.1f);
        }

        if (Input.GetKey(KeyCode.Space) && startdb)
        {

                        startdb = false; 
                        DbOne.GetComponent<DumbBells>().enabled = false; 
                        DbTwo.GetComponent<DumbBells>().enabled = false;
                        barbell.GetComponent<Barbell>().enabled = false; 

        }


        if (Input.GetKey(KeyCode.Space) && startbp)
        {
            transform.position = bench.transform.position + new Vector3(3, 0, 0);
            transform.Rotate(90, 0, 0);

           
            
                startbp = false; 
            barbell.SendMessage("EndWorkout");
        }

      

        if (Input.GetKey(KeyCode.UpArrow) && Grounded)
        {
           transform.position += new Vector3(0, .5f, 0);
        }  
        
        if (transform.position.y >= 4.5f)
        {
            gameManager.SendMessage("PullUpWorkout");
         
            RBPos.y = -Mathf.Abs(RBPos.y);
            Grounded = false;
        }


        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Grounded = false; 

        }



    }


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "DBMat")
        {
            DbOne.GetComponent<DumbBells>().enabled = true; 
            DbTwo.GetComponent<DumbBells>().enabled = true;
            startdb = true; 
            transform.position = new Vector3(4.62f, 1.63f, 11.27f);
            gameManager.SendMessage("DumbBellInstructions");
        }

        if (collision.gameObject.name == "BPMat")
        {
            
            transform.position = bench.transform.position + new Vector3(0, 1, 0);
           
            transform.Rotate(-90, 180, 0);
            startbp = true;

            barbell.GetComponent<Barbell>().enabled = true; 
            barbell.SendMessage("StartWorkout");
            gameManager.SendMessage("BenchPressInstructions");
            
        }

        if (collision.gameObject.name == "PUMat")
        {
        gameManager.SendMessage("PullUpInstructions");
          Grounded = true; 
        }

     
    }

   
    
    


  
}
