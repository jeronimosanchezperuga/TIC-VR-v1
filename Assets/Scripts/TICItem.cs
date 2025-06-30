using UnityEngine;

public class TICItem : MonoBehaviour
{
    public string itemName = "Objeto TIC";

    private void OnEnable()
    {
        // Suscribirse al evento de agarre si us�s grab interactors
        var grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args)
    {
        TICGameManager.Instance.ItemFound(itemName);
        // Opcional: destruir o desactivar despu�s de agarrarlo
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        var grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
