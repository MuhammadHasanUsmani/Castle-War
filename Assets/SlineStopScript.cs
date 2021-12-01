using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;

public class SlineStopScript : MonoBehaviour
{
    SplineFollower SFollower;
    SplineComputer com;
    public bool start = true;
    //public List<SplineComputer> Scom = new List<SplineComputer>();
    [SerializeField]
    public List<SplineTracer.NodeConnection> node = new List<SplineTracer.NodeConnection>();
    
    //Spline _spline;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i <=node.Count; i++)
        //{
        //   print (node[i].node.transform.position);
        //print(i+ " node count");
        //}
        //print(node.Count + " node count++");
        //SFollower.enabled = false;
        //_spline = GetComponent<Spline>();
        //var lenth  =_spline.points.Length;
        //print(lenth);
        //com = GetComponent<SplineComputer>();
        ////com.Break();
        //SFollower = GetComponent<SplineFollower>();
        //for (int i = 0; i < 2; i++)
        //{
        //    print("hi");
        //}
        //SFollower.onNode += OnNodePassed;
      
        
    }

    private void OnNodePassed(List<SplineTracer.NodeConnection> passed)
    {

        //throw new NotImplementedException();
        //for (int i = 0; i < passed.Count -1; i++)
        //{
        //    print(i);
        //}
        //SplineTracer.NodeConnection nodeConnection;
        //if (passed[passed.Count].point == 0)

        //{
        //    print("1st");
        //}
        //if (passed[passed.Count].point == 1/*this.transform == passed[1].node*/)

        //{
        //    print("2nd");
        //}
        //SplineTracer.NodeConnection nodeConnection = passed[0];
        //Debug.Log(nodeConnection.node.name + " at point " + nodeConnection.point);
        //SFollower.spline = Scom[1];
        //SFollower.enabled = false;
        //SplineTracer.NodeConnection nodeConnection1 = passed[1];
        //Debug.Log(nodeConnection1.node.name + " at point " + nodeConnection1.point);
        //print("1");



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SFollower.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SFollower.enabled = true;
        }
        //if (start)
        //{

        //}

    }

    public void FirstRound()
    {

        //SFollower.enabled = true;
        print("1st round");
    }
}
