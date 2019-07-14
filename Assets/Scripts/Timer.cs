using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text clock;
    private int timeTo;
    private int totalTime;
    private int looped;
    public Text Clock { get => clock; set => clock = value; }
    public int TimeTo { get => timeTo; set => timeTo = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.looped = 0;
        this.totalTime = this.TimeTo;
        this.Clock.text = this.TimeTo.ToString();
        StartCoroutine("CountDown");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Clock.text = this.TimeTo.ToString();
        if (this.TimeTo <= 0){ //Restarting the clock to the initial countdown
            if (this.looped > 0){
                this.TimeTo = this.totalTime;
                this.looped = 0;
            }
            else{
                this.looped++;
            }
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
