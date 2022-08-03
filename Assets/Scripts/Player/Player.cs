using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 10;

    [Header("key setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D Myrigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private Vector3 _startPositionPlayer;

    private void Awake()
    {
        _startPositionPlayer = transform.position;
        Begin();

    }

    public void Begin()
    {
        currentPoints = 0;
        UpdateUI();
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
        transform.position = _startPositionPlayer;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(keyCodeMoveUp))
           Myrigidbody2D.MovePosition(transform.position + transform.up * speed);
           //transform.Translate(transform.up * speed);
        else if (Input.GetKey(keyCodeMoveDown))
           Myrigidbody2D.MovePosition(transform.position + transform.up * -speed);
           //transform.Translate(transform.up * speed * -1);       
    }

    public void addPoint()
    {
        currentPoints++;
        UpdateUI();

    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }
}
