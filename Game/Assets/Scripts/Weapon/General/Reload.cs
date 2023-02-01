using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private void ReloadIdle()
    {
        anim.Play("ReloadIdle");
    }

    public void ReloadStart(float delay)
    {
        anim.Play("ReloadStart");
        StartCoroutine(Wait(delay));
    }

    private void ReloadRun()
    {
        anim.Play("ReloadRun");
    }

    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReloadIdle();
    }
}
