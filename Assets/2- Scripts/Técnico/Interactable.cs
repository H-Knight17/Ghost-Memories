using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    [Header("Descrição exibida quando o player se aproxima")]
    [TextArea(2, 4)] 
    public string description;

    [Header("Materiais")]
    public Material outlineMaterial; // Material com contorno
    private Material originalMaterial;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;

        // Garante que o collider é trigger
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    public void EnableOutline(bool enable)
    {
        if (spriteRenderer == null) return;
        spriteRenderer.material = enable ? outlineMaterial : originalMaterial;
    }
}
