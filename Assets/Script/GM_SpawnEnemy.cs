using System.Collections;
using UnityEngine;

public class GM_SpawnEnemy : MonoBehaviour
{
    public bool isEnabled = true;
    public float checkRate = 0.5f;

    [Header("WhiteEnemy")]
    public GameObject whiteEnemyObject;

    [Header("RedEnemy")]
    public GameObject redEnemyObject;

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
                    Instantiate(whiteEnemyObject, spawnEnemyPos, transform.rotation);
                    break;
                case 3:
                default:
                    Instantiate(redEnemyObject, spawnEnemyPos, transform.rotation);
                    break;
            }

            yield return checkDelay;
        }
    }
}
