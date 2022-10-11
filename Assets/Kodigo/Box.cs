using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int life=1;
    private void Start()
    {
        BoxColor();
    }
    private void Update()
    {
        BoxColor();
    }
    public void Life(int damage)
    {
        BoxColor();

        life = life - damage;
        if (life==0)
        {

            Destroy(gameObject);
        }

    }
    void BoxColor()
    {
        switch (life)
        {
            case 3:
                this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 255);
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().color = new Color(130, 0, 0, 255);
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                break;
            default:
                break;
        }
    }

   

}
