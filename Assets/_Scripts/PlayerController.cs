using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

[Header("Inscribed")]
    public bool isActive = true;
    public float speed = 8;
    public FanController activeFanController;
    public float clampedAcceleration = 200;


    [Header("Dynamic")]
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] float startingGravity;
    // Start is called before the first frame update
    void Awake(){
        playerRigid = GetComponent<Rigidbody2D>();
        startingGravity = playerRigid.gravityScale;
        if (activeFanController == null){
            print("There is no inscribed fan controller in the player controller");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activeFanController != null){
        if (activeFanController.fansEnabled == true){
        activeFanController.FloatPlayer(playerRigid);
        }
        if (!activeFanController.updatedGravity){
            activeFanController.updatedGravity = true;
            UpdateGravity();
        }
        }

        float hAxis = Input.GetAxis("Horizontal");

        float rigidVelX = speed * hAxis;
        float rigidVelY = playerRigid.velocity.y;

        Vector2 holdVel = Vector2.zero;
        holdVel.x = rigidVelX;
        holdVel.y = rigidVelY;


        //decelerate towards a steady speed, or 0 if there isnt any input
        holdVel.x = Mathf.Lerp(playerRigid.velocity.x, rigidVelX, .05f);
        

        playerRigid.velocity = holdVel;
    }

    void UpdateGravity(){
        playerRigid.gravityScale = startingGravity;
    }
}
