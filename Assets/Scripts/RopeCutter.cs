using UnityEngine;

public class RopeCutter : MonoBehaviour
{
	
	Rigidbody2D rb;
	Camera Cam;
	[SerializeField] private string triggeringTag;
	[SerializeField] private float bladeTimer = 0.05f;



	void Start()
	{
       rb = GetComponent<Rigidbody2D>();
	   Cam = Camera.main;
	}

	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			rb.position = Cam.ScreenToWorldPoint(Input.mousePosition);
			Invoke(nameof(Visible_blade), bladeTimer);
			
			RaycastHit2D hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.CompareTag(triggeringTag))
				{
					Destroy(hit.collider.gameObject);//cut blade
				    
					// remove all ropes
					int count_child = hit.transform.parent.gameObject.transform.childCount + 1; // +1 for the anchor
					for (int i = 0 ; i < count_child-1; i++)
					{
						Destroy(hit.transform.parent.gameObject.transform.GetChild(i).gameObject);
					}
				}
			}
		}


		if(Input.GetMouseButtonDown(0))
		{
           gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
	void Visible_blade()
	{
       gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}

	
}
