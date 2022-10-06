using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform ball;
    public float posX, posY, speed;
    void Start()
    {
        posY = 1;
        posX = Random.Range(-1, 2);
    }
    void Update()
    {
        BallBehaviour();
    }
    void BallBehaviour()
    {
        Vector2 direccion = new Vector2(posX, posY);
        this.transform.Translate(direccion * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Side")
        {
            posX = -posX;
        }
        if (collision.transform.tag == "Up")
        {
            Debug.Log("impact");
            posY = -posY;
        }
        if (collision.transform.tag == "Player")
        {
            posY = -posY;
            if (posX==0)
            {
                if (player.Instance.dirX < 0)
                {
                    posX = 1;
                }
                if (player.Instance.dirX > 0)
                {
                    posX = -1;
                }
            }
        }
    }
}
