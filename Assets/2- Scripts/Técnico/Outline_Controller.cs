using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Outline_Controller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material materialInstance;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        materialInstance = Instantiate(spriteRenderer.material);
        spriteRenderer.material = materialInstance;
    }

    public void SetOutlineThickness(float thickness)
    {
        if (materialInstance.HasProperty("_Thickness"))
            materialInstance.SetFloat("_Thickness", thickness);
    }

    public void SetOutlineColor(Color color)
    {
        if (materialInstance.HasProperty("_OutlineColor"))
            materialInstance.SetColor("_OutlineColor", color);
    }
}
