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
    [SerializeField] private float _speed;
    [Header("references")]
    private PlayerInput _playerInput;
    private bool _isWalking;
    private bool _canWalk;
    private Rigidbody _rigidBodyComponent;
    private Table _lastSelectedObject = null;

    public event EventHandler OnInteract;

    public bool IsWalking() 
    { 
        return _isWalking; 
    }

    private void Awake()
    {
        _rigidBodyComponent = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();

        _playerInput.Player.Interact.performed += 
            (InputAction.CallbackContext obj) => { 
                OnInteract?.Invoke(this, EventArgs.Empty); 
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

    private void Start()
    {
        OnInteract += Interact;
    }

    private void Update()
    {   
        UpdateMovement();
        UpdateSelected();
    }

    private void UpdateMovement()
    {   
        Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y) * Time.deltaTime * _speed;

        _rigidBodyComponent.velocity = moveDir * 100;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _speed);

        _isWalking = moveDir != Vector3.zero;
    }

    private void UpdateSelected()
    {
        if (
            Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out RaycastHit hit, 5f)
            && hit.transform.TryGetComponent<Table>(out Table hitObject)
            )
        {   
            _lastSelectedObject?.Deselect();
            _lastSelectedObject = hitObject;
            hitObject.Select();
        }
        else
        {
            _lastSelectedObject?.Deselect();
        }
    }

    private void Interact(object sender, System.EventArgs e)
    {
        if (_lastSelectedObject != null && _lastSelectedObject.IsSelected)
        {
            if (_currentHoldableItem != null)
            {

            }
        }
    }
}
