﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public int level;
    private string question;
    public string variableName;
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
    private Answers answers;
    private PopUp popUp;
    private GeneratorFor for_;
    private Shoot shoot;
    private bool correct;
    private bool timeOut;
    // Start is called before the first frame update
    void Start(){
        this.score = 0;
        generateLevel();
        popUp = gO.AddComponent<PopUp>();
        popUp.Message = message;
        timer = gO.AddComponent<Timer>();
        timer.Clock = time;
        timer.TimeTo = timeTo;
        shoot = gO.AddComponent<Shoot>();
        shoot.Bullet = bullet;
        shoot.OriginalPosition = bullet.GetComponent<RectTransform>().localPosition;
        this.correct = false;
        this.timeOut = true;
    }

    // Update is called once per frame
    void Update(){
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

    /* Depending on which level the user is, it gives the respective level with the question
    and the answers that is from that level. */
    void generateLevel(){
        if (level == 1){
            
            for_ = (GeneratorFor) new Level1(1);
        }
        else if (level == 2){
            for_ = (GeneratorFor) new Level2(1);
        }
        
        text.text = for_.generateFor(this.variableName, this.printMessage);
        List<int> result = for_.getResult();
        answers = new Answers(result);
        int aleatoryOrder = (int) Mathf.Ceil(Random.Range(0.0f, buttons.Capacity));
        for(int item = 0; item < buttons.Capacity; item++){
            // Aleatory puts the different answers to the buttons
            if (aleatoryOrder == 1){
                buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(result);
                buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
                buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
            }
            else if (aleatoryOrder == 2){
                buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(result);
                buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
                buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
            }
            else{
                buttons[0].GetComponentInChildren<Text>().text = writeAnswertToButton(result);
                buttons[1].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[0]);
                buttons[2].GetComponentInChildren<Text>().text = writeAnswertToButton(answers.Incorrect[1]);
            }
        }
    }

    /* Get the button that was pressed and checks if the answer beloging to that button is the correct one */
    public void getAnswer(int num){
        this.shoot.Objective = this.buttons[num - 1];
        this.shoot.IsShooting = true;
        this.bullet.GetComponent<Image>().enabled = true;
        this.correct = for_.getAnswer(this.buttons[num - 1].GetComponentInChildren<Text>().text, this.answers.Correct, popUp, timer);
        this.timeOut = false;
        popUp.showMessage(this.correct, this.timeOut); // Let the user know if he/she got correct it.
        if (correct){
            score += this.GAIN_POINTS;
            this._Score.text = score.ToString();
        }
        timer.TimeTo = 0; 
    }
    /* If the answer is a sequence of numbers, it concatenate the numbers. If not, only add the simple number.
     */
    string writeAnswertToButton(List<int> numbers){
        string answer = "";
        int size = numbers.Capacity/sizeof(int);
        for (int index = 0; index < size; index++){
            answer += numbers[index];
            if (index+1 <= size){
                answer += " ";
            }
        }
        return answer;
    }
}