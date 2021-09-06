using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private SampleDrag _sampleDrag ;
    public Vector3[] Positions;

    private int mCurrentIndex = 0;

    public float Speed = 2.0f;
    //public GameObject player;
    float score; 


    void start()
    {
        _sampleDrag = GetComponent<SampleDrag>();
        //player.GetComponent<SampleDrag>();
        // score = player.GetComponent<SampleDrag>().playerHealth;
    }
    // Update is called once per frame
    void Update()
    {
        //_sampleDrag.playerHealth

        Vector3 currentPos = Positions[mCurrentIndex];

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("work");
            if (mCurrentIndex < Positions.Length - 1)
                mCurrentIndex++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (mCurrentIndex > 0)
                mCurrentIndex--;
        }

        transform.position = Vector3.Lerp(transform.position, currentPos, Speed * Time.deltaTime);

    }
}
