using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace KWJ.UI.MANAGER
{


    public class UiManager : MonoBehaviour
    {

        private static UiManager instance = null;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else Destroy(this.gameObject);
        }

        public static UiManager Instance
        {
            get
            {
                if(instance == null) return null;

                return instance;
            }
        }

    }
}