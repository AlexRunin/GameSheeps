using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Windmil_Wheel_Button : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] Animator animator;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.down * 10;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(StartWheel());
    }

    IEnumerator StartWheel()
    {
        //animator.SetTrigger("Wheel");

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, i);

            yield return null;
        }

        //yield return new WaitForSeconds(1f);
        transform.position = endPosition;


    }
}

