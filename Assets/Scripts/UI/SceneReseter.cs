using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneReseter : MonoBehaviour
{
    private bool canPush;

    private void Start()
    {
        canPush = true;
    }

    public void OnResetButton(InputAction.CallbackContext context)
    {
        if (context.started
            && canPush)
        {
            canPush = false;
            SceneManager.LoadScene(0);
            StartCoroutine(ButtonReset());
        }
    }

    private IEnumerator ButtonReset()
    {
        yield return null;
        canPush = true;
    }
}
