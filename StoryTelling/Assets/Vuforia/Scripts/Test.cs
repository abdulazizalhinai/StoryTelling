using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : DefaultTrackableEventHandler
{
    bool move = false;
    int index = 1;
    //public Transform cube;
    //public Rigidbody rb;
    //Transform mytransform;
    private Vector3 mOffset;
    private float mZCoord;
    Vector3 OrginalPostion;
    int red = 0, green = 0;
    Vector3 OrginalScale;
    bool done = false;

    public string Box;

    public GameObject Rim;

    ParticleSystem effects;
    // Update is called once per frame
    protected override void Start()
    {

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
        Rim.SetActive(false);
        transform.localScale = OrginalScale;
    }
    void OnMouseDown()

    {
        Rim.SetActive(true);
        //transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        //mOffset.y = gameObject.transform.position.y + 1.5f;

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

    private void OnMouseEnter()
    {
        Rim.SetActive(true);
    }

    private void OnMouseExit()
    {
        Rim.SetActive(false);
    }


    void OnMouseDrag()

    {
        Rim.SetActive(true);
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, (GetMouseAsWorldPoint() - Camera.main.transform.position).normalized, out hit, 100, 1 << 9);

        Vector3 point = hit.point;
        //point.y = 0.5f;

        transform.position = point + hit.normal * 5.9f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Box == other.tag)
        {

            done = true;
            print("ok");
            if (Box == "RedBox")
            {
                PlayerPrefs.SetInt("red", PlayerPrefs.GetInt("red") + 1);
                //Destroy(gameObject);

                GetComponent<BoxCollider>().enabled = false;
                //transform.position = new Vector3(Random.Range(0.145f,-0.145f),Random.Range( 0.12f,-0.12f), 0.325f);
                //transform.position = new Vector3(0.145f, 0.12f, 0.325f);

                transform.localScale += new Vector3(0.08f, 0.08f, 0.08f);
                print(PlayerPrefs.GetInt("red"));
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<BoxCollider>().enabled = false;
            }
            else //if (Box == "GreenBox")
            {
                //// Destroy(gameObject);
                //transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
                //GetComponent<Rigidbody>().useGravity = false;
                //GetComponent<Rigidbody>().isKinematic = true;
               
                PlayerPrefs.SetInt("green", PlayerPrefs.GetInt("green") + 1);
                print(PlayerPrefs.GetInt("green"));
            }
            if (PlayerPrefs.GetInt("red") >= 3 && PlayerPrefs.GetInt("green") >= 3)
            {

                print("Welldone!");

                GameManager.Instance.GameWon();

            }
            //correct answer


        }
        else
        {

            print("no");
            transform.localPosition = OrginalPostion;

            //wrong answer
        }

    }

}



