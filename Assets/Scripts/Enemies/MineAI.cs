using UnityEngine;

public class MineAI : MonoBehaviour
{
    [SerializeField] private int damageAmount = 50;
    [SerializeField] private float explosionRadius = 5f;
    private bool hasExploded = false;

    private void Start()
    {
        gameObject.tag = "Mine";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasExploded && other.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        hasExploded = true;
        AudioManager.Instance.PlayExplosionSound();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                SharkController shark = col.GetComponent<SharkController>();
                if (shark != null)
                {
                    shark.Heal(-damageAmount);
                }
            }
        }

        ParticleSystem explosion = GetComponent<ParticleSystem>();
        if (explosion != null)
        {
            explosion.Play();
        }

        Destroy(gameObject, 0.5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
