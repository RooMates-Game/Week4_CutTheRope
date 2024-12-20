using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public Weight weigth;
    [SerializeField] private int links = 7;

    private GameObject link;

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;

        for (int i = 0; i < links; i++) // Create ropes
        {
            link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            previousRB = link.GetComponent<Rigidbody2D>();
        }

        weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
    }
}
