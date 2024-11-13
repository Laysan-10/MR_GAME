
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit; 
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;





public class SpawnerMulticoloredCubes : MonoBehaviour
{
	[SerializeField] private InputActionReference spawnAction;
	[SerializeField] private XRRayInteractor xrRayInteractor;
	[SerializeField] private PlaneClassification targetPlaneClassification;
	[SerializeField] private GameObject objectPrefab;

//private void OnEnable()
//{
//	spawnAction.action.Enable();
//	spawnAction.action.performed += OnSpawn;
//}

//private void OnDisable()
//{
//	spawnAction.action.Disable();
//	spawnAction.action.performed -= OnSpawn;
//}

public void OnSpawn(/*InputAction.CallbackContext context*/)
{
		Debug.Log("OnSpawn");
	if (xrRayInteractor.enabled && xrRayInteractor.TryGetCurrent3DRaycastHit(out var raycastHit, out _))
	{
            Debug.Log("1");
            if (raycastHit.transform.TryGetComponent(out ARPlane arPlane) && (arPlane.classification & targetPlaneClassification) != 0)
		{
                Debug.Log("2");
                var hitPose = new Pose(raycastHit.point, Quaternion.LookRotation(raycastHit.normal));

			var instantiate = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
			instantiate.name = "SpawnedObject";

			instantiate.GetComponent<Renderer>().material.color = Random.ColorHSV();
			instantiate.AddComponent<ARAnchor>();

			return;
		}

		if (raycastHit.transform.name == "SpawnedObject")
		{
                Debug.Log("3");
                Destroy(raycastHit.transform.gameObject);

			return;
		}
	}
}
}
