using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #pragma warning disable CS0618 // Desativa o aviso de "deprecated"

    [SerializeField] private float speed;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 movement;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical);

        // Só normaliza se houver movimento
        if (movement.magnitude > 1f)
            movement.Normalize();
    }

    void FixedUpdate()
    {
        // Usa velocity (funciona com o sistema antigo)
        rb.velocity = movement * speed;

        // Define qual camada está ativa
        if (movement.x != 0)
        {
            ResetLayers();
            animator.SetLayerWeight(2, 1); // Side Layer
            sprite.flipX = movement.x < 0; // Mais limpo
        }
        else if (movement.y > 0)
        {
            ResetLayers();
            animator.SetLayerWeight(1, 1); // Up Layer
        }
        else if (movement.y < 0)
        {
            ResetLayers();
            animator.SetLayerWeight(0, 1); // Down Layer
        }
        else
        {
            // Se estiver parado, mantém a última camada ativa (ou define uma padrão)
            // Opcional: ative o Idle aqui
            animator.SetLayerWeight(0, 1); // Ex: Idle ou Down Layer como padrão
        }

        // Atualiza o Bool "walking"
        if (movement != Vector2.zero)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    private void ResetLayers()
    {
        animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
    }
}