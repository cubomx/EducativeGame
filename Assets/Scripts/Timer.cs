using System.Collections;
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
        if (timeTo == 0){ //Restarting the clock to the initial countdown
            timeTo = totalTime;
        }
    }

    IEnumerator CountDown(){
        //Substracts one per second
        while (true){
            yield return new WaitForSeconds(1.0f);
            timeTo--;
        }
    }
}
