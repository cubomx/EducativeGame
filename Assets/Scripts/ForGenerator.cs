using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ForGenerator : MonoBehaviour
{
    public int level;
    private string question;
    public string variableName;
    public string printMessage;
    public Text text;
    public Text time;
    private Timer timer;
    public int timeTo;
    public GameObject gO;

    private GeneratorFor for_;
    
    // Start is called before the first frame update
    void Start()
    {
        generateLevel();
        timer = gO.AddComponent<Timer>();
        timer.timer = time;
        timer.timeTo = timeTo;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeTo == 0)
        {
            generateLevel();
        }
        
    }

    void generateLevel(){
        if (level == 1){
            for_ = (GeneratorFor) new Level1(1);
        }
        else if (level == 2){
            for_ = (GeneratorFor) new Level2(1);
        }
        text.text = for_.generateFor(this.variableName, this.printMessage);
    }

}
