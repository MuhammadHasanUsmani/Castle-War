using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleDrag : MonoBehaviour
{
    [System.Serializable]
    public class Boxes
    {
#pragma warning disable 0649
        public Collider2D boxCollider;
        public float min;
        public float max;
        public float BoxHealth;
        public Text boxHealthText;
#pragma warning restore 0649
    }
    int boxHealthIndex = 0;
    //
    [SerializeField]
    List<Boxes> boxes = new List<Boxes>();
    [SerializeField]
    List<GameObject> box = new List<GameObject>();
    

    public float playerHealth = 15f;
    public float enemyHealth;
    public Text playerHealthText;
    // positions 
    Vector2 lastPosition;
    Vector2 firstPosition;
    //

    public bool isActive = false;
    Collider2D lastObject;

    //mouse position for drag
    Vector2 point;
    float x;
    float y;
    //

    public float speed = 15f;
    public bool checkFight = false;
    public bool checkMouse = false;
    public Camera cam;
    Vector3 campoint;

    // check index
    int collideIndex = 2;
    public GameObject lastpos;
     
    // Player Animator
    public Animator anim;

    // for disable scroll horizontal///////////////////////
    public GameObject scrollrect;
    /// //////////////////////////////////////////////////




    private void Start()
    {
        lastPosition = transform.position;
        firstPosition = transform.position;
        transform.position = LevelSpawner.Instance.playercastleBox.transform.position;
        LevelSpawner.Instance.ChangePOsition();
        for (int i = 0; i < boxes.Count; i++)
        {
            boxes[i].BoxHealth = Random.Range(boxes[i].min, boxes[i].max);
        }
        //scrollrect.GetComponent<ScrollRect>();
    }
    void Update()
    {
        for (int i = 0; i < boxes.Count; i++)
        {

            boxHealthIndex = i;
            boxes[boxHealthIndex].boxHealthText.text = boxes[boxHealthIndex].BoxHealth.ToString();
            //if (boxes[boxHealthIndex].boxCollider == null)
            //{
            //    boxes.RemoveAt(boxHealthIndex);
            //}
        }
        playerHealthText.text = playerHealth.ToString();
        
    }

    void OnMouseDrag()
    {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        //z = gameObject.transform.position.z;

        point = Camera.main.ScreenToWorldPoint(new Vector2(x, y));
        gameObject.transform.position = point;

        //Debug.Log("x: " + point.x + "   y: " + point.y);
    }
    private void OnMouseUp()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, lastObject.transform.position, speed * Time.deltaTime);
            lastPosition = transform.position = lastObject.transform.position;
            Vector2 newpos;
            newpos = transform.position;
            newpos = new Vector2(lastObject.transform.position.x - 0.5f, lastObject.transform.position.y);
            lastPosition = newpos;
            //transform.position = Vector2.Lerp(lastPosition, newpos, Time.deltaTime*0.2f);
            transform.position = lastPosition;
            //print("mouseup");
            if (lastObject != null)
            {
                StartCoroutine("Fade");

            }
        }
        else
        {
            transform.position = lastPosition;
        }
        checkMouse = true;
        //this.transform.SetParent(LevelSpawner.Instance.littleCantaner.transform);
        //LevelSpawner.Instance.littleCantaner.transform.SetParent(LevelSpawner.Instance.bigCantaner.transform);
        scrollrect.GetComponent<ScrollRect>().horizontal = true;

    }
    private void OnMouseDown()
    {
        checkMouse = false;
        //this.transform.SetParent(null);
        //LevelSpawner.Instance.littleCantaner.transform.SetParent(null);
        scrollrect.GetComponent<ScrollRect>().horizontal = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("collide");
        checkFight = true;
        isActive = true;
        lastObject = collision;


        //if (boxes[2].boxCollider == collision)
        //{ 
        //    boxes[2].BoxHealth
        //}

        if (collision.gameObject.tag == "Box")
        {
            for (int i = 0; i < box.Count; i++) //boxes[boxes.Count].BoxHealth // box.Count
            {
                if (collision.gameObject.Equals(box[i]))
                {
                    //print(i);
                    collideIndex = i;
                    break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("exit");

        if (lastObject == collision)
        {   
            isActive = false; 
            lastObject = null; 
            checkFight = false;
        }
        
        if (lastObject == null)
        {
            StopCoroutine("Fade");
            //print("destroy");
        }

        if (boxes[collideIndex].BoxHealth <= 0)
        {
            Destroy(collision.gameObject);
            //Check.Instance.ListCheck();
            //LevelSpawner.Instance.tepmNum--;
            LevelSpawner.Instance.PlayerCastle();
        }
            
            

    }

   

    public void Fight()
    {
        if (playerHealth > enemyHealth)
        {
            playerHealth = playerHealth += enemyHealth;
            boxes[collideIndex].BoxHealth = 0;
            transform.position = Vector3.Lerp(lastPosition, firstPosition, 10f /*/ Time.deltaTime*/);
            //transform.position = new Vector2(firstPosition.x,firstPosition.y);
            lastPosition = firstPosition;
            //print("Enemy "+ collideIndex + " is Dead");
        }
        else
        {
            anim.SetBool("IsDying", true);
            //print("Player Dead");
        }
    }
    IEnumerator Fade()
    {
        anim.SetBool("IsFight", true);
        yield return new WaitForSeconds(2f);
        //print("enter");
        if (checkFight && checkMouse)
        {
            enemyHealth = boxes[collideIndex].BoxHealth;
            //print("Enemy Health is " + enemyHealth);
            Fight();
            //lastPosition = Vector3.Lerp(this.transform.position, lastpos.transform.position, speed * Time.deltaTime);
            //transform.position = Vector2.Lerp(lastPosition, firstPosition, 2f * Time.deltaTime);
        }
        anim.SetBool("IsFight", false);
        //CameraMove();

    }

    //public void CameraMove()
    //{
    //    campoint = cam.transform.position;
    //    if (playerHealth == 65)
    //    {
    //        Vector3 newpos =  campoint = new Vector3 (9,0,-10);
    //        cam.transform.position = Vector3.Lerp(campoint, newpos, 2f * Time.deltaTime);
    //        //cam.transform.position = campoint;
    //    }
    //    else if (playerHealth == 415)
    //    {
    //        campoint = cam.transform.position;
    //        campoint.x = (18);
    //        cam.transform.position = campoint;
    //        float newsizeCamera = cam.orthographicSize + 2f;
    //        cam.orthographicSize = newsizeCamera;
    //    }
    //    //cam.transform.position = Vector3.Lerp(campoint, newpos, 2f * Time.deltaTime);
    //    //cam.transform.position = campoint;

    //}
}// class








        //int index = FindObjectOfType<SampleDrag>().boxes.IndexOf();
        //int index = boxes.IndexOf(<SampleDrag>().boxes,boxes.Count); //FindObjectOfType<SampleDrag>().
        //Debug.Log(index + "ye num hai");


            //Destroy(boxes[1].boxCollider);
            //Destroy(box[1]);
        //boxes[collideIndex].BoxHealth = 0f;
    //public float range = 2f;
    //public GameObject raycastObj;
    //[Range(0, 5)]
    //public float rangerate;
        //rangerate = 2.5f;
    //private void Update()
    //{
        //Debug.DrawRay(transform.position, transform.right * range, Color.red);
        //EnemyCheck();
       //float  finalrate = rangerate / 256f * 100;
        //print(rangerate / 5 * 256 );
    //}

    //private void EnemyCheck()
    //{
    //    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * range, Color.red);
    //    int layerMask = 1 << 8;
    //    layerMask = ~layerMask;
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right ,/*TransformDirection(Vector2.left)*/ range,layerMask);
    //    if (hit.collider && hit.collider.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Hit : " + hit.collider.name);
    //    }
    //    //if (hit.collider && hit.collider.CompareTag("Enemy"))
    //    //{
    //    //    print("detect enemy");
    //    //}
    //}
