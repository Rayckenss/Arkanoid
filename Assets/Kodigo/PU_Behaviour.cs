using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Behaviour : MonoBehaviour
{
    public float speed;
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            int variable;
            variable = Random.Range(0, 3);
            switch (variable)
            {
                case 0:
                    collision.transform.GetComponentInChildren<Transform>().localScale = new Vector3(3, 1, 1);
                    if (collision.transform.GetComponentInChildren<Transform>().localScale.x > 3)
                    {
                        collision.transform.GetComponentInChildren<Transform>().localScale = new Vector3(3, 1, 1);
                    }
                    Destroy(this.gameObject);
                    break;
                case 1:
                    GameManager.Instance.ballSpeed = GameManager.Instance.ballSpeed + 2;
                    if (GameManager.Instance.ballSpeed > 10)
                    {
                        GameManager.Instance.ballSpeed = 10;
                    }
                    Destroy(this.gameObject);
                    break;
                case 2:
                    GameManager.Instance.ballSpeed = GameManager.Instance.ballSpeed - 2;
                    if (GameManager.Instance.ballSpeed < 2)
                    {
                        GameManager.Instance.ballSpeed = 2;
                    }
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
        if (collision.transform.tag=="Bot")
        {
            Destroy(this.gameObject);
        }

    }
}
