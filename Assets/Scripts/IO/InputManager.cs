using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameIO
{
    public static class InputManager
    {

        public static readonly bool ISMOBILE = Application.isMobilePlatform;

        public static void InitHandler(GameObject gameObject)
        {
            if(ISMOBILE)
            {
                gameObject.AddComponent<InputHandlerMobile>();
            }
            else
            {
                gameObject.AddComponent<InputHandlerPC>();
            }
        }
    }
}