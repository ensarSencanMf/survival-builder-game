using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;
    public float handleRange = 50f;
    
    private Vector2 inputVector;
    
    public Vector2 InputDirection { get { return inputVector; } }
    
    void Start()
    {
        if (joystickBackground == null)
            joystickBackground = GetComponent<RectTransform>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground, 
            eventData.position, 
            eventData.pressEventCamera, 
            out position))
        {
            position.x = (position.x / joystickBackground.sizeDelta.x);
            position.y = (position.y / joystickBackground.sizeDelta.y);
            
            inputVector = new Vector2(position.x * 2, position.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            
            joystickHandle.anchoredPosition = new Vector2(
                inputVector.x * handleRange,
                inputVector.y * handleRange);
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}