using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    public float ButtonOffset = 64f;


    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("DOWN");
        //Debug.Log("A = " + transform.Find("Button").position);
        //Debug.Log("B = " + eventData.position);

        transform.Find("Button").position = eventData.position + new Vector2(ButtonOffset, -ButtonOffset);

        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("UP");

        Pressed = false;
    }
}
