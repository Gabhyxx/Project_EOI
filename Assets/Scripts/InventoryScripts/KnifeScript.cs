using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public GameObject lKnife,
                      rKnife;

    Animator lAnim,
             rAnim;

    private void Awake()
    {
        lAnim = lKnife.GetComponent<Animator>();
        rAnim = rKnife.GetComponent<Animator>();
    }

    private void Update()
    {
       MouseClicks();
    }

    public void MouseClicks()
    {
        
        //Debug.Log("Cuchillo Izquierdo: " + lKnife.name);
        bool l = Input.GetMouseButtonDown(0);
        //lAnim.SetBool("isIdle", false);

        lAnimation(l);

        //Debug.Log("Cuchillo Derecho: " + rKinfe.name);
        bool r = Input.GetMouseButtonDown(1);
        rAnimation(r);

    }
    void lAnimation(bool l)
    {
        if (l)
        {
            lAnim.SetBool("isAttacking", true);
        }
        else
        {
            lAnim.SetBool("isAttacking", false);
        }
    }

    void rAnimation(bool r)
    {
        if (r)
        {
            //rAnim.SetBool("isIdle", false);
            rAnim.SetBool("isAttacking", true);
        }
        else
        {
            //rAnim.SetBool("isIdle", true);
            rAnim.SetBool("isAttacking", false);
        }
    }
}
