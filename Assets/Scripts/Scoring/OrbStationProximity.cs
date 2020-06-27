using UnityEngine;

public class OrbStationProximity : MonoBehaviour
{
    float detectionRange = 2;
    public float thrust = 1.0f;
    bool closeEnough;
    public Transform player;
 
 void Update()
    {
        closeEnough = false;
        if (Vector3.Distance(player.position, transform.position) <= detectionRange)
        {
            closeEnough = true;
        }
        if (closeEnough && Input.GetKeyUp(KeyCode.E))
        {
            // Orb falls
            gameObject.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * thrust);
        }
    }
 }

