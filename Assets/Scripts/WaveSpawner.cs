using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    

    [System.Serializable]
    public class Wave
    {
        public string name; //Wave name
        public string description;
        public Transform[] enemies; //Enemy position 
        public int count; //Spawn number
        public float rate; //Spawn rate
    }

    public Wave[] waves;
    public int nextWave = 0;
    public static WaveSpawner instance;
    //public Wave wave = new Wave();

    //Wave CountDown
    public float timeBetweeNWaves = 5f;
    public float waveCountdown;

    //Check if dead every second
    private float searchCountdown = 1f;

    //SpawnPoints
    public Transform[] spawnPoints;

    //Stop Spawn
    public bool stopSpawn;

    public SpawnState state = SpawnState.COUNTING;

    //Animator
    public Animator waveanim;

    //complete
    public GameObject completed;

    private void Awake()
    {
        instance = this;
        completed.SetActive(false);
    }

    private void Start()
    {
        waveCountdown = timeBetweeNWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            // Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
            }
            else
            {
                return;
            }

        }

        if (!stopSpawn)
        {
            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    //Start spawning wave
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }

    }

	void WaveCompleted()
	{
		Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweeNWaves;
        waveanim.Play("wavetextanim",0 ,0);

        if (nextWave + 1 > waves.Length - 1)
        {
            stopSpawn = true;
            Debug.Log("All waves complete!");
            completed.SetActive(true);
        }
        else
        {
            nextWave++;
        }
        
	}

    public bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f; //If enemies still alive, restart the timer
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        // Spawning
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            for (int j = 0; j < _wave.enemies.Length; j++)
            {
                SpawnEnemy(_wave.enemies[j]);
                yield return new WaitForSeconds(1f / _wave.rate);
            }
           // yield return new WaitForSeconds(1f / _wave.rate);
        }

        // Done Spawning, Waiting for players to kill
        state = SpawnState.WAITING;

        //

        yield break;
    }

    void SpawnEnemy(Transform _enemies)
    {
        //Spawn Enemy
        Debug.Log("Spawning Enemy:" + _enemies.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemies, _sp.position, _sp.rotation);
        
    }

}
