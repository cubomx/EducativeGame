using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PopUp: MonoBehaviour{
    public Text message;

    void Start(){
        message.enabled = false;
    }

    void Update(){
        
    }

    // Showing the text corresponding to the answer of the user
    public void showMessage(bool itsCorrect){
        if (itsCorrect){
            message.text = "CORRECT";
        }
        else{
            message.text = "INCORRECT";
        }
        message.enabled = true;
        Invoke("timeToDissapear", 2.0f);
    }

    void timeToDissapear(){
        message.enabled = false;
    }
}