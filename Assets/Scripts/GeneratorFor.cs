using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Base class to all the levels that are going to have the user the 
opportunity to play */
public abstract class GeneratorFor{

        private int initialValue;
        private int initialFor;
        private int maxium;
        private int counter;
        private int result;
        private int increment;
        private int incrementOut;
        private char variableFor;
        private string variableName;
        private const int MAX = 122;
        private const int MIN = 97;

        private List<string> options = new List<string>(new string []{"index", "valor", "suma", "contar"});


        private int loops;
        private int type_;
        public GeneratorFor(int type_){
            this.Type_ = type_;
        }

        public char getForVariable(){
            int asciiNum = (int) Mathf.Floor(Random.Range(MIN, MAX));
            char nameOfCounter = (char) asciiNum;
            return nameOfCounter;
        }

        public string getVariableName(){
            return this.Options[(int) Mathf.Floor(Random.Range(0.0f, this.Options.Count))];
        }

        public abstract List<int> getResult();

        public abstract string generateFor(string printMessage);

        public abstract bool getAnswer(string answer, List<int> correct, PopUp popUp, Timer timer, int index);

    public int InitialValue { get => initialValue; set => initialValue = value; }
    public int InitialFor { get => initialFor; set => initialFor = value; }
    public int Maxium { get => maxium; set => maxium = value; }
    public int Counter { get => counter; set => counter = value; }
    public int Result { get => result; set => result = value; }
    public int Increment { get => increment; set => increment = value; }
    public int IncrementOut { get => incrementOut; set => incrementOut = value; }
    public int Type_ { get => type_; set => type_ = value; }
    public int Loops { get => loops; set => loops = value; }
    public char VariableFor { get => variableFor; set => variableFor = value; }
    public List<string> Options { get => options; set => options = value; }
    public string VariableName { get => variableName; set => variableName = value; }
}



