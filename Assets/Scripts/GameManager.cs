using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Meter Shit")]
    public Image Meter;
    public float Fill;
    public int Score;
    public Image ShadeBox;
    public Text Instructions;
    public float TextTimer;
    public bool TimerStart;
    

    public bool BP;
    public bool DB;
    public bool PU;
   


    [Header("End Game")] public bool End;
    private float Filled = 1;  

    public void Start()
    {
  
        ShadeBox.GetComponent<Image>().enabled = false;
        Instructions.GetComponent<Text>().enabled = false; 
    }

    void Update()
    {
      
        if (TimerStart)
        {
            TextTimer -= Time.deltaTime; 
        }

        if (TextTimer <= 0)
        {
          
            NoText();
            ShadeBox.GetComponent<Image>().enabled = false;
            Instructions.GetComponent<Text>().enabled = false; 
        }
        
      
        
        
        if (Meter.fillAmount == Filled)
        {
            End = true; 
            Debug.Log("YOU WIN");
          
        }
    }

    public void NoText()
    {
        TimerStart = false; 
        TextTimer = 6f; 
     
    }
    
    public void DumbBellInstructions()
    {

        DB = true; 
        TimerStart = true;
       
        if (TimerStart)
        {
            ShadeBox.GetComponent<Image>().enabled = true;
            Instructions.GetComponent<Text>().enabled = true;
            Instructions.text = "Press A and D to lift DumbBells. Press Space to end.";
        }

        //TimerStart = true; 
        
      

    }
    

 public void DumbBellWorkout()
 {
     
         Meter.fillAmount += Fill;
         Score += 1;
     
 }

    public void PullUpInstructions()
    {
        PU = true;
       
        TimerStart = true;
        if (TimerStart)
        {
            ShadeBox.GetComponent<Image>().enabled = true;
            Instructions.GetComponent<Text>().enabled = true;
            Instructions.text = "Press Up Arrow to do Pull Ups. Press Space to end.";
        }

      

    }
    public void PullUpWorkout()
    {
        if (PU)
        {
            Meter.fillAmount += Fill;
            Score += 1;
        }
    }



    public void BenchPressInstructions()
    {
        TimerStart = true;
        BP = true; 
        if (TimerStart)
        {
            ShadeBox.GetComponent<Image>().enabled = true;
            Instructions.GetComponent<Text>().enabled = true;
            Instructions.text = "Press Up Arrow to do Bench Presses. Press Space to end.";
        }
        
    }
    
    public void BenchPressWorkout()
    {
        if (BP)
        {
            Meter.fillAmount += Fill;
            Score += 1;
        }
    }


    public void EndGame()
    {

        if (End)
        {
            SceneManager.LoadScene("PlayerWon");
        }
    }
    
}
