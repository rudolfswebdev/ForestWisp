using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispTemple : MonoBehaviour
{
    public GameObject orb;
    public int requiredMinions = 0;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        orb.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void CheckMinions(int minions)
    {
        if( minions >= requiredMinions)
        {
            Debug.Log(minions);
            Debug.Log(requiredMinions);
            if (orb.gameObject != null)
            {
                orb.GetComponent<Rigidbody>().isKinematic = false;
                orb.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * speed);
                orb.tag = "orb";
            }
            
        }
    }

    
}
