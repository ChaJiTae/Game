using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject floorObject;

    //float timeDiff;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if  (timer > 10)
        {
            GameObject newfloor = Instantiate(floorObject);
            newfloor.transform.position = new Vector3(5, Random.Range(-1.7f, 5.7f), 0);
            timer = 0;
        }

    }
}
