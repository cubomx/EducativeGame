using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level2: GeneratorFor{
    private int secondIncrementInside;

    public int SecondIncrementInside { get => secondIncrementInside; set => secondIncrementInside = value; }

    public Level2(int type_) : base(type_){
    }

    /* Get the result of the for given to the user */
    public override List<int> getResult(){
        List<int> result = new List<int>();
        if (this.Type_ == 1){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res += this.Increment;
                res += this.SecondIncrementInside;
            }
            result.Add(res);
        }
        else if (this.Type_ == 2){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res = 0;
                res = res + this.Increment;
            }
            res += this.IncrementOut;
            result.Add(res);
        }
        return result; 
    }

    /* Generate the problem that the user are going to see on screen and save the values to
    then get the result of the problem */
    public override string generateFor(string printMessage){
        string question = "";
        question = this.getMininumValues(printMessage);
        
        if (this.Type_ == 1){
            this.SecondIncrementInside = (int)Mathf.Ceil(Random.Range(0f, 3f));
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.Increment + "</color>;\n";
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.SecondIncrementInside + "</color>;\n";
        }
        if (this.Type_ == 2){
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> = <color=#0ed657> 0 </color>;\n";
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.Increment + "</color>;\n";
        }
        question += "\t}\n";
        question += "<color=#ac4dd2>" + printMessage + "</color> <color=#04d1f1>" + this.VariableName + "</color>;</color>"; // print message
        
        return question;
    }

    /* Check if the answer is right*/

    public override bool getAnswer(string answer, List<int> correct, PopUp popUp, Timer timer, int index){
        int optionSelected = int.Parse(answer);
        if (optionSelected == correct[index]){
            return true;
        }
        return false;
    }
    
}