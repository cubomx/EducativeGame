public class GeneratorFor{

        private int initialValue;

        private int initialFor;

        private int maxium;
        
        private int counter;

        private int result;

        private int increment;

        private int incrementOut;

        public GeneratorFor(int initialV, int initialF, int max, int count, int increm, int incremOut){
            this.InitialValue = initialV;
            this.InitialFor = initialF;
            this.Maxium = max;
            this.Counter = count;
            this.Increment = increm;
            this.IncrementOut = incremOut;
        }

        public abstract int getResult();

    public int InitialValue { get => initialValue; set => initialValue = value; }
    public int InitialFor { get => initialFor; set => initialFor = value; }
    public int Maxium { get => maxium; set => maxium = value; }
    public int Counter { get => counter; set => counter = value; }
    public int Result { get => result; set => result = value; }
    public int Increment { get => increment; set => increment = value; }
    public int IncrementOut { get => incrementOut; set => incrementOut = value; }
}

public class Level1: GeneratorFor{
    public Level1(int initialV, int initialF, int max, int count, int increm, int incremOut) => super(initialV, initialF, max, count, increm, incremOut);

    public int getResult(){
        int result = this.InitialValue;
        for (int index = this.InitialFor; index < this.Maxium; index += this.Counter){
            
        }
    }
}

public class Answers{
    private int correct;
    private int[] incorrect;

    public int[] Incorrect { get => incorrect; set => incorrect = value; }
    public int Correct { get => correct; set => correct = value; }

    public Answers(int correct) => this.Correct = correct;

    public getOtherOptions(){
        int random = Mathf
    }
}