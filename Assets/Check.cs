using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount < 1) // agar child na ho to destroy 
        {
            print("child is 0");
            Destroy(this.gameObject,0.2f);
        }

    }
}
