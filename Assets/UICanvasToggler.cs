using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UICanvasToggler : MonoBehaviour
{
    public GameObject canvasObject;
    public TextMeshProUGUI messageText;
    public string initialMessage = "¡Bienvenido! Encontrá los 3 objetos TIC escondidos en las aulas.";
    private string lastMessage;

    private bool isVisible = true;

    public InputActionProperty leftTriggerAction;
    public InputActionProperty rightTriggerAction;

    private void Start()
    {
        ShowMessage(initialMessage);
    }

    private void Update()
    {
        // Detectar si alguno de los triggers fue presionado
        bool leftTrigger = leftTriggerAction.action.WasPressedThisFrame();
        bool rightTrigger = rightTriggerAction.action.WasPressedThisFrame();

        if (leftTrigger || rightTrigger)
        {
            ToggleCanvas();
        }
    }

    public void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            lastMessage = message;
        }

        if (canvasObject != null)
        {
            canvasObject.SetActive(true);
            isVisible = true;
        }
    }

    public void ToggleCanvas()
    {
        if (canvasObject == null) return;

        isVisible = !isVisible;
        canvasObject.SetActive(isVisible);

        if (isVisible && messageText != null)
        {
            messageText.text = lastMessage;
        }
    }
}
