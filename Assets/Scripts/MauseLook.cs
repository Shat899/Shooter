using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauseLook : MonoBehaviour
{
   public Vector2 turn;
   public float sensitivity = 1f;
   
   public Vector3 deltaMove;

   public float horizontalMove;
   public float verticalMove;
   public float speed = 2f;

   public GameObject player;
   private Animator PlayerAnimator;
   void Start()
   {    // We prevent the cursor from going outside the game window
        Cursor.lockState = CursorLockMode.Locked;
        PlayerAnimator = player.GetComponent<Animator>();
   } 
    void Update()
    {
        // We receive the coordinates of the mouse
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.y = Mathf.Clamp(turn.y, -20, 20);
        // Camera rotation
        //transform.localRotation  = Quaternion.Euler(-turn.y,  turn.x, 0);
         transform.localRotation  = Quaternion.Euler(-turn.y,  0, 0);
      
        
        // Player rotation 

         player.transform.localRotation  = Quaternion.Euler(0 ,turn.x , 0);
        
        //Player movements
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        deltaMove= new Vector3(horizontalMove, 0, verticalMove) * speed * Time.deltaTime;
        player.transform.Translate(deltaMove);

    }
    void PlayerController()    
    { 
       if (verticalMove != 0)  
       {
        PlayerAnimator.SetInteger("Move", 1);
       }
       else
       {
        PlayerAnimator.SetInteger("Move", 0);
       }
    }
}
