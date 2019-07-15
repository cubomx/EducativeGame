using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1: GeneratorFor{
    private int secondIncrement;

    public int SecondIncrement { get => secondIncrement; set => secondIncrement = value; }

    public Level1(int type_) : base(type_){

    }
    /* Get the result of case that was selected aleatory */
    public override List<int> getResult(){
        List<int> result = new List<int>();
        if (this.Type_ == 1){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res += this.Increment;
            }
            result.Add(res);
        }
        else if (this.Type_ == 2){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res = res - this.Increment;
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
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.Increment + "</color>;\n\t}\n";
        }
        else if (this.Type_ == 2){
            this.IncrementOut = (int) Mathf.Ceil(Random.Range(0f, 2f));
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> -= <color=#0ed657>" + this.Increment + "</color>;\n\t}\n";
            question += "<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.IncrementOut + "</color>;\n";
        }
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