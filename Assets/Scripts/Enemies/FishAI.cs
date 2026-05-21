using UnityEngine;

public class FishAI : Food
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SharkController shark = other.GetComponent<SharkController>();
            if (shark != null)
            {
                GameManager.Instance.AddScore(scoreValue);
                AudioManager.Instance.PlayEatSound();
                Destroy(gameObject);
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Fish";
        scoreValue = 10;
    }
}
