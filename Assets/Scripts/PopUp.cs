using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PopUp: MonoBehaviour{
    private Text message;

    public Text Message { get => message; set => message = value; }
    public GameObject MessageBox { get => messageBox; set => messageBox = value; }

    private GameObject messageBox;

    void Start(){
        Message.enabled = false;
        MessageBox.SetActive(false);
    }

    void Update(){
        
    }

    // Showing the text corresponding to the answer of the user
    public void showMessage(bool itsCorrect, bool timeOut){
        if (itsCorrect){
            this.Message.text = "CORRECT";
        }
        else if (timeOut){
            this.Message.text = "LUCKY FOR THE NEXT ONE";
        }
        else{
            this.Message.text = "NICE TRY";
        }
        this.MessageBox.SetActive(true);
        this.Message.enabled = true;
        
        Invoke("timeToDissapear", 2.0f);
    }

    void timeToDissapear(){
        this.MessageBox.SetActive(false);
        this.Message.enabled = false;
    }
}