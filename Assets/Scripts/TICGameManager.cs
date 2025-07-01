using UnityEngine;
using TMPro;
using static OVRPlugin;

public class TICGameManager : MonoBehaviour
{
    public static TICGameManager Instance;

    private int itemsFound = 0;
    public int totalItems = 3;
    public float textTime = 3f;

    public TextMeshProUGUI messageText; // Arrastrá un TextMeshPro en World Space aquí
    public TextMeshProUGUI controllerText; // Arrastrá un TextMeshPro en World Space aquí
    public GameObject finalPanel;       // Cartel de felicitaciones (puede ser un Canvas o 3D object)

    public GameObject uiMessageGO;

    public GameObject confetti;

    private void Awake()
    {
        Instance = this;
        if (finalPanel != null)
            finalPanel.SetActive(false);
        controllerText.text = "Encontraste\n" + itemsFound + " de " + totalItems + " carteles.";
        confetti.SetActive(false);
    }

    public void ItemFound(string itemName)
    {
        itemsFound++;
        ShowMessage("En TIC trabajamos con\n" + itemName);
        controllerText.text = "Encontraste\n" + itemsFound + " de " + totalItems + " carteles.";

        if (itemsFound >= totalItems)
        {
            ShowMessage("¡Completaste la búsqueda!");
            confetti.SetActive(true);
            if (finalPanel != null)
                finalPanel.SetActive(true);

            // Opcional: reproducir un sonido o animación
        }
    }

    private void ShowMessage(string msg)
    {
        if (messageText != null)
        {
            uiMessageGO.SetActive(true);
            messageText.text = msg;
            CancelInvoke(nameof(ClearMessage));
            //Invoke(nameof(ClearMessage), textTime);
        }
    }

    private void ClearMessage()
    {
        if (messageText != null)
            messageText.text = "";
        CloseUIMessage();
    }

    public void CloseUIMessage()
    {
        uiMessageGO.SetActive(false);
    }
}
