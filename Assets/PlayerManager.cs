using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int minions = 0;
    public int orbs = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20.0f);
        
        int i = 0;
        while (i < hitColliders.Length)
        {
            switch (hitColliders[i].gameObject.tag)
            {
                case "minion":
                    Debug.Log("THERE IS A MINION");
                    if (Input.GetKeyDown(KeyCode.E) && hitColliders[i].gameObject.GetComponent<FollowPlayer>().stationary == true)
                    {
              
                        hitColliders[i].gameObject.GetComponent<FollowPlayer>().StartFollow();
                    }
                    break;
            }
            i++;
        }
    }

    public void RemoveOrbs(int toll)
    {
        orbs -= toll;
    }

}
