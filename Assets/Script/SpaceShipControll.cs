using System.Collections;
using UnityEngine;

public class SpaceShipControll : MonoBehaviour
{
    const string EXPLODE_POOL_OBJECT = "explodeObject";
    const string PROJECTILE_POOL_NAME = "Bullet";

    public GameObject bullet;
    public Transform firePoint;
    public float chargeTime = 0.2f;

    private bool isReady = true;
    WaitForSeconds shootingInterval;

    //The Reset() method will attempt to grab values in the editor to save time in finding references
    void Reset()
    {
        //Find the Charge Effects object, Fire Point object, and Drone Body object
        firePoint = transform.Find("SpaceShip/FirePoint");
    }

    void Start()
    {
        shootingInterval = new WaitForSeconds(chargeTime);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            gameObject.transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime, Input.touches[0].deltaPosition.y * Time.deltaTime, 0));

        if (isReady)
        {
            GameObject Bullet = ObjectPoolManager.instance.GetObject(PROJECTILE_POOL_NAME, true, firePoint.position, firePoint.rotation);
            if (Bullet == null)
            {
                Debug.Log("[SpaceShipControll] Bullet not enough!!");
            }
            isReady = false;
            StartCoroutine(Charging());
        }
    }

    IEnumerator Charging()
    {
        yield return shootingInterval;
        isReady = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("[SpaceShipControll::OnCollisionEnter2D] hit by Enemy");
            GameObject explodeObject = ObjectPoolManager.instance.GetObject(EXPLODE_POOL_OBJECT, true, gameObject.transform.position, gameObject.transform.rotation);
            if (explodeObject == null)
            {
                Debug.Log("[WhiteEnemyControll::OnCollisionEnter2D] explodeObject not enough!!");
            }
            Destroy(gameObject);

            GameManager.instance.gameOverLabel.SetActive(true);
            GameManager.instance.retryBtn.SetActive(true);
            GameManager.instance.quitBtn.SetActive(true);
        }
    }
}
