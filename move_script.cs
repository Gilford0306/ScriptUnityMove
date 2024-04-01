using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_script : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    private Vector3 initialPosition;
    void Start()
    {
        Debug.Log("Script start");
        initialPosition = player.transform.position;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        float startY = player.transform.position.y;
        float targetY = startY + jumpHeight;
        float elapsedTime = 0f;
        float jumpDuration = 0.5f; 

        while (elapsedTime < jumpDuration)
        {
            float newY = Mathf.Lerp(startY, targetY, (elapsedTime / jumpDuration));
            player.transform.position = new Vector3(player.transform.position.x, newY, player.transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Land());
    }

    IEnumerator Land()
    {
        float startY = player.transform.position.y;
        float initialY = initialPosition.y;
        float elapsedTime = 0f;
        float landDuration = 0.2f; 

        while (elapsedTime < landDuration)
        {
            float newY = Mathf.Lerp(startY, initialY, (elapsedTime / landDuration));
            player.transform.position = new Vector3(player.transform.position.x, newY, player.transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}