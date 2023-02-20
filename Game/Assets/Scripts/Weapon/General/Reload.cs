using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void RIdle()
    {
        anim.Play("ReloadIdle");
    }

    public void RStart()
    {
        anim.Play("ReloadStart");
    }

    private void RContinue()
    {
        anim.Play("ReloadRun");
    }
}
