using UnityEngine;

public class CrabAI : Food
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue);
            AudioManager.Instance.PlayEatSound();
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Crab";
        scoreValue = 50;
        speed = 2f;
    }
}
