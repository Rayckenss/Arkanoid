using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public static player Instance;
    public Rigidbody2D rB;
    public float speed = 10;
    public float posicionX;
    public Control control;
    public float dirX;
    public float posX;
    public float bPosX;
    public Vector3 mousePosition;
    public bool paused;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        paused = false;
    }
    private void Update()
    {
        if (paused) { return; }
        Direction();
        PlayerController();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void PlayerController()
    {
        switch (control)
        {
            case Control.Mouse:
                if (mousePosition.x < 5.5f && mousePosition.x > -5.5f)
                {
                    this.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                }
                break;
            case Control.Keyboard:
                posicionX += Input.GetAxisRaw("Horizontal") * speed;
                posicionX = Mathf.Clamp(posicionX, -5.5f, 5.5f);
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


    public enum Control
    {
        Mouse,
        Keyboard
    }
}
