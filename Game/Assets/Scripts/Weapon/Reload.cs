using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool reloadState = true;
    [SerializeField]
    private float delay;

    public void ReloadIdle()
    {
        anim.Play("ReloadIdle");
    }

    public void ReloadStart(float delay)
    {
        anim.Play("ReloadStart");
        reloadState = false;
        this.delay = delay;
        StartCoroutine(Wait());
    }

    public void ReloadRun()
    {
        anim.Play("ReloadRun");
    }

    private void ReloadFinish()
    {
        reloadState = true;
        ReloadIdle();
    }

    public bool IsReloadFinished()
    {
        return reloadState;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        ReloadFinish();
    }
}
