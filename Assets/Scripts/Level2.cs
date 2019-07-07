using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level2: GeneratorFor{
    private int mod;

    public int Mod { get => mod; set => mod = value; }

    public Level2(int type_) : base(type_){
        this.Mod = mod;
    }

    /* Get the result of the for given to the user */
    public override List<int> getResult(){
        List<int> result = new List<int>();
        int res = this.InitialValue;
        for (int index = this.InitialFor; index < this.Maxium; index +=this.Counter){
            res++;
            if (index % this.Mod == 0){
                res = 0;
            }
        }
        result.Add(res);
        return result; 
    }

    /* Generate the problem that the user are going to see on screen and save the values to
    then get the result of the problem */
    public override string generateFor(string printMessage){
        string question = "";
        this.Counter = (int) Mathf.Ceil(Random.Range(0f, 5f));
        this.VariableName = this.getVariableName();
        this.InitialValue = (int)Mathf.Ceil(Random.Range(0f, 5f));
        this.Mod = 2;
        this.Maxium = (int)Mathf.Ceil(Random.Range(3.0f, 10.0f));
        int ifClause = (int)Mathf.Ceil(Random.Range(0.0f, 7.0f));
        question = "int " + this.VariableName  + " = " + this.InitialValue + ";\n";
        question += "for (int i = 0; i < " + this.Maxium + " i+=" + this.Counter + "){\n";
        question += "\t\t" + this.VariableName + " += 1\n";
        if (ifClause >= 4){
            this.Mod = 3;
            question += "\t\tif (i % 3 == 0){\n\t\t\t" + this.VariableName  + " =0\n\t\t}\n";
        }
        else{
            question += "\t\tif (i % 2 == 0){\n\t\t\t" + this.VariableName  + "+=1\n\t\t}\n";
        }
        question += "\t}\n" + printMessage;
        
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