using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector3 originalPosition;
    private Button objective;
    private int button;
    private bool isShooting;
    public Vector3 OriginalPosition { get => originalPosition; set => originalPosition = value; }
    public Button Objective { get => objective; set => objective = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }
    public int Button { get => button; set => button = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
        this.IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShooting){
            TraceVector(this.Objective);
        }
    }

    /* Checking if the bullet is not already in the space of the button, if not, it gets the vector of direction
    and moves the bullet a proportion of this vector */
    void TraceVector (Button objective){
        RectTransform objectiveTrans = this.Objective.GetComponent<RectTransform>();
        RectTransform bulletTrans = gameObject.GetComponent<RectTransform>();
        Vector3 collision = objectiveTrans.localPosition;
        Vector3 origin = bulletTrans.localPosition;
        Vector3 direction = subtract(origin, collision);
        gameObject.GetComponent<RectTransform>().localPosition = addMove(origin, direction);
    }

    /* Obtaining the director vector of the two points */
    Vector3 subtract (Vector3 v1, Vector3 v2){
        return new Vector3(v2.x - v1.x, v2.y - v1.y, v2.z-v1.z);
    }

    /* Moving the bullet to where the button is moving */
    Vector3 addMove(Vector3 position, Vector3 direction){
        float move = this.speed * Time.deltaTime;
        return new Vector3(position.x + (direction.x * move), position.y + (direction.y * move), position.z);
    }

    /* Verifying if the bullet is already touching the button that the user clicked */
     private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == ("btn" + this.Button.ToString())){
            this.IsShooting = false;
            gameObject.GetComponent<RectTransform>().localPosition = this.OriginalPosition;
            gameObject.GetComponent<Image>().enabled = false;
        }
    }

     
}
