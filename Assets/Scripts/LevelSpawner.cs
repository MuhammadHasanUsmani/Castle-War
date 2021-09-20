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
    // list for player Castle Box Position
    [SerializeField]
    List<GameObject> playercastle = new List<GameObject>();

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
        //for (int i = 0; i < boxesRow0.Count; i++)
        //{
        //    int index = i;
        //    //print(boxesRow0[i].BoxHealth);
        //}
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
            boxesRow1[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);
            boxesRow0[i].boxCollider.transform.localPosition = new Vector2(boxElements[i].x, boxElements[i].y);

            boxRows[i].transform.position = new Vector2(boxPositions[i].x, boxPositions[i].y);
        }
    }

    public void SetPositon()
    {
        for (int i = 0; i < boxRows.Count ; i++)
        {
            if (boxRows[i] == null)
            {
                boxRows.RemoveAt(i);
                boxRows[i].transform.position = new Vector2(boxPositions[i].x, boxPositions[i].y);
            }
        }

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
    }

    public void PlayerCastle()
    {
        playerCastle =  Instantiate(playercastleBox);
        playercastle.Add(playerCastle);
        for (int i = 0; i < playercastle.Count; i++)
        {
            playercastle[i].transform.position = new Vector2(boxElements[i].x, boxElements[i].y);
        }
        //for (int i = playercastle.Count; i == 0; i--)
        //{
        //    for (int j = 0; j < boxElements.Count; j++)
        //    {
        //        playercastle[i].transform.position = new Vector2(boxElements[j].x, boxElements[j].y);
        //    }
        //}
    }
} // class






