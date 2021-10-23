using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    PlayerMovement2 Instance;

    public float PitchMultiplier = 50, RollMultiplier = 50, ForwardSpeed = 60, CamFollowBias = 0.995f, CamOffsetZ = 30, CamOffsetY = 5, CamLookAtOffset = 100, MinSpeed = 5, MaxSpeed = 60, StallMultiplier = 20;

    public float up = 30, Gravity = 5;

    bool isRising = false;
    public bool TurnOffGravity = false;
    // Start is called before the first frame update
    private Animator Anim;
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }

        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //cam movement 
       // Vector3 MoveCamTo = transform.position - transform.forward * CamOffsetZ + Vector3.up * CamOffsetY;
        //Camera.main.transform.position = Camera.main.transform.position * CamFollowBias + MoveCamTo * (1 - CamFollowBias)  ;
        //Camera.main.transform.LookAt(transform.position + transform.forward * CamLookAtOffset );
        

        //playermovement
        float xIn = Input.GetAxis("Horizontal");
        float yIn = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 0);

        transform.position += new Vector3(xIn * RollMultiplier * Time.deltaTime, yIn  * PitchMultiplier * Time.deltaTime,  0);
        Anim.SetFloat("Pitch", yIn);
        Anim.SetFloat("Roll", xIn);

        transform.position += Vector3.forward * Time.deltaTime * ForwardSpeed; //Move forward 
        if (!TurnOffGravity)
        {
            if (isRising)
            {
                transform.position += Vector3.up * up * Time.deltaTime; // slowly move up
               // Anim.SetFloat("Pitch", 1);
            }
            else
            {
                transform.position += Vector3.down * Gravity * Time.deltaTime; // slowly move down
                //Anim.SetFloat("Pitch", 0);
            }
        }
        
    }

    Vector3 GetInput()
    {
        Debug.Log(Input.GetAxis("Mouse X"));
        //Input.GetAxis("Mouse X");
        Vector3 Temp = new Vector3(0,0,0);
        
        Temp.x = Input.GetAxis("Vertical") * PitchMultiplier * Time.deltaTime;

        float HIn = -Input.GetAxis("Horizontal");
        if (transform.eulerAngles.z + HIn <= 90 || transform.eulerAngles.z + HIn >= 270)
        {
            Temp.z = HIn * RollMultiplier * Time.deltaTime;
        }

        return Temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in wind");
        if (other.gameObject.CompareTag("Wind"))
        {
           

            isRising = true;

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("out wind");
        if (other.gameObject.CompareTag("Wind"))
        {

            isRising = false;
        }
    }



}
