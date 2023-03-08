using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    bool inCombat = true;

    public GameObject sprite;

    void Start()
    {
        sprite.SetActive(false);
        {
            StartCoroutine(Flickering());
        }
    }

    private void Update()
    {

    }

    public IEnumerator Flickering()
    {
        while (inCombat)
        {
            sprite.SetActive(true);
            yield return new WaitForSeconds(0.22f);
            sprite.SetActive(false);
            yield return new WaitForSeconds(0.22f);
        }
    }
}
