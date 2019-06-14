using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ForGenerator : MonoBehaviour
{
    
    private string question;
    public string variableName;
    public string printMessage;
    public Text text;
    public Text time;
    private Timer timer;
    public int timeTo;
    public GameObject gO;
    
    // Start is called before the first frame update
    void Start()
    {
        hola h;
        h.nombre = 2;
        generateFor();
        timer = gO.AddComponent<Timer>();
        timer.timer = time;
        timer.timeTo = timeTo;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeTo == 0)
        {
              generateFor();
        }
        
    }

    void generateFor(){
        int counter = (int) Mathf.Ceil(Random.Range(0f, 5f));
            int start = (int)Mathf.Ceil(Random.Range(0f, 5f));
            int maxium = (int)Mathf.Ceil(Random.Range(3.0f, 10.0f));
            int ifClause = (int)Mathf.Ceil(Random.Range(0.0f, 7.0f));
            this.question = "int " + this.variableName + " = " + start + ";\n";
            this.question += "for (int i = 0; i < " + maxium + " i+=" + counter + "){\n";
            this.question += "\t\t" + this.variableName + " += 1\n";
            if (ifClause >= 4)
            {
                this.question += "\t\tif (i % 3 == 0){\n\t\t\t" + this.variableName + " =0\n\t\t}\n";
            }
            else
            {
                this.question += "\t\tif (i % 2 == 0){\n\t\t\t" + this.variableName + "+=1\n\t\t}\n";
            }
            this.question += "\t}\n" + printMessage;
            
            text.text = this.question;
    }


    int getValueAtEnd(){

    }


}
