using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public int requiredOrbs = 0;
    public int currentOrbs = 0;
    public Animator anim;
    public GameObject[] orbs;
    public List<GameObject> disabledOrbs;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(GameObject orb in orbs)
        {
            orb.SetActive(false);
            disabledOrbs.Add(orb);
        }
        anim = GetComponent<Animator>();
    }

    public void CheckOrbs(int playerOrbs)
    {

        

        for(int i = 1; i<= playerOrbs; i++)
        {
            GameObject selectedOrb =  disabledOrbs[Random.Range(0, disabledOrbs.Count)];
            selectedOrb.SetActive(true);
            disabledOrbs.Remove(selectedOrb);
            currentOrbs += 1;
            OrbCollector.instance.RemoveWisp();
        }

        if (currentOrbs == requiredOrbs) ActivateGate();
    }

    public void ActivateGate()
    {
        anim.SetTrigger("openGate");
    }

    
}
