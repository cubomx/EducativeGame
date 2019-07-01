using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Answers{
    private const float MAX = 9.0f;
    private List<int> correct;
    private List<List<int>> incorrect;


    public Answers(List<int> correct){
        this.Correct = correct;
        this.Incorrect = this.getOtherOptions();
    }

    public List<int> Correct { get => correct; set => correct = value; }
    public List<List<int>> Incorrect { get => incorrect; set => incorrect = value; }


    /* Generates the other options that are going to be displayed to the user. */
    private List<List<int>> getOtherOptions(){
        int random = (int) Mathf.Ceil(Random.Range(0.0f, MAX));
        List<List<int>> options = new List<List<int>>();
        int randOption1 = (int) Mathf.Ceil(Random.Range(0.0f, 2.0f));
        int randOption2 = (int) Mathf.Ceil(Random.Range(0.0f, 4.0f));
        
        for(int i = 0; i < 2; i++){
            options.Add(new List<int>());
        }
        int size = this.Correct.Count;
        for(int index = 0; index < size; index++){
            if (random <= 4){
                if (this.Correct[index] > randOption1){
                    options[0].Add(this.Correct[index] - randOption1);
                }
                else{
                    options[0].Add(this.Correct[index] + randOption1 - 1);
                }
                
                options[1].Add(randOption2  + this.Correct[index]);
            }
            else if (random <= 7 ){
                options[0].Add(randOption1 + this.Correct[index]);
                options[1].Add(randOption2 + this.Correct[index]);
            }
            else{
                if (this.Correct[index] > randOption1){
                    options[0].Add(this.Correct[index] - randOption1);
                }
                else{
                    options[0].Add(this.Correct[index] + randOption1);
                }
                options[1].Add(this.Correct[index] + randOption2);
            }
        }
        return options;
    }
}