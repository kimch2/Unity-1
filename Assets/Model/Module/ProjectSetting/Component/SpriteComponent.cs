using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Xml;
using ETModel;
using System;

namespace ETModel {
    [ObjectSystem]
    public class SpriteComponentAwakeSystem : AwakeSystem<SpriteComponent>
    {
        public override void Awake(SpriteComponent self)
        {
            self.Awake();
        }
    }

    public class SpriteComponent : UIPanelComponent {

        public GameObject SpriteResource;

        public void Awake()
        {
            //SpriteResource = GameObject.Instantiate(ResourcesHelper.LoadPrefab(ResourceType.UI, "Sprite")) as GameObject;
        }

       public Sprite GetSprite(string type,string id)
        {
            ReferenceCollector  collect= SpriteResource.transform.Find(type).GetComponent<ReferenceCollector>();
            Texture2D texture = collect.Get<Texture2D>(id);
            Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sp;
         }
     }
}