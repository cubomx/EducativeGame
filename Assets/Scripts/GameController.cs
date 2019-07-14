using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public int level;
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
    // Start is called before the first frame update
    void Start(){
        waiting = false;
        this.index = 0;
        this.score = 0;
        generateLevel();
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
            if (!this.correct && this.timeOut){
                this.popUp.showMessage(false, true);
            }
            else{
                this.timeOut = true;
            }
            generateLevel();
        }
        }
    }

    /* Depending on which level the user is, it gives the respective level with the question
    and the answers that is from that level. */
    void generateLevel(){
        
        if (this.level == 1){
            for_ = (GeneratorFor) new Level1(1);
        }
        else if (this.level == 2){
            for_ = (GeneratorFor) new Level2(1);
        }
        
        text.text = for_.generateFor(this.printMessage);
        answers = new Answers(for_.getResult());
        Debug.Log("Tamaño: " + this.answers.Correct.Count);
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
            score += this.GAIN_POINTS;
            this._Score.text = score.ToString();
            if (this.index == this.lengthQuestions){
                generateLevel();
                this.index = 0;
            }
            else if (this.index-1 != 0 && this.index % 2 == 0){
                this.loop++;
                generateQuestion(Char.ToString(this.for_.VariableFor));
            }
            else{
                generateQuestion(this.for_.VariableName);
            }
        }
        else{
            timer.TimeTo = 0; 
            this.index = 0;
            this.loop = 0;
        }
        
    }
    /* If the answer is a sequence of numbers, it concatenate the numbers. If not, only add the simple number.
     */
    string writeAnswertToButton(List<int> numbers){
        string answer = "";
        int size = numbers.Count;
        if (this.level == 1){
            answer += numbers[this.index].ToString();
        }
        else if (this.level == 2){
            for (int index = 0; index < size; index++){
                answer += numbers[index];
                if (index+1 <= size){
                    answer += " ";
                }
            }
        }
        return answer;
    }

    int randomNumber(int min, int max){
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public void continueToQuestion(){
       this.timeWaitingUser = 0f;
    }
}
