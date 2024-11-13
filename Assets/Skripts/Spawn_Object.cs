
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Spawn_Object : MonoBehaviour
{
  // XRRayInteractor для определения точки спавна
  [SerializeField] private XRRayInteractor xrRayInteractor;

  // Ссылка на Input Action 
  

  // Метод, вызываемый при нажатии на кнопку в руке
  public void SpawnObject(GameObject _spawn)
  {
	if (xrRayInteractor.enabled)
	{
	  // Создаем объект в позиции руки (с небольшим смещением для видимости)
	  var spawnPosition = xrRayInteractor.transform.position + xrRayInteractor.transform.forward * 0.5f; 
	  var spawnedObject = Instantiate(_spawn, spawnPosition, xrRayInteractor.transform.rotation);
		spawnedObject.AddComponent<ARAnchor>(); 
	}
  }
}
