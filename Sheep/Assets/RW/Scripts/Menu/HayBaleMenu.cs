using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class HayBaleMenu : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Animator animator;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.up * 10;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(StartHayBale());
    }

    IEnumerator StartHayBale()
    {
        //animator.SetTrigger("Wheel");

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, i);

            yield return null;
        }
        //animator.gameObject.GetComponent<Vector3(Random.Range())>
        //animator.Play


        transform.position = endPosition;


    }
}
