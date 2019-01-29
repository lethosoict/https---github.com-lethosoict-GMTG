using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContaner;
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;
    private const float CAMERA_TRANSITION_SPEED = 3.0f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;


        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContaner.transform, false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(()=>LoadLevel(sceneName));
        }

        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);


        }
    }


    private void Update()
    {
     if(cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
        }   
    }

    private void LoadLevel(string sceneName)
    {
        Debug.Log(sceneName);
       // SceneManager.LoadScene(sceneName);
    }

    public void LookAt(Transform menuTransform)
    {
        //Camera.main.transform.LookAt(menuTransform.position);
        cameraDesiredLookAt = menuTransform;
    }

}
