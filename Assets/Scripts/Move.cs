using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool movingLeft;
    public Vector2 LIMITS_X;
    private float speed = 60f;
    // Start is called before the first frame update
    void Start(){ }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 transform = gameObject.GetComponent<RectTransform>().localPosition; //Depends if getting the position of the parent or not
        float position = transform.x;
        float moveInX = 2.0f;
        if (this.movingLeft){
            moveInX -= 4.0f;
        }
        position += moveInX*speed*Time.deltaTime;
        
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(position, transform.y, transform.z);
        if (position < this.LIMITS_X.x || position > this.LIMITS_X.y){
            this.movingLeft = !this.movingLeft;
        }
    }
}
