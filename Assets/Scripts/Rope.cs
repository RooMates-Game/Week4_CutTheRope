using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hook;

    [SerializeField] private GameObject linkPrefab;

    [SerializeField] private int links = 7;

    [SerializeField] private Weight weight;

    private Transform linksFolder; // A folder to hold all the links
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // hook = hook.GetComponent<Rigidbody2D>();
        // Create a new folder (GameObject) to store the links
        GameObject folder = new GameObject("LinksFolder");
        linksFolder = folder.transform;
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            // Instantiate the link and set its parent to the folder
            GameObject link = Instantiate(linkPrefab, linksFolder);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if(i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();  
            }
            else
            {
                weight.connectedRopeEnd(link.GetComponent<Rigidbody2D>());
            }
            
        }
    }

}
