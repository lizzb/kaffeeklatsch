/*
 * ObjectLabel
 * 
 * Makes a GUIText label follow an object in 3D space.
 * Useful for things like having name tags over players' heads.
 * 
 * Notes: from http://wiki.unity3d.com/index.php/ObjectLabel
 
Usage: Attach this script to a GUIText object, and drag the object it should follow into the Target slot.
For best results, the anchor of the GUIText should probably be set to lower center,
depending on what you're doing.

Note: This script also works with GUITextures.
 
*/

using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof(GUIText))]
public class ObjectLabel : MonoBehaviour
{
 	// Object that this label should follow... the one it is attached to... ??
	public Transform target;  
	
	/*
	Offset is used to position the label somewhere relative to the actual target's position.
	The default of (0, 1, 0) is useful for having the label appear above the object,
	rather than appearing right on top of it.
	*/
	// Units in world space to offset; 1 unit above object by default
	public Vector3 offset = Vector3.up;    
	/*
	If ClampToScreen is on, the label will never disappear
	even if the target is off the screen, but will attempt to follow as best it can
	(for example, if the target is off to the left of the camera out of sight,
	the label will still be visible on the left).
	*/
	// If true, label will be visible even if object is off screen
	public bool clampToScreen = false;  
	
	/*
	ClampBorderSize sets how much space will be left at the borders
	if the label is being clamped to the screen, to help ensure that the label
	is still readable and not partially cut off.
	This is in viewport space, so the default .05 is 5% of the screen's size.
	*/
	// How much viewport space to leave at the borders when a label is being clamped
	public float clampBorderSize = 0.05f;  
	
	/*
	If UseMainCamera is checked, the first camera in the scene tagged MainCamera will be used.
	If it's not checked, you should drag the desired camera onto the CameraToUse slot,
	which is otherwise unused if UseMainCamera is true.
	*/
	
	// Use the camera tagged MainCamera
	public bool useMainCamera = true;   
	public Camera cameraToUse ;   // Only use this if useMainCamera is false
	Camera cam ;
	Transform thisTransform;
	Transform camTransform;
 
	void Start ()
	{
		//target = this; doesn't work
		thisTransform = transform;
		if (useMainCamera)
			cam = Camera.main;
		else
			cam = cameraToUse;
		camTransform = cam.transform;
	}
 
	void Update ()
	{
 
		if (clampToScreen) {
			Vector3 relativePosition = camTransform.InverseTransformPoint (target.position);
			relativePosition.z = Mathf.Max (relativePosition.z, 1.0f);
			thisTransform.position = cam.WorldToViewportPoint (camTransform.TransformPoint (relativePosition + offset));
			thisTransform.position = new Vector3 (Mathf.Clamp (thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize),
                                             Mathf.Clamp (thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize),
                                             thisTransform.position.z);
 
		} else {
			thisTransform.position = cam.WorldToViewportPoint (target.position + offset);
		}
	}
}
	
