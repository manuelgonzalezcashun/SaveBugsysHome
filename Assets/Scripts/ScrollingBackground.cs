using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    Transform cameraTransform;
    Vector3 lastCameraPosition;

    float textureUnitSizeX;

    [SerializeField] float parallaxEffectMultiplier = 0.5f;
    Vector3 move = new Vector3(0.01f, 0.0f, 0.0f);

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;

    }
    void LateUpdate()
    {
        cameraTransform.position += move;

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;


        if (cameraTransform.position.x - transform.position.x > textureUnitSizeX)
        {
            float offset = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3 (cameraTransform.position.x + offset, transform.position.y);
        }
    }
}
