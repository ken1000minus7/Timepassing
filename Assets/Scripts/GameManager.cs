using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject duck;
    public Transform player;
    void Start()
    {
        StartCoroutine(SpawnDuck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnDuck()
    {
        while(true)
        {
            float x = Random.Range(Mathf.Max(0, player.position.x - 100), Mathf.Min(1000, player.position.x + 100));
            float z = Random.Range(Mathf.Max(0, player.position.z - 100), Mathf.Min(1000, player.position.z + 100));
            Instantiate(duck, new Vector3(x, 0, z), Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
