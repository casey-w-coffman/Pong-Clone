using UnityEngine;

public class Borders : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //create checkbox in inspector for is right border?
    public bool isRightBorder;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if ball has collided with border
        if (collision.gameObject.CompareTag("Ball"))
        {
            //adds point for left if collided with right border  
            if (isRightBorder)
            {
                GameManager.Instance.AddPointLeft();
            }
            //adds point for right if not collided with right border
            else
            {
                GameManager.Instance.AddPointRight();
            }
        }
        else
        {
        //return nothing
        }
    }
}
