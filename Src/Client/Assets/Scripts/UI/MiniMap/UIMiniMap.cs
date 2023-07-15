using Manager;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniMap : MonoBehaviour
{

    public Collider minimapBoundingBox;
    public Image minimap;
    public Image arrow;
    public Text mapName;
    private Transform playerTransform;

    void Start()
    {
        InitMap();
    }

    void Update()
    {
        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;

        float relaX = playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float relaY = playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = relaX / realWidth;
        float pivotY = relaY / realHeight;

        minimap.rectTransform.pivot = new Vector2(pivotX, pivotY);
        minimap.rectTransform.localPosition = Vector2.zero;
        arrow.transform.eulerAngles = new Vector3(0, 0, -playerTransform.eulerAngles.y);
    }

    void InitMap()
    {
        mapName.text = User.Instance.CurrentMapData.Name;
        if (minimap.overrideSprite == null)
            minimap.overrideSprite = MinimapManager.Instance.LoadCurrentMinimap();
        minimap.SetNativeSize();
        minimap.transform.localPosition = Vector3.zero;
        playerTransform = User.Instance.CurrentCharacterObject.transform;
    }
}

