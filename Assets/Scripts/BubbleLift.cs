using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleLift : MonoBehaviour
{   
    [SerializeField] private float liftForce = 1f;
    private Transform ballTransform;
    private bool isTriggered = false;
	[SerializeField] private string triggeringBall;
	[SerializeField] private string triggeringFrog;

	[SerializeField] private string sceneName;



    private void Update()
    {
        if(isTriggered)
        {
            transform.Translate(liftForce * Time.deltaTime * Vector2.up);
            if (ballTransform != null)
            {
                ballTransform.position = transform.position;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringBall))
        {
            ballTransform = other.transform;
            isTriggered = true;
        }

        if (other.CompareTag(triggeringFrog)){
            SceneManager.LoadScene(sceneName);
        }
        
    }



    
}
