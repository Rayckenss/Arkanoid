using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ball : MonoBehaviour
{
    public player player;
    public Transform ball;
    public float posX, posY, speed;
    bool gameOver;
    void Start()
    {
        posY = 1;
        posX = Random.Range(-1, 2);
        gameOver = false;
    }
    void Update()
    {
        if (GameManager.Instance.paused) { return; }
        if (GameManager.Instance.win) { return; }
        if (gameOver) { return; }
        BallBehaviour();
        speed = GameManager.Instance.ballSpeed;
    }
    void BallBehaviour()
    {
        Vector2 direccion = new Vector2(posX, posY);
        this.transform.Translate(direccion * speed * Time.deltaTime);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Side")
        {
            posX = -posX;
        }
        if (collision.transform.tag == "Up")
        {
            posY = -posY;
        }
        if (collision.transform.tag == "Player")
        {
            posY = -posY;
            if (posX == 0)
            {
                if (player.dirX < 0)
                {
                    posX = 1;
                }
                if (player.dirX > 0)
                {
                    posX = -1;
                }
            }
        }
        if (collision.transform.tag == "Bot")
        {
            gameOver = true;
            GameManager.Instance.endGame.SetActive(true);
        }
        if (collision.transform.tag == "Box")
        {
            List<ContactPoint2D> point = new List<ContactPoint2D>();
            collision.GetContacts(point);
            point.OrderBy(ContactPoint2D => ContactPoint2D.point.x);
            foreach (ContactPoint2D contact in point)
            {
                Debug.Log(contact.point.x);
            }
            posX = collision.transform.position.x > this.transform.position.x  ? -posX : posX;
            posY = collision.transform.position.y > this.transform.position.y  ? -posY : posY;
            posX = collision.transform.position.x > this.transform.position.x  ? posX : -posX;
            posY = collision.transform.position.y > this.transform.position.y  ? posY : -posY;
            GameManager.Instance.boxes.Remove(collision.gameObject);
            collision.GetComponent<Box>().Life(1);
        }

    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side")
        {
            posX = -posX;
        }
        if (collision.transform.tag == "Up")
        {
            posY = -posY;
        }
        if (collision.transform.tag == "Player")
        {
            posY = -posY;
            if (posX == 0)
            {
                if (player.dirX < 0)
                {
                    posX = 1;
                }
                if (player.dirX > 0)
                {
                    posX = -1;
                }
            }
        }
        if (collision.transform.tag == "Bot")
        {
            gameOver = true;
            GameManager.Instance.endGame.SetActive(true);
        }
        if (collision.transform.tag == "Box")
        {
            ContactPoint2D[] point =  collision.contacts;
            point.OrderBy(ContactPoint2D => ContactPoint2D.point.x);
            foreach (ContactPoint2D contact in point)
            {
                Debug.Log(contact.point.x);
            }
            posX = collision.transform.position.x > this.transform.position.x ? -posX : posX;
            posY = collision.transform.position.y > this.transform.position.y ? -posY : posY;
            posX = collision.transform.position.x > this.transform.position.x ? posX : -posX;
            posY = collision.transform.position.y > this.transform.position.y ? posY : -posY;
            GameManager.Instance.boxes.Remove(collision.gameObject);
            collision.transform.GetComponent<Box>().Life(1);
        }
    }
}
