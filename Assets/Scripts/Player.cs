using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : ItemHolder
{   
    public static Player Instance;

    [Header("properties")]
    [SerializeField] protected float _speed;

    public event EventHandler<IInteractable> OnInteract;

    protected PlayerInput _playerInput;
    protected bool _isWalking;
    protected bool _canWalk;
    protected Rigidbody _rigidBodyComponent;
    protected ISelectable _lastSelectedObject = null;
    protected ISelectable _currentSelectedObject = null;

    public bool IsWalking() 
    { 
        return _isWalking; 
    }

    protected void Awake()
    {
        _rigidBodyComponent = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();

        _playerInput.Player.Interact.performed +=
            (InputAction.CallbackContext obj) =>
            {
                OnInteract?.Invoke(this, _currentSelectedObject as IInteractable);
            };

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new Exception("Maximum 1 Player prefab");
        }
    }

    protected void Update()
    {   
        UpdateMovement();
        UpdateSelected();
    }

    protected void UpdateMovement()
    {   
        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y) * Time.deltaTime * _speed;

        _rigidBodyComponent.velocity = moveDir * 100;

        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _speed);
        }

        _isWalking = moveDir != Vector3.zero;
    }

    protected void UpdateSelected()
    {
        if (
            Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out RaycastHit hit, 5f)
            && hit.transform.TryGetComponent<ISelectable>(out ISelectable hitObject)
            )
        {   
            _lastSelectedObject?.Deselect();
            _lastSelectedObject = hitObject;
            _currentSelectedObject = hitObject;
            hitObject.Select();
        }
        else
        {
            _lastSelectedObject?.Deselect();
            _currentSelectedObject = null;
        }
    }
}
