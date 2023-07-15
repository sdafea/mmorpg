using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    class MinimapManager : Singleton<MinimapManager>
    {
        public Sprite LoadCurrentMinimap()
        {
            return Resloader.Load<Sprite>("UI/Minimap/" + User.Instance.CurrentMapData.MiniMap);
        }

    }
}

