using UnityEngine;
using UnityEngine.SceneManagement;

public class Weight : MonoBehaviour {

	public float distanceFromChainEnd = 0.6f;

	[SerializeField] [Tooltip("Name of scene to move to when triggering the given tag")] string sceneName;
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
		}
	}

}
