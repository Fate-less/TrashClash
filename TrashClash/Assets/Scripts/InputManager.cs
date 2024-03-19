using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static PlayerInput PlayerInput { get; set;}
    public Vector2 navigationInput { get; set; }
    private InputAction navigationAction;

    private void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        navigationAction = PlayerInput.actions["Navigate"];
    }
    private void Update()
    {
        navigationInput = navigationAction.ReadValue<Vector2>();
    }
}
