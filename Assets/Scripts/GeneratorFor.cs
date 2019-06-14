using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class GeneratorFor{

        private int initialValue;

        private int initialFor;

        private int maxium;
        
        private int counter;

        private int result;

        private int increment;

        private int incrementOut;

        private int type_;

        public GeneratorFor(int type_){
            this.Type_ = type_;
        }

        public abstract int getResult();

        public abstract string generateFor(string variableName, string printMessage);

    public int InitialValue { get => initialValue; set => initialValue = value; }
    public int InitialFor { get => initialFor; set => initialFor = value; }
    public int Maxium { get => maxium; set => maxium = value; }
    public int Counter { get => counter; set => counter = value; }
    public int Result { get => result; set => result = value; }
    public int Increment { get => increment; set => increment = value; }
    public int IncrementOut { get => incrementOut; set => incrementOut = value; }
    public int Type_ { get => type_; set => type_ = value; }
}



