using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool movingLeft;
    public Vector2 LIMITS_X;
    // Start is called before the first frame update
    void Start()
    {
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 transform = gameObject.GetComponent<RectTransform>().localPosition; //Depends if getting the position of the parent or not
        float position = transform.x;
        float moveInX = 2.0f;
        if (movingLeft){
            moveInX -= 4.0f;
        }
        position += moveInX;
        
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(position, transform.y, transform.z);
        if (position < LIMITS_X.x || position > LIMITS_X.y){
            
            movingLeft = !movingLeft;
        }
            
    }

}
