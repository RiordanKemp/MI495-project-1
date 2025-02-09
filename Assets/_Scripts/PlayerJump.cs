using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [Header("Inscribed")]
    public KeyCode jump = KeyCode.Space;
    public float jumpPower = 500;
    public int maxJumps = 1;
    public float bufferTime = 0.3f;
    public Vector2 boxSize;
    public float raycastDist;
    public LayerMask groundLayer;
    [Header("Dynamic")]
    [SerializeField] int jumpsLeft = 0;
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] float remainingBuffer = 0;

  
    void Awake(){
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump))
        {
            if (jumpsLeft > 0){Jump();}
            else{BufferJump();}
        }

        if (remainingBuffer > 0){
            if (jumpsLeft > 0){Jump();}
            remainingBuffer -= Time.deltaTime;
        }
    }

    void FixedUpdate(){
        isGrounded();

    }

    public bool isGrounded(){
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, raycastDist, groundLayer)){
         jumpsLeft = maxJumps;
            return true;
        }
        else{
            jumpsLeft = 0;
            return false;
        }
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * raycastDist, boxSize);
    }

    void Jump(){
    playerRigid.AddForce(new Vector2(playerRigid.velocity.x, jumpPower));
    jumpsLeft -= 1;
    remainingBuffer = 0;
    }

    void BufferJump(){
        remainingBuffer = bufferTime;
    }

   
}
