using System.Collections;
using UnityEngine;

public class SpaceShipControll : MonoBehaviour
{
    const string PROJECTILE_POOL_NAME = "Bullet";

    public GameObject bullet;
    public Transform firePoint;
    public float chargeTime = 0.2f;
    public GameObject explosion;

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
        if (Input.GetKey(KeyCode.RightArrow))
            gameObject.transform.position += new Vector3(0.1f, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            gameObject.transform.position += new Vector3(0, 0.1f, 0);

        if (Input.GetKey(KeyCode.DownArrow))
            gameObject.transform.position += new Vector3(0, -0.1f, 0);

        if (Input.GetKey(KeyCode.Space) && isReady)
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
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);

            GameManager.instance.gameOverLabel.SetActive(true);
            GameManager.instance.retryBtn.SetActive(true);
            GameManager.instance.quitBtn.SetActive(true);
        }
    }
}
