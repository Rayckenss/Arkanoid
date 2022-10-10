using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herramienta : MonoBehaviour
{
    public int alto, ancho;
    public GameObject prefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    GameObject go = Instantiate(prefab,new Vector3(i,j,0),Quaternion.identity);
                }
            }
        }
    }
}
