using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance = null;
    // custom class for bax variables
    [System.Serializable]
    private class Boxes
    {
#pragma warning disable 0649
        public Collider2D boxCollider;
        public float minHealth;
        public float maxHealth;
        public float BoxHealth;
        public Text boxHealthText;
#pragma warning restore 0649
    }

    // player castle prefeb
    public GameObject playercastleBox;
    GameObject playerCastle;

    // list for boxElements in row
    [SerializeField]
    List<Boxes> boxesRow0 = new List<Boxes>();
    [SerializeField]
    List<Boxes> boxesRow1 = new List<Boxes>();
    [SerializeField]
    List<Boxes> boxesRow2 = new List<Boxes>();


    //[SerializeField]
    //List<Boxes> boxesRow3 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow4 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow5 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow6 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow7 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow8 = new List<Boxes>();
    //[SerializeField]
    //List<Boxes> boxesRow9 = new List<Boxes>();


    // list for box elements positions
    [SerializeField]
    List<Vector2> boxElements = new List<Vector2>();
    //[SerializeField]
    //List<Vector2> boxElements1 = new List<Vector2>();
    // boxes rows
    [SerializeField]
    List<GameObject> boxRows = new List<GameObject>();
    // list for boxPositions
    [SerializeField]
    List<Vector2> boxPositions = new List<Vector2>();

    /////////////////

    // list for player Castle Box Position
    [SerializeField]
    //LinkedList<GameObject> playercastle = new LinkedList<GameObject>();
    Stack<GameObject> PlayerCastleBox = new Stack<GameObject>();
    //[SerializeField]
    //List<GameObject> playercastle = new List<GameObject>();
    // 
    [SerializeField]
    List<Vector2> playerCastlePosition = new List<Vector2>();
    public int tepmNum = 0;

    // Contaners
    public GameObject bigCantaner;
    public GameObject littleCantaner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        { Destroy(gameObject); }
    }
    // Start is called before the first frame update
    void Start()
    {

        // player castle box information in start
        tepmNum = playerCastlePosition.Count - 1;
        playerCastle = Instantiate(playercastleBox);
        PlayerCastleBox.Push(playerCastle);
        playerCastle.transform.SetParent(littleCantaner.transform);

        littleCantaner.transform.SetParent(bigCantaner.transform);
        print(tepmNum +"is this start");
        // end

        ChangePOsition();
    }

    // Update is called once per frame
    void Update()
    {
        SetPositon();
    }
    public void ChangePOsition()
    {
        for (int i = 0; i < 11; i++)
        {
            //boxesRow9[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow8[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow7[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow6[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow5[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow4[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            //boxesRow3[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            boxesRow0[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            boxesRow1[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            boxesRow2[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);

            boxRows[i].transform.position = new Vector2(boxPositions[i].x, boxPositions[i].y);
        }
    }

    public void SetPositon()
    {
        // for all row positions
        for (int i = 0; i < boxRows.Count ; i++)
        {
            if (boxRows[i] == null)
            {
                boxRows.RemoveAt(i);
                boxRows[i].transform.position = new Vector2(boxPositions[i].x, boxPositions[i].y);
            }
        }
        // for 1 row
        for (int i = 0; i < boxesRow0.Count ; i++)
        {
            if (boxesRow0[i].boxCollider == null)
            {
                boxesRow0.RemoveAt(i);
                print("box gone");
                
                //Vector2.Lerp(boxesRow[i].boxCollider.transform.position, new Vector2(boxElements0[i].x, boxElements0[i].y), 0.5f * Time.deltaTime);
                boxesRow0[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            }
        }
        // for 2 row
        for (int i = 0; i < boxesRow1.Count; i++)
        {
             if (boxesRow1[i].boxCollider == null)
             {
                    boxesRow1.RemoveAt(i);
                    print("box gone");
                    //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
                    //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
                    //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
                    boxesRow1[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
             }
        }
        // for 3 row
        for (int i = 0; i < boxesRow2.Count; i++)
        {
            if (boxesRow2[i].boxCollider == null)
            {
                boxesRow2.RemoveAt(i);
                print("box gone");
                //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
                //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
                //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
                boxesRow2[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            }
        }
        // for 4 row
        //for (int i = 0; i < boxesRow3.Count; i++)
        //{
        //    if (boxesRow3[i].boxCollider == null)
        //    {
        //        boxesRow3.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow3[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 5 row
        //for (int i = 0; i < boxesRow4.Count; i++)
        //{
        //    if (boxesRow4[i].boxCollider == null)
        //    {
        //        boxesRow4.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow4[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 6 row
        //for (int i = 0; i < boxesRow5.Count; i++)
        //{
        //    if (boxesRow5[i].boxCollider == null)
        //    {
        //        boxesRow5.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow5[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 7 row
        //for (int i = 0; i < boxesRow6.Count; i++)
        //{
        //    if (boxesRow6[i].boxCollider == null)
        //    {
        //        boxesRow6.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow6[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 8 row
        //for (int i = 0; i < boxesRow7.Count; i++)
        //{
        //    if (boxesRow7[i].boxCollider == null)
        //    {
        //        boxesRow7.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow7[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 9 row
        //for (int i = 0; i < boxesRow8.Count; i++)
        //{
        //    if (boxesRow8[i].boxCollider == null)
        //    {
        //        boxesRow8.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow8[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
        // for 10 row
        //for (int i = 0; i < boxesRow9.Count; i++)
        //{
        //    if (boxesRow9[i].boxCollider == null)
        //    {
        //        boxesRow9.RemoveAt(i);
        //        print("box gone");
        //        //Vector2 lastposition = boxesRow1[i].boxCollider.transform.position;
        //        //Vector2 newposition = boxElements1[i].x, boxElements1[i].y;
        //        //Vector2.Lerp(lastposition,newposition, 0.5f * Time.deltaTime);
        //        boxesRow9[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
        //    }
        //}
    }

    public void PlayerCastle()
    {
        playerCastle = Instantiate(playercastleBox);
        //playercastle.Add(playerCastle);
        PlayerCastleBox.Push(playerCastle);
        playerCastle.transform.SetParent(littleCantaner.transform);
        //int lastnum = playerCastlePosition.Count - 1;

        foreach (var item in PlayerCastleBox)
        {

            print(tepmNum + " is this method");
            //for (int i = playerCastlePosition.Count; i >= 0; i--)
            //{
            //    item.transform.position = new Vector2(playerCastlePosition[i].x, playerCastlePosition[i].y);
            //}
            item.transform.position = new Vector2(playerCastlePosition[tepmNum].x, playerCastlePosition[tepmNum].y);
            tepmNum--;
        }
        tepmNum = playerCastlePosition.Count - 1;
        //for (int i = 0; i < playercastle.Count; i++) //for (int i = 0; i < playercastle.Count; i++)
        //{
        //    print("stack");
        //    print("stack is " + PlayerCastleBox.Count);

        //    playercastle[i].transform.position = new Vector2(playerCastlePosition[i].x, playerCastlePosition[i].y);
        //}
        //for (int i = lastnum; i >= 0; i--)
        //{
        //    playercastle[i].transform.position = new Vector2(playerCastlePosition[i].x, playerCastlePosition[i].y);

        //     print( "castle " +lastnum);
        //}
        //for (int i = playercastle.Count; i == 0; i--)
        //{
        //    for (int j = 0; j < boxElements.Count; j++)
        //    {
        //        playercastle[i].transform.position = new Vector2(boxElements[j].x, boxElements[j].y);
        //    }
        //}
    }
} // class






