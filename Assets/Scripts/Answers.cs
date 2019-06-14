using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Answers{
    private const float LIMIT = 4.0f;
    private const float MAX = 9.0f;
    private int correct;
    private int[] incorrect;

    public int[] Incorrect { get => incorrect; set => incorrect = value; }
    public int Correct { get => correct; set => correct = value; }

    public Answers(int correct) => this.Correct = correct;

    public int [] getOtherOptions(){
        int random = (int) Mathf.Ceil(Random.Range(0.0f, MAX));
        int [] options = new int[2];
        if (random <= 4){
            options[0] = (int) Mathf.Ceil(Random.Range(0.0f, LIMIT)) - this.Correct;
            options[1] = (int) Mathf.Ceil(Random.Range(0.0f, LIMIT)) + this.Correct;
        }
        else if (random <= 7){
            options[0] = (int)  Mathf.Ceil(Random.Range(0.0f, LIMIT)) + this.Correct;
            options[1] = (int) Mathf.Ceil(Random.Range(0.0f, LIMIT)) + this.Correct;
        }
        else{
            options[0] = (int) Mathf.Ceil(Random.Range(0.0f, LIMIT)) - this.Correct;
            options[1] = (int) Mathf.Ceil(Random.Range(0.0f, LIMIT)) - this.Correct;
        }
        return options;
    }
}