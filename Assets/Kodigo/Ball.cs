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
    public AudioSource sonido;


    void Start()
    {
        posY = 1;
        sonido.volume = Options.globalVolumen;
        posX = Random.Range(-1, 2);
        if (posX == 0)
        {
            posX = 1;
        }
        gameOver = false;
    }
    void Update()
    {
        if (GameManager.Instance.paused) { return; }
        if (GameManager.Instance.win) { return; }
        if (gameOver) { return; }
        BallBehaviour();
        speed = GameManager.Instance.ballSpeed;
        sonido.volume = Options.globalVolumen;
    }
    void BallBehaviour()
    {
        Vector2 direccion = new Vector2(posX, posY);
        this.transform.Translate(direccion * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Side")
        {
            posX = -posX;
            sonido.Play();
        }
        if (collision.transform.tag == "Up")
        {
            posY = -posY;
            sonido.Play();
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
            sonido.Play();
        }
        if (collision.transform.tag == "Bot")
        {
            gameOver = true;
            GameManager.Instance.endGame.SetActive(true);
        }
        if (collision.transform.tag == "Box")
        {
            if (collision.contacts.Length > 0)
            {
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (transform.position.x > collision.contacts[i].point.x && posX < 0 || transform.position.x < collision.contacts[i].point.x && posX > 0)
                    {
                        posX = -posX;
                        sonido.Play();
                    }
                    if (transform.position.y > collision.contacts[i].point.y && posY < 0 || transform.position.y < collision.contacts[i].point.y && posY > 0)
                    {
                        posY = -posY;
                        sonido.Play();
                    }
                }
            }
            if (Random.Range(0, 101) <= GameManager.Instance.probabilidad)
            {
                GameObject poweUp = Instantiate(GameManager.Instance.powerUpPrefab, collision.transform.position, Quaternion.identity);
            }
            GameManager.Instance.PuntajeEnPantalla(10);
            collision.transform.GetComponent<Box>().Life(1);
            if (collision.transform.GetComponent<Box>().life == 0)
            {
                GameManager.Instance.boxes.Remove(collision.gameObject);
            }
        }
        if (collision.transform.tag == "Obs")
        {
            if (collision.contacts.Length > 0)
            {
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (transform.position.x > collision.contacts[i].point.x && posX < 0 || transform.position.x < collision.contacts[i].point.x && posX > 0)
                    {
                        posX = -posX;
                        sonido.Play();
                    }
                    if (transform.position.y > collision.contacts[i].point.y && posY < 0 || transform.position.y < collision.contacts[i].point.y && posY > 0)
                    {
                        posY = -posY;
                        sonido.Play();
                    }
                }
            }
        }
    }
}
