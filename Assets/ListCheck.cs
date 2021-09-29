using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCheck : MonoBehaviour
{
    [SerializeField]
    LinkedList<string> box = new LinkedList<string>();
    [SerializeField] 
    List<int> num = new List<int>();

    int namee;
    int number;
    
        //int lastnum =  num[num.Count - 1];

    // Start is called before the first frame update
    void Start()
    {
        box.AddFirst("a");
        box.AddFirst("b");
        box.AddFirst("c");
        foreach (var item in box)
        {
            print(item +  num[number]);
            number++;
        }
        //print(lastnum);
        //lastnum--;
        //print(lastnum);
        //for (int i = 0 ; i < num.Count; i++)
        //{
        //    print(num[i] + box[i]);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = box.Count; i < 0; i--)
        //{
        //    print(i);

        //}
        //for (int a = 0; a < num.Count; a++)
        //{
        //    //number = a;
        //print(a);
        //}
        
    }
}
