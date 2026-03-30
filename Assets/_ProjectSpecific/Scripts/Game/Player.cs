using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Ship
{
    //[Header("Player Settings")]

    [Header("Player Settings")]
    [SerializeField] private Transform m_PlayerTransform;
    [SerializeField] private Rigidbody m_PlayerRigidbody;

    private bool isGameStarted = false;

    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnGameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnGameOver -= OnGameOver;
    }

    private void OnGameStart()
    {
        isGameStarted = true;        
    }

    private void OnGameOver()
    {
        isGameStarted = false;
    }

    private void Update()
    {
        DetectInput();
    }

    private void DetectInput()
    {
        if(!isGameStarted)
            return;

        if (GetPlayerStatus())
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                MoveLeft();
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                MoveRight();
            }
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Fire();
            }
        }
    }

    protected override void Fire()
    {
        base.Fire();
    }

    private void MoveLeft()
    {
        ClampPosition();
        m_PlayerRigidbody.MovePosition(m_PlayerTransform.position + Vector3.left * Time.deltaTime * GetSpeed());
    }

    private void MoveRight()
    {
        ClampPosition();
        m_PlayerRigidbody.MovePosition(m_PlayerTransform.position + Vector3.right * Time.deltaTime * GetSpeed());
    }

    private void ClampPosition()
    {
        Vector3 clampPos = m_PlayerTransform.position;
        clampPos.x = Mathf.Clamp(clampPos.x, -18f, 18f);
        m_PlayerTransform.position = clampPos;
    }
}
