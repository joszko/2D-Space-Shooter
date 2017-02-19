using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    float enemyRate = 5;
    float nextEnemy = 1;
    float nextWaveDelay = 2;
    float nextWaveStart = 0;

    public GameObject enemy01Prefab;
    public GameObject enemy02Prefab;

    public float waveLimit = 10;

    float enemycount = 1;

    GameObject[] getCount;

    float spawnDistance = 15f;

    public GameObject playButton;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        nextWaveStart += Time.deltaTime;
        //Debug.LogError(nextWaveStart);
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0 && enemycount <= waveLimit && playButton.activeSelf == false)
        {
            nextEnemy = enemyRate;
            enemyRate *= -0.9f;

            if (enemyRate < 2)
            {
                enemyRate = 2;
            }

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;
            offset = offset.normalized * spawnDistance;

            Instantiate(enemy01Prefab,transform.position + offset, Quaternion.identity);
            enemycount++;

            if (nextWaveDelay <= nextWaveStart)
            {
                Instantiate(enemy02Prefab, transform.position + offset, Quaternion.identity);
            }


        }


	}

    public void ResetEnemyCount()
    {
        enemycount = 0;
    }

    }

