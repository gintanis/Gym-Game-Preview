using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("Mini Game Stuff")]
    public float Fill;
    public Image Meter;
    public float Score;
    public float Hit;
    public GameObject Db; 
 
    [Header("Score Stuff")]
    public Image GameMeter;

    public bool DB;
    public bool BB;
    public bool PU; 



    public bool BPComplete; 
    public bool DBComplete;
    public bool PUComplete;

   
    // public bool BP; 

    
    
    // Start is called before the first frame update
    void Start()
    {
        BPComplete = false;
        DBComplete = false;
        PUComplete = false; 
        GameMeter.fillAmount = .02f;
        
        Meter.fillAmount = 1;

    }

    // Update is called once per frame
    void Update()
    {
  
            Meter.fillAmount -= .01f;

        if (Meter.fillAmount <= Hit)
        {
            Meter.color = Color.red;
        }
        else if (Meter.fillAmount >= Hit)
        {
            Meter.color = Color.green;
        }

        if (BPComplete && PUComplete && DBComplete)
        {
            End();
        }
        
      
    }





  


    public void DumbBellWorkout()
    {
        
        if (Meter.color == Color.red)
        {
            Meter.fillAmount = 1;
            GameMeter.fillAmount += Score; 

        }
        if (GameMeter.fillAmount == 1)
        {
            DBComplete = true; 
          
        }
        if (Meter.fillAmount <= 0)
        {
            GameMeter.fillAmount = .05f; 
        }
    }
 
        
    public void PullUpWorkout()
    {

       
        if (Meter.color == Color.red)
        {
            Meter.fillAmount = 1;
            GameMeter.fillAmount += Score; 
            
        }
        if (GameMeter.fillAmount == 1)
        {
            PUComplete = true; 
                
        }
        if (Meter.fillAmount <= 0)
        {
            GameMeter.fillAmount = .05f; 
        }
     



    }
    
    public void BenchPressWorkout()
    {
      
       
        if (Meter.color == Color.red)
        {
            Meter.fillAmount = 1;
            GameMeter.fillAmount += Score; 
            
        }
        if (GameMeter.fillAmount == 1)
        {
            BPComplete = true;
           
        }
        if (Meter.fillAmount <= 0)
        {
            GameMeter.fillAmount = .05f; 
        }
     
    }


       
    
    
  
    
    
    
 /*   public void DumbBellWorkout()
    {
        
        if (Meter.color == Color.red)
        {
            Meter.fillAmount = 1;
            Score += Fill;
            
        }
        if (GameMeter.fillAmount == 1)
        {
            DBComplete = true; 
          
        }
       
       

      


    }
    
    public void PullUpWorkout()
    {

       
            if (Meter.color == Color.red)
            {
                Meter.fillAmount = 1;
                Score += Fill;
            
            }
            if (GameMeter.fillAmount == 1)
            {
                PUComplete = true; 
                
            }
           
      
        } */

    public void End()
    {

        SceneManager.LoadScene("PlayerWon");

    }



}


    
   


    

