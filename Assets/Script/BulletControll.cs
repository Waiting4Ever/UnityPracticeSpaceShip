using UnityEngine;

public class BulletControll : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.2f, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("[BulletControll::OnCollisionEnter] hit object");
            Disable();
        }
    }

    void Disable()
    {
        //Disable the bullet so it can be reused by the Object Pool
        gameObject.SetActive(false);
    }
}
