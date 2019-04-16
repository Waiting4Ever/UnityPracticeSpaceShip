using System.Collections;
using UnityEngine;

public class GM_SpawnEnemy : MonoBehaviour
{
    private const string WHITE_ENEMY_POOL_OBJECT = "WhiteEnemy";
    private const string RED_ENEMY_POOL_OBJECT = "RedEnemy";

    public bool isEnabled = true;
    public float checkRate = 0.5f;

    WaitForSeconds checkDelay;

    void Start()
    {
        checkDelay = new WaitForSeconds(checkRate);
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        //Initially wait before spawning to give the player time to prepare
        yield return checkDelay;

        while (isEnabled)
        {
            int spawnEnemyType = Random.Range(0, 4);
            Vector3 spawnEnemyPos = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0);
            switch (spawnEnemyType)
            {
                case 0:
                case 1:
                case 2:
                    GameObject whiteEnemy = ObjectPoolManager.instance.GetObject(WHITE_ENEMY_POOL_OBJECT, true, spawnEnemyPos, transform.rotation);
                    if (whiteEnemy == null)
                    {
                        Debug.Log("[GM_SpawnEnemy::SpawnCycle] WhiteEnemy not enough!!");
                    }
                    break;
                case 3:
                default:
                    GameObject redEnemy = ObjectPoolManager.instance.GetObject(RED_ENEMY_POOL_OBJECT, true, spawnEnemyPos, transform.rotation);
                    if (redEnemy == null)
                    {
                        Debug.Log("[GM_SpawnEnemy::SpawnCycle] RedEnemy not enough!!");
                    }
                    break;
            }

            yield return checkDelay;
        }
    }
}
