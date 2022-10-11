using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rB;
    public float speed = 10;
    public float posicionX;
    public Control control;
    public float dirX;
    public float posX;
    public float bPosX;
    public Vector3 mousePosition;
    public float maxX, minX;



    private void Start()
    {
        GameManager.Instance.paused = false;
    }
    private void Update()
    {
        if (GameManager.Instance.paused) { return; }
        Direction();
        PlayerController();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        maxX = (16 - transform.GetChild(0).lossyScale.x) / 2; 
        minX = maxX * -1;
    }
    void PlayerController()
    {
        switch (control)
        {
            case Control.Mouse:
                if (mousePosition.x < maxX && mousePosition.x > minX)
                {
                    this.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                }
                if (this.transform.position.x>maxX)
                {
                    transform.position = new Vector2(maxX, transform.position.y);
                }
                if (this.transform.position.x<minX)
                {
                    transform.position = new Vector2(minX, transform.position.y);
                }
                break;
            case Control.Keyboard:
                posicionX += Input.GetAxisRaw("Horizontal") * speed;
                posicionX = Mathf.Clamp(posicionX, minX, maxX);
                this.transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);
                break;
            default:
                break;
        }


    }
    void Direction()
    {
        bPosX = posX;
        posX = transform.position.x;
        dirX = bPosX - posX;
    }
    public void Mode(int mode)
    {
        switch (mode)
        {
            case 1:
                control = Control.Mouse;
                break;
            case 2:
                control = Control.Keyboard;
                break;
            default:
                break;
        }
    }


    public enum Control
    {
        Mouse,
        Keyboard
    }
}
