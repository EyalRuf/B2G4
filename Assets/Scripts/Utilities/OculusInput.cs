using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusInput : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.None;

    [Header("Settings"), SerializeField]
    public bool normalizeJoystick;
    public float joystickDamp;
    [Range(0, 1)] public float gripPressedTreshold;
    [Range(0, 1)] public float triggerPressedTreshold;

    [Header("Button 0")]
    public bool button0Down;
    public bool button0Pressed;
    public bool button0Up;

    [Header("Button 1")]
    public bool button1Down;
    public bool button1Pressed;
    public bool button1Up;

    [Header("Grip"), Range(0, 1)]
    public float gripPos;
    public bool gripDown;
    public bool gripPressed;
    public bool gripUp;

    [Header("Trigger"), Range(0, 1)]
    public float triggerPos;
    public bool triggerDown;
    public bool triggerPressed;
    public bool triggerUp;
    
    [Header("Joystick")]
    public Vector2 joystick;
    public Vector2 joystickRaw;

    [Header("Misc properties")]
    public Vector3 worldVelocity;
    public Vector3 worldAngularVelocity;
    public bool isInFocus;

    private Vector2 joystickDampVelocity;

    private void Update()
    {
        //button 0
        bool button0PressedState = OVRInput.Get(OVRInput.Button.One, controller);
        button0Down = !button0Pressed && (button0PressedState != button0Pressed);
        button0Up = button0Pressed && (button0PressedState != button0Pressed);
        button0Pressed = button0PressedState;


        //button 1
        bool button1PressedState = OVRInput.Get(OVRInput.Button.Two, controller);
        button1Down = !button1Pressed && (button1PressedState != button1Pressed);
        button1Up = button1Pressed && (button1PressedState != button1Pressed);
        button1Pressed = button1PressedState;

        //grip
        gripPos = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        bool gripPressedState = gripPos >= gripPressedTreshold;
        gripDown = !gripPressed && (gripPressedState != gripPressed);
        gripUp = gripPressed && (gripPressedState != gripPressed);
        gripPressed = gripPressedState;

        //trigger
        triggerPos = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        bool triggerPressedState = triggerPos >= triggerPressedTreshold;
        triggerDown = !triggerPressed && (triggerPressedState != triggerPressed);
        triggerUp = triggerPressed && (triggerPressedState != triggerPressed);
        triggerPressed = triggerPressedState;

        //joystick
        joystickRaw = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);

        joystick = Vector2.SmoothDamp(joystick, joystickRaw, ref joystickDampVelocity, joystickDamp);
        joystick = normalizeJoystick && joystick.magnitude > 1 ? joystick.normalized : joystick;

        //world position and rotation
        worldVelocity = OVRInput.GetLocalControllerVelocity(controller);
        worldAngularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);

        //do callbacks
        OVRManager.InputFocusAcquired += OnInputFocusAcquired;
        OVRManager.InputFocusLost += OnInputFocusLost;
    }

    private void OnInputFocusLost()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            isInFocus = false;
        }
    }

    private void OnInputFocusAcquired()
    {
        gameObject.SetActive(true);
        isInFocus = true;
    }
}
