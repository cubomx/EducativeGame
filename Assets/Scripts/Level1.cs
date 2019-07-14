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
            res += this.IncrementOut;
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
        else if(this.Type_ == 3){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res += this.Increment;
                res += this.SecondIncrement;
            }
            result.Add(res); 
            
        }
        return result; 
    }

    /* Generate the problem that the user are going to see on screen and save the values to
    then get the result of the problem */
    public override string generateFor(string printMessage){
        if (this.Type_ == 1){
            string question = "";
            this.VariableFor = this.getForVariable();
            this.VariableName = this.getVariableName();
            this.InitialFor = (int) Mathf.Ceil(Random.Range(0f, 4.0f));
            this.Loops = (int) Mathf.Ceil(Random.Range(3.0f, 5.0f));
            this.Counter = (int) Mathf.Ceil(Random.Range(0f, 3f));
            this.InitialValue = (int)Mathf.Ceil(Random.Range(0f, 5f));
            this.Increment = (int)Mathf.Ceil(Random.Range(0f, 3f));
            this.IncrementOut = (int) Mathf.Ceil(Random.Range(0f, 2f));
            this.Maxium = (this.Loops * this.Counter) + this.InitialFor + 1; 
            int ifClause = (int)Mathf.Ceil(Random.Range(0.0f, 7.0f));
            question = "<color=#eef3f0><color=#ff5733>int </color> <color=#04d1f1>" + this.VariableFor + "</color>;\n";
            question += "<color=#ff5733>int </color> <color=#04d1f1>" + VariableName + "</color> = <color=#0ed657>" + this.InitialValue + "</color>;\n";
            question += "<color=#ac4dd2>for</color> ( <color=#04d1f1>"+ this.VariableFor + "</color> = <color=#0ed657>" + this.InitialFor + "</color>; <color=#04d1f1>" + this.VariableFor + 
            "</color> < <color=#0ed657>" + this.Maxium + "</color>; <color=#04d1f1>" + this.VariableFor +"</color> += <color=#0ed657>" + this.Counter + "</color> ){\n";
            question += "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.Increment + "</color>;\n";
            question += "\t}\n<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.IncrementOut + "</color>;\n<color=#ac4dd2>" + printMessage + "</color> <color=#04d1f1>" + this.VariableName + "</color>;</color>";
            return question;
        }
        return "";
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