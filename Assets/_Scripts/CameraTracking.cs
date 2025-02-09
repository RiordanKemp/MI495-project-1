using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [Header("Inscribed")]
    public bool followPlayer = true;
    public float clampX = 3;
    public float clampY = 1;
    [Header("Dynamic")]
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 holdVec3 = new Vector3(Mathf.Clamp(player.transform.position.x, -clampX, clampX), Mathf.Clamp(player.transform.position.y, clampY, float.MaxValue), -10);
        transform.position = holdVec3;  
    }
}
