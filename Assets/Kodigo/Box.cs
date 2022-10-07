using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int life=1;

    public void Life(int damage)
    {
        life = life - damage;
        if (life==0)
        {

            Destroy(gameObject);
        }
    }

   

}
