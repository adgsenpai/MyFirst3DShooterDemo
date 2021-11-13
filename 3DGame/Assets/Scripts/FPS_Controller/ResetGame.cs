using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public Text DeathMessage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject soundEffect = GameObject.Find("Death");
            soundEffect.GetComponent<AudioSource>().Play();
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        Text myText = GameObject.Find("deathMessage").GetComponent<Text>();
        myText.text = "You are dead";
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(Application.loadedLevel);
    }
}
