using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Spike")){
            print("spike");
        }
    }
}
