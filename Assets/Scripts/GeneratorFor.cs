using System.Collections.Generic;
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

        private int loops;
        private int type_;
        public GeneratorFor(int type_){
            this.Type_ = type_;
        }

        public abstract List<int> getResult();

        public abstract string generateFor(string variableName, string printMessage);

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
}



