using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_childs : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.childCount == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
