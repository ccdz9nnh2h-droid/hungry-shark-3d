using UnityEngine;

public class SharkController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float sprintSpeed = 20f;
    [SerializeField] private float rotationSpeed = 8f;
    [SerializeField] private float dragForce = 2f;

    [Header("Health")]
    [SerializeField] private int maxHP = 200;
    private int currentHP;

    [Header("Eating")]
    [SerializeField] private float eatRadius = 2f;
    [SerializeField] private Transform mouthPosition;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;
    private bool isSprinting = false;
    private SharkAnimator sharkAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sharkAnimator = GetComponent<SharkAnimator>();
        currentHP = maxHP;
        
        if (mouthPosition == null)
            mouthPosition = transform;

        GameManager.Instance.UpdateHP(currentHP);
    }

    private void Update()
    {
        HandleInput();
        HandleRotation();
        CheckForEating();
    }

    private void FixedUpdate()
    {
        MoveShark();
        ApplyWaterDrag();
    }

    private void HandleInput()
    {
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveZ = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveZ = -1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveX = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveX = 1;

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (sharkAnimator != null)
            sharkAnimator.SetSwimmingSpeed(moveDirection.magnitude);
    }

    private void MoveShark()
    {
        if (moveDirection.magnitude > 0)
        {
            float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
            Vector3 targetVelocity = moveDirection * currentSpeed;
            targetVelocity.y = rb.velocity.y;
            rb.velocity = targetVelocity;
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void HandleRotation()
    {
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void ApplyWaterDrag()
    {
        rb.velocity *= (1 - dragForce * Time.fixedDeltaTime);
    }

    private void CheckForEating()
    {
        Collider[] colliders = Physics.OverlapSphere(mouthPosition.position, eatRadius);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Food"))
            {
                EatFood(col.gameObject);
            }
            else if (col.CompareTag("Danger"))
            {
                TakeDamage(col.gameObject);
            }
        }
    }

    private void EatFood(GameObject food)
    {
        int score = 0;
        Food foodComponent = food.GetComponent<Food>();
        if (foodComponent != null)
            score = foodComponent.GetScore();
        else
            score = 10;

        GameManager.Instance.AddScore(score);
        AudioManager.Instance.PlayEatSound();
        
        if (sharkAnimator != null)
            sharkAnimator.PlayEatAnimation();

        Destroy(food);
    }

    private void TakeDamage(GameObject danger)
    {
        currentHP -= 50;
        AudioManager.Instance.PlayExplosionSound();
        
        if (sharkAnimator != null)
            sharkAnimator.PlayHitAnimation();

        GameManager.Instance.UpdateHP(currentHP);
        Destroy(danger);

        if (currentHP <= 0)
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        GameManager.Instance.UpdateHP(currentHP);
    }
}
