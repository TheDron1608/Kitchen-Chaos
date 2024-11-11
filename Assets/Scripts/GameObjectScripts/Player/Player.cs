using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class  PlayerReSelectEventArgs
{
    public Furniture oldSelected;
    public Furniture newSelected;

    public PlayerReSelectEventArgs (Furniture oldSelected, Furniture newSelected)
    {
        this.oldSelected = oldSelected;
        this.newSelected = newSelected;
    }
}

public class Player : ItemHolder
{   
    public static Player Instance;

    [SerializeField] protected float _speed;

    public event EventHandler<IInteractable> OnInteract;
    public event EventHandler<IInteractable> OnInteractAlt;
    public event EventHandler <PlayerReSelectEventArgs> OnReSelect;

    protected PlayerInput _playerInput;
    protected bool _isWalking;
    protected bool _canWalk;
    protected Rigidbody _rigidBodyComponent;
    protected Furniture _lastSelectedObject = null;
    protected Furniture _currentSelectedObject = null;

    public bool IsWalking() 
    { 
        return _isWalking; 
    }


    protected void Awake()
    {
        _rigidBodyComponent = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();

        _playerInput.Player.Interact.performed += Player_OnInteract;
        _playerInput.Player.InteractAlt.performed += Player_OnInteractAlt;
        OnReSelect += Player_OnReSelect;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new Exception("Maximum 1 Player prefab");
        }
    }

    private void Player_OnReSelect(object sender, PlayerReSelectEventArgs e)
    {
        _lastSelectedObject = e.oldSelected;
        _currentSelectedObject = e.newSelected;
    }
    private void Player_OnInteract(InputAction.CallbackContext obj)
    {
        if (!GetCanInteract()) return;
        OnInteract?.Invoke(this, _currentSelectedObject as IInteractable);
    }
    private void Player_OnInteractAlt(InputAction.CallbackContext obj)
    {
        if (!GetCanInteract()) return;
        OnInteractAlt?.Invoke(this, _currentSelectedObject as IInteractable);
    }

    public bool GetCanInteract()
    {
        return GlobalGameState.CurrentGameState == GlobalGameState.GameStateEnum.Gameplay;
    }
    public bool GetCanMove()
    {
        return GlobalGameState.CurrentGameState != GlobalGameState.GameStateEnum.GameOver;
    }

    protected void Update()
    {   
        UpdateMovement();
        UpdateSelected();
    }

    protected void UpdateMovement()
    {
        if (!GetCanMove()) {
            _rigidBodyComponent.velocity = Vector3.zero;
            _isWalking = false;
            return;
        }

        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y) * _speed;

        _rigidBodyComponent.velocity = moveDir;

        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _speed);
        }

        _isWalking = moveDir != Vector3.zero;
    }

    protected void UpdateSelected()
    {
        if (!GetCanInteract())
        {
            OnReSelect?.Invoke(this, new PlayerReSelectEventArgs(_currentSelectedObject, null));
            return;
        }

        Furniture newSelectedObject;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out RaycastHit hit, 5f))
        {
            hit.transform.TryGetComponent<Furniture>(out newSelectedObject);
        }
        else
        {
            newSelectedObject = null;
        }

        if (_currentSelectedObject != newSelectedObject)
        {
            OnReSelect?.Invoke(this, new PlayerReSelectEventArgs(_currentSelectedObject, newSelectedObject));
        }
    }
}
