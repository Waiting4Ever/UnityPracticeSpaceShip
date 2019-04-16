using UnityEngine;

public class WhiteEnemyControll : MonoBehaviour
{
    const string EXPLODE_POOL_OBJECT = "explodeObject";
    const int SCORE_VALUE = 10;

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
                GameObject explodeObject = ObjectPoolManager.instance.GetObject(EXPLODE_POOL_OBJECT, true, gameObject.transform.position, gameObject.transform.rotation);
                if (explodeObject == null)
                {
                    Debug.Log("[WhiteEnemyControll::OnCollisionEnter2D] explodeObject not enough!!");
                }
                GameManager.instance.AddScore(SCORE_VALUE);
            }
            Disable();
        }
    }

    void Disable()
    {
        //Disable the WhiteEnemy so it can be reused by the Object Pool
        gameObject.SetActive(false);
    }
}
