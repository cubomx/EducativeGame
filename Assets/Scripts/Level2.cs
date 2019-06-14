using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level2: GeneratorFor{
    private int mod;

    public int Mod { get => mod; set => mod = value; }

    public Level2(int type_) : base(type_){
        this.Mod = mod;
    }

    public override int getResult(){
        int result = this.InitialValue;
        for (int index = this.InitialFor; index < this.Maxium; index +=this.Counter){
            result++;
            if (index % this.Mod == 0){
                result = 0;
            }
        }
        return result; 
    }

    public override string generateFor(string variableName, string printMessage){
        string question = "";
        this.Counter = (int) Mathf.Ceil(Random.Range(0f, 5f));
        this.InitialValue = (int)Mathf.Ceil(Random.Range(0f, 5f));
        this.Mod = 2;
        this.Maxium = (int)Mathf.Ceil(Random.Range(3.0f, 10.0f));
        int ifClause = (int)Mathf.Ceil(Random.Range(0.0f, 7.0f));
        question = "int " + variableName + " = " + this.InitialValue + ";\n";
        question += "for (int i = 0; i < " + this.Maxium + " i+=" + this.Counter + "){\n";
        question += "\t\t" + variableName + " += 1\n";
        if (ifClause >= 4){
            this.Mod = 3;
            question += "\t\tif (i % 3 == 0){\n\t\t\t" + variableName + " =0\n\t\t}\n";
        }
        else{
            question += "\t\tif (i % 2 == 0){\n\t\t\t" + variableName + "+=1\n\t\t}\n";
        }
        question += "\t}\n" + printMessage;
        
        return question;
    }
    
}