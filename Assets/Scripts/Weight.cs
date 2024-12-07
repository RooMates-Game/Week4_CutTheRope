using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] float distanceFromChainEnd = 0.3f;

    public void connectedRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f , -distanceFromChainEnd);
    }
}
