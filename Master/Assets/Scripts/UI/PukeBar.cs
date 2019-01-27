using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PukeBar : FillingBar
{
    public float FillPerFrame;
    public GameObject GameOverScreen;

    private void Start()
    {
        GameOverScreen.SetActive(false);
    }

    private void Update()
    {
        Bar.fillAmount += FillPerFrame;

        if (Bar.fillAmount >= 1)
        {
            StartCoroutine(EndGame());
        }
    }

    public void ChangeFillAmout(float amount)
    {
        Bar.fillAmount += amount;
    }

    public void ResetBar()
    {
        Bar.fillAmount = 0;
    }

    IEnumerator EndGame()
    {
        GameObject mudda = GameObject.Find("Mudda");
        PlayerController controller = FindObjectOfType<PlayerController>();
        mudda.GetComponent<NavMeshAgent>().SetDestination(controller.transform.position);
        //kotzen
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Vector3.Distance(mudda.transform.position, controller.transform.position) < 1f);
        yield return new WaitForSeconds(1);
        GameOverScreen.SetActive(true);
    }
}