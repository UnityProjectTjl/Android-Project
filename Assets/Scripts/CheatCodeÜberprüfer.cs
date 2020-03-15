using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheatCodeÜberprüfer : MonoBehaviour
{
    public Text password;
       
    public void Überprüfe()
    {
       if (password.text =="x08y09z03")
        {
            SceneManager.LoadScene("CheatMenu");
            print(password.text);
        }
       

        

    }

  
    
    
}
