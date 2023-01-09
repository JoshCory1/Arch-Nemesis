using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enmeyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;
    GameObject[] pool;

    void Awake()
    {
        populatePool();
    }
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnEnmey()); 
    }
    void populatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enmeyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnmey()
    {
        while(true)
        {
           EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
