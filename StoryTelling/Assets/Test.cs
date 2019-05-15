using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : DefaultTrackableEventHandler
{
    public bool isbear = false;
    bool move = false;
    int index = 1;
    public Transform greenbox, redbox;
    private Vector3 mOffset;
    private float mZCoord;
    Vector3 OrginalPostion;
    int red = 0, green = 0;
    Vector3 OrginalScale,redboxorginal, greenboxorginal;
    bool done = false;
    public AudioClip TryAgin;
    public AudioClip EXSELLENT;
    public AudioClip YOUAREWEDUFULL;

    public string Box;

    public GameObject Rim;

    ParticleSystem effects;
    // Update is called once per frame
    protected override void Start()
    {
        //greenbox = GetComponent<Transform>();
        //redbox = GetComponent<Transform>();
        redboxorginal = redbox.transform.localScale;
        greenboxorginal = greenbox.transform.localScale;
        base.Start();
        PlayerPrefs.SetInt("red", 0);
        PlayerPrefs.SetInt("green", 0);
        OrginalPostion = transform.localPosition;
        OrginalScale = transform.localScale;
        //  cube = GetComponent<Transform>();
        //print(OrginalPostion);
        //rb = GetComponent<Rigidbody>();
    }
    private void OnMouseUp()
    {
        greenbox.transform.localScale = greenboxorginal;
        redbox.transform.localScale = redboxorginal;
        Rim.SetActive(false);
        transform.localScale = OrginalScale;
    }
    void OnMouseDown()
    {
         
        if (!done)
        {
            Rim.SetActive(true);
            if (!isbear)
                transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            mZCoord = Camera.main.WorldToScreenPoint(
                gameObject.transform.position).z;



            // Store offset = gameobject world pos - mouse world pos

            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            //mOffset.y = gameObject.transform.position.y + 1.5f;
        }
        if (Box == "RedBox")
        {
            print("red");
            redbox.transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);
            greenbox.transform.localScale -= new Vector3(0.09f, 0.09f, 0.09f);
        }
        else
        {
            redbox.transform.localScale -= new Vector3(0.09f, 0.09f, 0.09f);
            greenbox.transform.localScale += new Vector3(0.15f, 0.15f, 0.15f);
        }
            

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        if (!done)
        {
            Rim.SetActive(true);
            RaycastHit hit;

            Physics.Raycast(Camera.main.transform.position, (GetMouseAsWorldPoint() - Camera.main.transform.position).normalized, out hit, 100, 1 << 9);

            Vector3 point = hit.point;
            //point.y = 0.5f;

            transform.position = point + hit.normal * 5.9f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Box == other.tag)
        {
            if (!done)
            {

                int a = Random.Range(1, 3);
                if (a == 1)
                    SoundManager.instance.PlaySingle(YOUAREWEDUFULL);
                else
                    SoundManager.instance.PlaySingle(EXSELLENT);
                done = true;
                print("ok");
                if (Box == "RedBox")
                {
                    PlayerPrefs.SetInt("red", PlayerPrefs.GetInt("red") + 1);
                    
                    print(PlayerPrefs.GetInt("red"));
                   
                }
                else //if (Box == "GreenBox")
                {
                    PlayerPrefs.SetInt("green", PlayerPrefs.GetInt("green") + 1);
                    print(PlayerPrefs.GetInt("green"));
                }
                if (PlayerPrefs.GetInt("red") >= 4 && PlayerPrefs.GetInt("green") >= 4)
                {

                    print("Welldone!");

                    GameManager.Instance.GameWon();

                }
                //correct answer

            }
        }
        else
        {
            SoundManager.instance.PlaySingle(TryAgin);
            print("no");
            transform.localPosition = OrginalPostion;

            //wrong answer
        }

    }

}