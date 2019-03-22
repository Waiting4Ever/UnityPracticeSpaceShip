using UnityEngine;

public class RedEnemyControll : MonoBehaviour
{
    static int SCORE_VALUE = 90;

    public GameObject explosion;

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, -0.3f, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("SpaceShip"))
        {
            Debug.Log("[RedEnemyControll::OnCollisionEnter2D] hit object");
            if (other.gameObject.CompareTag("Bullet"))
            {
                GameManager.instance.AddScore(SCORE_VALUE);
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
