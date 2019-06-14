using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public int timeTo;
    private int totalTime;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = timeTo;
        timer.text = this.timeTo.ToString();
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = this.timeTo.ToString();
        if (timeTo == 0){
            timeTo = totalTime;
        }
    }

    IEnumerator CountDown(){
        while (true){
            yield return new WaitForSeconds(1.0f);
            timeTo--;
        }
    }
}
