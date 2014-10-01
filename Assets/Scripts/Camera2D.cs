using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public Transform target;
	public Transform edge;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	private Bounds boundingBox;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	
	// Use this for initialization
	void Start () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;

		// define camera boundaries from edge object
		boundingBox = edge.renderer.bounds;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 topLeft = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		Vector2 bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));
		Rect cameraRect = new Rect (topLeft.x, topLeft.y, bottomRight.x - topLeft.x, bottomRight.y - topLeft.y);

		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		// Clamp camera at edge
		if (newPos.x < boundingBox.min.x + cameraRect.width*0.5f)
		{
			newPos.x = boundingBox.min.x + cameraRect.width*0.5f;
		}
		else if (newPos.x > boundingBox.max.x - cameraRect.width*0.5f)
		{
			newPos.x = boundingBox.max.x - cameraRect.width*0.5f;
		}
		if (newPos.y > boundingBox.max.y + cameraRect.height*0.5f)
		{
			newPos.y = boundingBox.max.y + cameraRect.height*0.5f;
		}
		else if (newPos.y < boundingBox.min.y - cameraRect.height*0.5f)
		{
			newPos.y = boundingBox.min.y - cameraRect.height*0.5f;
		}

		transform.position = newPos;
		
		lastTargetPosition = target.position;		
	}
}
