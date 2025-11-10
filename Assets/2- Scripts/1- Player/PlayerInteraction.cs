using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInteraction : MonoBehaviour
{
    [Header("UI de Interação")]
    public GameObject interactionPanel;
    public TextMeshProUGUI interactionText;

    private Interactable currentInteractable;

    void Start()
    {
        // Configura o Rigidbody do player
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Garante que o painel comece invisível
        if (interactionPanel != null)
            interactionPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();

        if (interactable != null)
        {
            currentInteractable = interactable;

            // Mostra texto na tela
            if (interactionPanel != null && interactionText != null)
            {
                interactionPanel.SetActive(true);
                interactionText.text = interactable.description;
            }

            // Ativa contorno
            interactable.EnableOutline(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();

        if (interactable != null && interactable == currentInteractable)
        {
            // Esconde painel e desativa contorno
            if (interactionPanel != null)
                interactionPanel.SetActive(false);

            interactable.EnableOutline(false);
            currentInteractable = null;
        }
    }
}
