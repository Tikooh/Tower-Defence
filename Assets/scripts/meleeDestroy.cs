using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeDestroy : MonoBehaviour
{
    public bool isMelee;

    private IEnumerator DestroyMelee()
    {
        // Debug.Log("waiting");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        if (isMelee == true)
        {
            Debug.Log("deleting");
            StartCoroutine(DestroyMelee());
        }
    }

    // Update is called once per frame
}
