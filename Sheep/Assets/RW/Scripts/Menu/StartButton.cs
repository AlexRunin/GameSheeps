using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class StartButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(StartGame()); //Вызываем каррутину
    }

    IEnumerator StartGame()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // SceneManager.LoadScene(1);
    }

    // заанемировать key menu
    // Добавить анимацию при нажатие на объект
    

}   
