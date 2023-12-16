using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float meleeRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damageAmount;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()
         && Time.timeScale > 0)
        {
            MeleeAttack();
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }

    private void MeleeAttack()
    {
        AudioPlayer.instance.PlaySFX(0);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
                Vector2 direction = (enemy.transform.position - transform.position).normalized;

                if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        anim.SetTrigger("meleeAttack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}