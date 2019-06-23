using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
   private float speed = 0.05f;
    private Vector3 originalPosition;
    private Button objective;
    private bool isShooting;
    private GameObject bullet;

    public Vector3 OriginalPosition { get => originalPosition; set => originalPosition = value; }
    public Button Objective { get => objective; set => objective = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.Bullet.GetComponent<Image>().enabled = false;
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
        RectTransform bulletTrans = this.Bullet.GetComponent<RectTransform>();
        if (!doesItOverlaps(objectiveTrans, bulletTrans)){
            Vector3 collision = objectiveTrans.localPosition;
            Vector3 origin = bulletTrans.localPosition;
            Vector3 direction = subtract(origin, collision);
            this.Bullet.GetComponent<RectTransform>().localPosition = addMove(origin, direction);
        }
        else{
            this.IsShooting = false;
            this.Bullet.GetComponent<RectTransform>().localPosition = this.OriginalPosition;
            this.Bullet.GetComponent<Image>().enabled = false;
        }
    }

    /* Obtaining the director vector of the two points */
    Vector3 subtract (Vector3 v1, Vector3 v2){
        return new Vector3(v2.x - v1.x, v2.y - v1.y, v2.z-v1.z);
    }

    /* Moving the bullet to where the button is moving */
    Vector3 addMove(Vector3 position, Vector3 direction){
        return new Vector3(position.x + (direction.x * this.speed), position.y + (direction.y * this.speed), position.z);
    }

    /* Verifying if the bullet is already touching the button that the user clicked */
    bool doesItOverlaps(RectTransform rectTrans1, RectTransform rectTrans2){
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);
        return rect1.Overlaps(rect2);
    }
}
