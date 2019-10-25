using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class MouseLook : MonoBehaviour
{
    [Header("Show Text")] public Text Instructions;
    public Image ShadeBox;
    public GameObject WorkoutManager;
    public float verticalAngle = 0f;


    [Header("Turn On and Turn Off Station")]
    public GameObject player;
    public GameObject dumbBellOne;
    public GameObject dumbBellTwo;
    public GameObject barBell;
    public GameObject scoreManager; 
    //public LayerMask layerMask;
   // [SerializeField] private Material highlight; 
    // Update is called once per frame


     void Start()
    {
        player = GameObject.Find("Player");
        scoreManager.GetComponent<ScoreManager>().enabled = false; 
        Instructions.GetComponent<Text>().enabled = false;
        ShadeBox.GetComponent<Image>().enabled = false;
        dumbBellOne.GetComponent<DumbBell>().enabled = false;
        dumbBellTwo.GetComponent<DumbBell>().enabled = false;
        barBell.GetComponent<BarBell>().enabled = false; 
    }

    void Update()
    {
         
        float RayDist = 7f; 
   
        
            /*if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * RayDist, Color.green);
               
                if (Physics.Raycast(ray, out hit, RayDist, layerMask ))
                {
                    Instructions.GetComponent<Text>().enabled = true;
                    ShadeBox.GetComponent<Image>().enabled = true;
                    Instructions.text = "Click to Workout";
                        Debug.Log(hit.collider.name);
                    
                    
                }

            } */
        
        // WORKS!        
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * RayDist, Color.green);
               
        if (Physics.Raycast(ray, out hit, RayDist))
        {
           
            Debug.Log(hit.collider.name);
            
            if (hit.collider.CompareTag("Equipment" ))
            {
                
                Instructions.GetComponent<Text>().enabled = true;
                ShadeBox.GetComponent<Image>().enabled = true;
                Instructions.text = "Click to Workout";

           
                if (Input.GetMouseButton(0))

                {
                    scoreManager.GetComponent<ScoreManager>().enabled = true;
                    scoreManager.GetComponent<ScoreManager>().GameMeter.fillAmount = .05f;
                    scoreManager.GetComponent<ScoreManager>().Meter.fillAmount = 1f; 
                    
                    if (Input.GetMouseButton(0) && hit.collider.name == "DumbBell" ||
                        hit.collider.name == "DumbBellTwo")
                    {
                        dumbBellOne.GetComponent<DumbBell>().enabled = true;
                        dumbBellTwo.GetComponent<DumbBell>().enabled = true;
                        player.GetComponent<PlayerController>().willLift = true;
                        Instructions.GetComponent<Text>().enabled = true;
                        ShadeBox.GetComponent<Image>().enabled = true;
                        Instructions.text = "Press A and D to Lift";
                    }


                  /*  if (Input.GetMouseButton(0) && hit.collider.name == "Bench")
                    {
                        player.SendMessage("GetInPosition");
                        player.GetComponent<PlayerController>().willLift = true;
                        Instructions.GetComponent<Text>().enabled = true;
                        ShadeBox.GetComponent<Image>().enabled = true;
                        Instructions.text = "Press E to Lift";
                    } */

                    
                    if (Input.GetMouseButton(0) && hit.collider.name == "BarBell")
                    {
                        barBell.GetComponent<BarBell>().enabled = true;
                        player.GetComponent<PlayerController>().willLift = true;                        
                    }

                    if (Input.GetMouseButton(0) && hit.collider.name == "PullUpBar")
                    {
                        player.GetComponent<PlayerController>().pullUP = true; 
                        player.GetComponent<PlayerController>().willLift = true;
                        Instructions.GetComponent<Text>().enabled = true;
                        ShadeBox.GetComponent<Image>().enabled = true;
                        Instructions.text = "Press E to Lift";
                    }
                }
                
                

                if (Input.GetMouseButton(1))
                {
                    scoreManager.GetComponent<ScoreManager>().enabled = false;

                    if (Input.GetMouseButton(1) && hit.collider.name == "DumbBell" ||
                        hit.collider.name == "DumbBellTwo")
                    {
                        dumbBellOne.GetComponent<DumbBell>().enabled = false;
                        dumbBellTwo.GetComponent<DumbBell>().enabled = false;
                        player.GetComponent<PlayerController>().willLift = false;
                        Instructions.GetComponent<Text>().enabled = false;
                        ShadeBox.GetComponent<Image>().enabled = false;
                        scoreManager.GetComponent<ScoreManager>().enabled = false;

                    }


                    if (Input.GetMouseButton(1) && hit.collider.name == "BarBell")
                    {
                        barBell.GetComponent<BarBell>().enabled = false;
                        barBell.transform.position = new Vector3(0, 2, -1);
                        player.GetComponent<PlayerController>().willLift = false;
                        player.SendMessage("GetOutPosition");
                        Instructions.GetComponent<Text>().enabled = false;
                        ShadeBox.GetComponent<Image>().enabled = false;
                        scoreManager.GetComponent<ScoreManager>().enabled = false;

                    }




                    if (Input.GetMouseButton(1) && hit.collider.name == "PullUpBar")
                    {
                        player.GetComponent<PlayerController>().willLift = false;
                        player.GetComponent<PlayerController>().pullUP = false;
                        Instructions.GetComponent<Text>().enabled = false;
                        ShadeBox.GetComponent<Image>().enabled = false;

                    }
                }

            }

        }
        
       
       
        else 
        {
            Instructions.GetComponent<Text>().enabled = false;
            ShadeBox.GetComponent<Image>().enabled = false; 
        }



      
        
        
        
        
       
        float mouseY = Input.GetAxis("Mouse Y"); //vertical mouse velocity
        float mouseX = Input.GetAxis("Mouse X");
        transform.parent.Rotate(0f, mouseX * 10f, 0f);
        verticalAngle -= mouseY * 10f;        
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);
        transform.localEulerAngles = new Vector3(verticalAngle, transform.localEulerAngles.y, 0f);
    }

}