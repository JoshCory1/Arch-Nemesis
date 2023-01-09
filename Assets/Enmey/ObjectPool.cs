using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enmeyPrefab;
    [SerializeField] float spawnTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnEnmey()); 
    }
    IEnumerator SpawnEnmey()
    {
        while(true)
        {
            Instantiate(enmeyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
