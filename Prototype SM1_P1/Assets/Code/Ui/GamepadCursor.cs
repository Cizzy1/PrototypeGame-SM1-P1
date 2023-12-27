using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class GamepadCursor : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private RectTransform cursor;
    [SerializeField]
    private RectTransform canvasRect;
    [SerializeField]
    private Canvas canvas;
    private Camera cam;

    public float CurSpeed = 1000f;

    private bool previousMouseState;

    private Mouse virtualMouse;

    private void OnEnable(){
        if(virtualMouse == null){
            virtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
        }
        else if(!virtualMouse.added){
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if (cursor != null){
            Vector2 position = cursor.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
    }

    private void OnDisable(){
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    private void UpdateMotion(){
        if(virtualMouse == null || Gamepad.current == null){
            return;
        }

        Vector2 stickValue = Gamepad.current.leftStick.ReadValue();
        stickValue *= CurSpeed * Time.deltaTime;

        Vector2 currentposition = virtualMouse.position.ReadValue();
        Vector2 newPos = currentposition + stickValue;

        newPos.x = Mathf.Clamp(newPos.x, 0, Screen.width);
        newPos.y = Mathf.Clamp(newPos.y, 0, Screen.height);

        InputState.Change(virtualMouse.position, newPos);
        InputState.Change(virtualMouse.delta ,stickValue);


        bool aButtonIsPressed = Gamepad.current.aButton.IsPressed();

        if(previousMouseState != Gamepad.current.aButton.isPressed){
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }

        AnchorCur(newPos);
    } 

    private void AnchorCur(Vector2 position){
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, position, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : cam, out anchoredPos);

        cursor.anchoredPosition = anchoredPos;
    }
}
