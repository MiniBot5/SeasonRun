using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class GroundTracker: MonoBehaviour
{
    IEnumerator Rotate(float duration)
    {
        float startRotation = _carObject.transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            _carObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }

    private Racer racer = new();
    [SerializeField]
    private GameObject _carObject;
    public void Start()
    {
       
    }

    public void Update()
    {
        
        if (Physics.SphereCast(gameObject.transform.position, .1f, Vector3.down, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Grass"))
            {
                _carObject.GetComponent<SCC_Drivetrain>().engineTorque = 100;
                Debug.Log(_carObject.GetComponent<SCC_Drivetrain>().engineTorque);
            }
            else if (hit.collider.gameObject.CompareTag("Ice") !& _carObject.GetComponent<SCC_Drivetrain>().car.NonSlip)
            {
                _carObject.GetComponent<SCC_Drivetrain>().brakeTorque = 100;
            }
            else if (hit.collider.gameObject.CompareTag("Water"))
            {
                racer.ResetToLastCheckpoint();
            }
            //else if (hit.collider.gameObject.CompareTag("Leaves"))
            //{
            //    Rotate(5f);
            //    Destroy(hit.collider.gameObject);
            // }
            else
            {
                _carObject.GetComponent<SCC_Drivetrain>().engineTorque = 1000;
                Debug.Log(_carObject.GetComponent<SCC_Drivetrain>().engineTorque);
            }
                
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(gameObject.transform.position, .2f);
    }

}
