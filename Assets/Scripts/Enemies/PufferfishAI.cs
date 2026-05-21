using UnityEngine;

public class PufferfishAI : MonoBehaviour
{
    [SerializeField] private int damageAmount = 50;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float changeDirectionTime = 4f;

    private Vector3 moveDirection;
    private float directionChangeTimer = 0f;
    private Rigidbody rb;

    private void Start()
    {
        gameObject.tag = "Pufferfish";
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
    }

    private void Update()
    {
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    private void ChangeDirection()
    {
        moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.3f, 0.3f),
            Random.Range(-1f, 1f)
        ).normalized;
        directionChangeTimer = changeDirectionTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SharkController shark = other.GetComponent<SharkController>();
            if (shark != null)
            {
                shark.Heal(-damageAmount);
                AudioManager.Instance.PlayExplosionSound();
                Destroy(gameObject);
            }
        }
    }
}
