using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] protected int scoreValue = 10;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float changeDirectionTime = 3f;

    protected Vector3 moveDirection;
    protected float directionChangeTimer = 0f;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        gameObject.tag = "Food";
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        ChangeDirection();
    }

    protected virtual void Update()
    {
        directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            ChangeDirection();
        }
    }

    protected virtual void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    protected void ChangeDirection()
    {
        moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.5f, 0.5f),
            Random.Range(-1f, 1f)
        ).normalized;
        directionChangeTimer = changeDirectionTime;
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
