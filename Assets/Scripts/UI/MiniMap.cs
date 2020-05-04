using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{

    [SerializeField]
    Transform playerPos;

    [SerializeField]
    Camera mapCamera;

    public List<MapIconModel> mapIconModels = new List<MapIconModel>();

    private void Update()
    {
        DrawIconsOnMap();
    }

    private void DrawIconsOnMap()
    {
        foreach(MapIconModel mapObject in mapIconModels)
        {
            if(mapObject.GameObjectRefernce == null)
            {
                print("HI");
            }
            Vector3 screenPos = mapCamera.WorldToViewportPoint(mapObject.GameObjectRefernce.transform.position);
            mapObject.Icon.transform.SetParent(this.transform);

            RectTransform rt = this.GetComponent<RectTransform>();
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);

            screenPos.x = Mathf.Clamp(screenPos.x * rt.rect.width + corners[0].x, corners[0].x, corners[2].x);
            screenPos.y = Mathf.Clamp(screenPos.y * rt.rect.height + corners[0].y, corners[0].y, corners[2].y);
            screenPos.z = 0;
            mapObject.Icon.transform.position = screenPos;
        }
    }
    public void AddMapIconModel(GameObject gameObjectRefence, Image icon)
    {
        MapIconModel mapIconModel = new MapIconModel() { GameObjectRefernce = gameObjectRefence, Icon = Instantiate(icon) };
        mapIconModels.Add(mapIconModel);
    }
    public void RemoveGameObjectIcon(GameObject gameObjectRefence)
    {
        List<MapIconModel> cleanedMapIconModels = new List<MapIconModel>();
        for (int i = 0; i < mapIconModels.Count; ++i)
        {
            if (mapIconModels[i].GameObjectRefernce == gameObjectRefence)
            {
                Destroy(mapIconModels[i].Icon);
                continue;
            }
            else
            {
                cleanedMapIconModels.Add(mapIconModels[i]);
            }
        }
        mapIconModels.Clear();
        mapIconModels.AddRange(cleanedMapIconModels);
    }

}
