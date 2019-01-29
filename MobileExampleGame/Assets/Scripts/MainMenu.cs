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

    public Material playerMaterial;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;
    private const float CAMERA_TRANSITION_SPEED = 3.0f;



    private void Start()
    {
        cameraTransform = Camera.main.transform;
       // ChangePlayerSkin(0);


        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelButtonContaner.transform, false);

            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(()=>LoadLevel(sceneName));
        }

        int textureIndex = 0;
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(shopButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(shopButtonContainer.transform, false);
            int index = textureIndex;
            container.GetComponent<Button>().onClick.AddListener(() => ChangePlayerSkin(index));
            textureIndex++;
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

    private void ChangePlayerSkin(int index)
    {
        float x = (index % 4) * 0.25f;
        float y = ((int)index/ 4) * 0.25f;

        if (y == 0.0f)
            y = 0.75f;
        else if (y == 0.25f)
            y = 0.5f;
        else if (y == 0.5f)
            y = 0.25f;
        else if (y == 0.75f)
            y = 0f;


        playerMaterial.SetTextureOffset("_MainTex", new Vector2(x,y));
        Debug.Log(index);
        GameManager.Instance.currentSkinIndex = index;
        GameManager.Instance.Save();

    }

}
