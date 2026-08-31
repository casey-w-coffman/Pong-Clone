using UnityEngine;

public class Borders : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isRightBorder;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isRightBorder)
            {
                GameManager.Instance.AddPointLeft();
            }
            else
            {
                GameManager.Instance.AddPointRight();
            }
        }
        else
        {

        }
    }
}
