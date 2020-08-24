using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousecursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite wandCursor;
    public Sprite shootCursor;
    public Sprite normalCursor;

    public GameObject clickEffect;
    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Set Cursor
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        // Set Shoot Cursor
        if (Input.GetMouseButtonDown(0))
        {
            rend.sprite = shootCursor;
            Instantiate(clickEffect, transform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rend.sprite = normalCursor;
        }

    }
}
