using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class Weight : MonoBehaviour {

	public float distanceFromChainEnd = 0.6f;
	private CandyCounter candyCounter;

	private void Start() {
		candyCounter = Object.FindFirstObjectByType<CandyCounter>();
	}
	
	
	[SerializeField] [Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;

	Vector3 viewportPosition;
	public void ConnectRopeEnd (Rigidbody2D endRB)
	{
		HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRB;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag =="frog")
		{
			SceneManager.LoadScene(sceneName);
		}
		if(other.tag =="candy")
		{
			Destroy(other.gameObject);
			candyCounter.AddCandy(1);

			
			
			
		}
	}

	private void Update() {
		viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
		 // Check if the object is outside the viewport
		if (viewportPosition.x < 0 || viewportPosition.x > 1 || 
			viewportPosition.y < 0 || viewportPosition.y > 1)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

}
