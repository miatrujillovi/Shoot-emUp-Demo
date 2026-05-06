using UnityEngine;

public class Look : MonoBehaviour
{
    [Header("Configuración de Sensibilidad")]
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    [Header("Límites de Ángulo Vertical (Arriba/Abajo)")]
    public float minXLookAngle = -80f; 
    public float maxXLookAngle = 80f;  

    [Header("Límites de Ángulo Horizontal (Izquierda/Derecha)")]
    public float minYLookAngle = -90f; 
    public float maxYLookAngle = 90f;  

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleFPSLook();
    }

    private void HandleFPSLook()
    {
        Vector2 lookInput = InputManager.Instance.GetLook();

        float mouseX = lookInput.x * sensitivityX * Time.deltaTime;
        float mouseY = lookInput.y * sensitivityY * Time.deltaTime;

        verticalRotation -= mouseY; 
        horizontalRotation += mouseX; 

        verticalRotation = Mathf.Clamp(verticalRotation, minXLookAngle, maxXLookAngle);
        horizontalRotation = Mathf.Clamp(horizontalRotation, minYLookAngle, maxYLookAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
}