using UnityEngine;

public class WhiteEnemyControll : MonoBehaviour
{
    static int SCORE_VALUE = 10;

    public GameObject explosion;

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, -0.1f, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("SpaceShip"))
        {
            Debug.Log("[WhiteEnemyControll::OnCollisionEnter2D] hit object");
            if (other.gameObject.CompareTag("Bullet"))
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                GameManager.instance.AddScore(SCORE_VALUE);
            }
            Destroy(gameObject);
        }
    }
}
