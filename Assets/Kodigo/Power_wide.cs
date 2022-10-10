using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_wide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
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
                break;
            case 1:
                GameManager.Instance.ballSpeed = GameManager.Instance.ballSpeed + 2;
                if (GameManager.Instance.ballSpeed > 10)
                {
                    GameManager.Instance.ballSpeed = 10;
                }
                break;
            case 2:
                GameManager.Instance.ballSpeed = GameManager.Instance.ballSpeed - 2;
                if (GameManager.Instance.ballSpeed < 2)
                {
                    GameManager.Instance.ballSpeed = 2;
                }
                break;
            default:
                break;
        }

    }
}
