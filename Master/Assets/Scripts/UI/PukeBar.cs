using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PukeBar : FillingBar
{
    public float FillPerFrame;
    public GameObject GameOverScreen;
    public GameObject dude;
    public GameObject pukeDude;

    private void Start()
    {
        GameOverScreen.SetActive(false);
        DoorMiniGame.onLockFinished += () => Bar.fillAmount = 0;
    }

    private void Update()
    {
        Bar.fillAmount += FillPerFrame;

        if (Bar.fillAmount >= 1)
        {
            int layer = dude.GetComponent<SpriteRenderer>().sortingOrder;
            dude.SetActive(false);
            pukeDude.SetActive(true);
            pukeDude.GetComponent<SpriteRenderer>().sortingOrder = layer;
            StartCoroutine(EndGame());
            FindObjectOfType<PlayerController>().enabled = false;
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
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Vector3.Distance(mudda.transform.position, controller.transform.position) < 1f);
        yield return new WaitForSeconds(1);
        GameOverScreen.SetActive(true);
        FindObjectOfType<SceneChanger>().GoToCreditScene();
    }
}