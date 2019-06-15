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
                res += this.Increment;
            }
            res += this.IncrementOut;
            result.Add(res);
        }
        else if (this.Type_ == 2){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                res = 0;
                res = res + this.Increment;
            }
            res += this.IncrementOut;
            result.Add(res);
        }
        else if(this.Type_ == 3){
            int res = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                res += this.Increment;
                res += this.SecondIncrement;
            }
            result.Add(res); 
            
        }
        return result; 
    }

    /* Generate the problem that the user are going to see on screen and save the values to
    then get the result of the problem */
    public override string generateFor(string variableName, string printMessage){
        if (this.Type_ == 1){
            string question = "";
            this.Counter = (int) Mathf.Ceil(Random.Range(0f, 3f));
            this.InitialValue = (int)Mathf.Ceil(Random.Range(0f, 5f));
            this.Increment = (int)Mathf.Ceil(Random.Range(0f, 3f));
            this.IncrementOut = (int) Mathf.Ceil(Random.Range(0f, 2f));
            this.Maxium = (int)Mathf.Ceil(Random.Range(3.0f, 10.0f));
            int ifClause = (int)Mathf.Ceil(Random.Range(0.0f, 7.0f));
            question = "int " + variableName + " = " + this.InitialValue + ";\n";
            question += "for (int i = 0; i < " + this.Maxium + " i+=" + this.Counter + "){\n";
            question += "\t\t" + variableName + " += " + this.Increment + "\n";
            question += "\t}\n" + variableName + " += " + this.IncrementOut + "\n" + printMessage;
            return question;
        }
        return "";
    }

    /* Check if the answer is right*/
    public override bool getAnswer(string answer, List<int> correct, PopUp popUp, Timer timer){
        int optionSelected = int.Parse(answer);
        if (optionSelected == correct[0]){
            return true;
        }
        return false;
    }

    
}