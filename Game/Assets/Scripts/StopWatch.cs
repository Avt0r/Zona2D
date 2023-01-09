using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{

    [SerializeField]
    private int seconds;
    [SerializeField]
    private int minutes;
    [SerializeField]
    private Text result;

    private void Start()
    {
        seconds = 0;
        minutes = 0; 
        StartCoroutine(Run());   
    }

    private IEnumerator Run()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds++;
            if(seconds == 60)
            {
                seconds = 0;
                minutes++;
            }
            string s = seconds < 10 ? "0" + seconds : "" + seconds;
            string m = minutes < 10 ? "0" + minutes : "" + minutes;
            result.text = m + ":" + s;
        }
    }
}
