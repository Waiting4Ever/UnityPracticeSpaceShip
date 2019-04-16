using UnityEngine;

public class RedEnemyControll : MonoBehaviour
{
    const string EXPLODE_POOL_OBJECT = "explodeObject";
    const int SCORE_VALUE = 90;

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
                GameObject explodeObject = ObjectPoolManager.instance.GetObject(EXPLODE_POOL_OBJECT, true, gameObject.transform.position, gameObject.transform.rotation);
                if (explodeObject == null)
                {
                    Debug.Log("[RedEnemyControll::OnCollisionEnter2D] explodeObject not enough!!");
                }
            }
            Disable();
        }
    }

    void Disable()
    {
        //Disable the RedEnemy so it can be reused by the Object Pool
        gameObject.SetActive(false);
    }
}
