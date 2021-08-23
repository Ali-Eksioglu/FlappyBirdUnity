using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boruspawner : MonoBehaviour
{

public kusHareket KusScript;
public GameObject Borular;

public float spawntime;

    
    public IEnumerator SpawnBoru()
    {
        while(!KusScript.isDead){
            Instantiate(Borular, new Vector3(8,Random.Range(-1,3),0) , Quaternion.identity);
            yield return new WaitForSeconds(spawntime);
        }
        
    }

}
