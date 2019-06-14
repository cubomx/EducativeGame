using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1: GeneratorFor{
    private int secondIncrement;

    public int SecondIncrement { get => secondIncrement; set => secondIncrement = value; }

    public Level1(int type_) : base(type_){

    }

    public override int getResult(){
        if (this.Type_ == 1){
            int result = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result += this.Increment;
            }
            result += this.IncrementOut;
            return result;
        }
        else if (this.Type_ == 2){
            int result = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result = 0;
                result = result + this.Increment;
            }
            result += this.IncrementOut;
            return result;
        }
        else if(this.Type_ == 3){
            int result = this.InitialValue;
            for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result += this.Increment;
                result += this.SecondIncrement;
            }
            return result;
        }
        return 0; 
    }

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
    
}