using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    private int level = 3;
    private int sublevel = 1;
    public string printMessage;
    public Text text;
    public Text time;
    public Text _Score;
    private Timer timer;
    public int timeTo;
    public GameObject gO;
    public Text message;
    public List<Button> buttons;
    public  int GAIN_POINTS;
    private int score;
    public GameObject bullet;
    public Text question;
    public GameObject initialMessage;
    public Button continueBtn;
    public GameObject messageBox;
    public Text levelInfo;
    public Text previousAnswers;
    private Answers answers;
    private PopUp popUp;
    private GeneratorFor for_;
    private Shoot shoot;
    private bool correct;
    private bool timeOut;
    private int index;
    private int lengthQuestions;
    private int loop;
    private bool waiting;
    private float timeWaitingUser = 15f;
    private int correctAnswers;
    private int incorrectAnswers;
    
    // Start is called before the first frame update
    void Start(){
        waiting = false;
        this.index = 0;
        this.score = 0;
        
        popUp = gO.AddComponent<PopUp>();
        popUp.Message = message;
        popUp.MessageBox = messageBox;
        timer = gO.AddComponent<Timer>();
        timer.Clock = time;
        timer.TimeTo = timeTo;
        this.shoot = this.bullet.AddComponent<Shoot>();
        this.shoot.OriginalPosition = bullet.GetComponent<RectTransform>().localPosition;
        this.correct = false;
        this.timeOut = true;
        this.correctAnswers = 4;
        this.incorrectAnswers = 0;
        generateLevel();
    }

    // Update is called once per frame
    void Update(){
        if (waiting){
            this.timeWaitingUser -= Time.deltaTime;
            if (this.timeWaitingUser <= 0.0f){
                this.timer.TimeTo = 16;
                waiting = false;
                this.timeWaitingUser = 15;
                stopEverything(true);
                startQuestion();
            }
        }
        else{
            if (timer.TimeTo <= 0){
                //restartValues();
                if (this.timeOut){
                    this.popUp.showMessage(false, true);
                }
                generateLevel();
            }
        }
    }

    /* Depending on which level the user is, it gives the respective level with the question
    and the answers that is from that level. */
    void generateLevel(){
        this.shoot.IsShooting = false;
        if (this.level == 1){
            for_ = (GeneratorFor) new Level1(this.sublevel);
        }
        else if (this.level == 2){
            for_ = (GeneratorFor) new Level2(this.sublevel);
        }
        else if (this.level == 3){
            for_ = (GeneratorFor) new Level3(this.sublevel);
        }
        this.levelInfo.text = "Level " + this.level;
        text.text = for_.generateFor(this.printMessage);
        answers = new Answers(for_.getResult());
        this.loop = 1;
        waiting = true;
        stopEverything(false);
        this.lengthQuestions = this.answers.Correct.Count;
    }

    void startQuestion(){
        generateQuestion(Char.ToString(this.for_.VariableFor));
    }

    void stopEverything(bool activate){
        this.initialMessage.SetActive(!activate);
        foreach (Button item in this.buttons)
        {
            item.gameObject.SetActive(activate);
        }
        this.question.gameObject.SetActive(activate);
        this.continueBtn.gameObject.SetActive(!activate);
    }

    void generateQuestion(string nameOfVariable){
        this.timeOut = true;
        this.timeTo = 0;
        int aleatoryOrder = this.randomNumber(0, buttons.Count + 1);
        // Aleatory puts the different answers to the buttons
        getAnswersToButtons(aleatoryOrder);
        if (this.index + 1 == this.lengthQuestions){
            this.question.text = "Al finalizar el for, ¿valor de " + this.for_.VariableName + "?";
        }
        else{
            this.question.text = "Al entrar en la vuelta " + loop.ToString() + " ¿valor de " + nameOfVariable + "?";
        }
            
    }

    void getAnswersToButtons(int aleatoryOrder){
        if (aleatoryOrder == 1){
            buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Correct);
            buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
            buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
        }
        else if (aleatoryOrder == 2){
            buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Correct);
            buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
            buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
        }
        else{
            buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Correct);
            buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
            buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
        }
    }

    /* Get the button that was pressed and checks if the answer beloging to that button is the correct one */
    public void getAnswer(int num){
        this.shoot.Objective = this.buttons[num - 1];
        this.shoot.IsShooting = true;
        this.bullet.GetComponent<Image>().enabled = true;
        this.correct = for_.getAnswer(this.buttons[num - 1].GetComponentInChildren<Text>().text, this.answers.Correct, popUp, timer, this.index);
        this.shoot.Button = num;
        this.timeOut = false;
        popUp.showMessage(this.correct, this.timeOut); // Let the user know if he/she got correct it.
        if (correct){
            this.timer.TimeTo = 15;
            this.index++;
            showListOfCorrectAnswers();
            score += this.GAIN_POINTS;
            this._Score.text = score.ToString();
            if (this.index == this.lengthQuestions){
                this.correctAnswers++;
                changeLevel();
                generateLevel();
                this.index = 0;
            }
            else if (this.index-1 != 0 && this.index % 2 == 0 || this.for_.ShortFor){
                this.loop++;
                generateQuestion(Char.ToString(this.for_.VariableFor));
            }
            else{
                generateQuestion(this.for_.VariableName);
            }
        }
        else{
            restartValues();
            this.incorrectAnswers++;
            timer.TimeTo = 0; 
            showListOfCorrectAnswers();
        }
        
    }
    /* If the answer is a sequence of numbers, it concatenate the numbers. If not, only add the simple number.
     */
    string writeAnswertToButton(List<int> numbers){
        string answer = "";
        answer += numbers[this.index].ToString();
        return answer;
    }

    int randomNumber(int min, int max){
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public void continueToQuestion(){
       this.timeWaitingUser = 0f;
    }

    void changeLevel (){
        if (correctAnswers > 3){
            sublevel++;
            if (sublevel >= 3){
                if (for_.GetType() == typeof(Level1)){
                    sublevel = 1;
                    level = 2;
                }
                else if (for_.GetType() == typeof(Level2)){
                    sublevel = 1;
                    level = 3;
                }     
            }
            correctAnswers = 0;
            incorrectAnswers = 0;
        }
    }

    void showListOfCorrectAnswers(){
        if (this.index > 0 && this.index < this.lengthQuestions){
            string forSerie = Char.ToString(this.for_.VariableFor) + " ", variableSerie = this.for_.VariableName + " ";
            for (int i = 0; i < this.index; i++){
                if (i % 2 == 0){
                    forSerie += this.answers.Correct[i] + " ";
                }
                else{
                    variableSerie += this.answers.Correct[i] + " ";
                }
            }
            this.previousAnswers.text = forSerie + "\n" + variableSerie;
        }
        else {
            this.previousAnswers.text = "";
        }
    }

    void restartValues(){
        this.index = 0;
        this.loop = 0;
    }
}
