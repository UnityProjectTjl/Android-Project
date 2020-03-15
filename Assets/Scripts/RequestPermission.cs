using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class RequestPermission : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            // The user authorized use of the Location.
        }
        else
        {
            // We do not have permission to use the Location.
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
