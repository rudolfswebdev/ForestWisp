using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int minions = 0;
    public int orbs = 0;
    // Start is called before the first frame update
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

                    if (Input.GetKeyDown(KeyCode.E) && hitColliders[i].gameObject.GetComponent<FollowPlayer>().stationary == true)
                    {
              
                        hitColliders[i].gameObject.GetComponent<FollowPlayer>().StartFollow();
                        minions++;
                    }
                    break;
                case "wisp_temple":
                    hitColliders[i].gameObject.GetComponent<wispTemple>().CheckMinions(minions);
                    break;
                case "orb":
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitColliders[i].gameObject);
                        orbs += 1;
                        OrbCollector.instance.AddWisp();
                    }
                    break;
                case "gate":
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(orbs != 0)
                        {
                            hitColliders[i].gameObject.GetComponent<GateScript>().CheckOrbs(orbs);
                            orbs = 0;
                        }else
                        {
                            OrbCollector.instance.DisplayWispsRequired();
                        }
                       
                    }
                    break;
                case "portal":
                    OrbCollector.instance.DisplayEndScreen();
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
