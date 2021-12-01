using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerAnim : MonoBehaviour
{

    Vector3 startPosition;
    // Start is called before the first frame update
    bool isHovering = false;
    Collider objectCollider;
    int id;
    void Start()
    {
        startPosition = transform.localPosition;
        Debug.Log("started");

        objectCollider = GetComponent<Collider>();

        id = GetInstanceID();
    }


    void Float()
    {
        Vector3 position = transform.localPosition;
        position.y = startPosition.y + Mathf.Sin(Time.time * 5) * 0.5f;
        transform.localPosition = position;
    }



    // Update is called once per frame
    void Update()
    {
        Float();


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            bool objectIsHit = hit.collider.GetInstanceID() == objectCollider.GetInstanceID();
            isHovering = objectIsHit;

            if (objectIsHit && Input.GetButtonDown("Fire1"))
            {
                char choice = tag[tag.Length - 1];
                SceneController.Instance.GoToScene(choice);
            }
        }
        else isHovering = false;


    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * (isHovering ? 3f : 1f), 0.1f);

    }
}
