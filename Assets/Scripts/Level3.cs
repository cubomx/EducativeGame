using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level3 : GeneratorFor{

    public Level3(int type_) : base(type_){
    }
   public override List<int> getResult(){
        List<int> result = new List<int>();
        int index;
        int res = this.InitialValue;
        if (this.Type_ == 1){
            for (index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res += this.Increment;
            }
            res += this.IncrementOut;
        }
        else if (this.Type_ == 2){
            for (index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
            }
            res += index * 2 + 1;
        }
        else if (this.Type_ == 3){
            for (index = this.InitialFor; index < this.Maxium; index += this.Counter){
                result.Add(index);
                result.Add(res);
                res = index * 2 + 1;
            }
        }
        result.Add(res);
        return result; 
    }

    public override string generateFor(string printMessage){
        string question = "";
        question = this.getMininumValues(printMessage);
        
        if (this.Type_ == 1){
            this.IncrementOut = (int) Mathf.Ceil(Random.Range(0f, 2f));
            question += "\n" + "\t\t<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.Increment + "</color>;\n";
            question += "<color=#04d1f1>" + VariableName + "</color> += <color=#0ed657>" + this.IncrementOut + "</color>;" +  "\n";
        }
        else if (this.Type_ == 2){
            this.ShortFor = true;
            question += "{\n\t\t<color=#ac4dd2>" + printMessage + "</color> <color=#04d1f1>" + this.VariableFor + "</color>;" + "\n\t}\n";
            question += "<color=#04d1f1>" + this.VariableName + "</color> = " + "<color=#04d1f1> " + this.VariableFor + 
            "</color>  * <color=#0ed657> 2 </color> + <color=#0ed657> 1 </color>;\n";
        }
        else if (this.Type_ == 3){
            question += "{\n\t\t" + "<color=#04d1f1>" + this.VariableName + "</color> = " + "<color=#04d1f1> " + this.VariableFor + 
            "</color>  * <color=#0ed657> 2 </color> + <color=#0ed657> 1 </color>;\n" + "\t\t";
        }
        question += "<color=#ac4dd2>" + printMessage + "</color> <color=#04d1f1>" + this.VariableName + "</color>;"; // print message
        
        if (this.Type_ == 3){
            question += "\n}";
        }
        question += "</color>";
        return question;
    }
}