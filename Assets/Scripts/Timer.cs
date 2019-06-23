using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text clock;
    private int timeTo;
    private int totalTime;

    public Text Clock { get => clock; set => clock = value; }
    public int TimeTo { get => timeTo; set => timeTo = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.totalTime = this.TimeTo;
        this.Clock.text = this.TimeTo.ToString();
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void Update()
    {
        this.Clock.text = this.TimeTo.ToString();
        if (this.TimeTo == 0){ //Restarting the clock to the initial countdown
            this.TimeTo = this.totalTime;
        }
    }

    IEnumerator CountDown(){
        //Substracts one per second
        while (true){
            yield return new WaitForSeconds(1.0f);
            this.TimeTo--;
        }
    }
}
