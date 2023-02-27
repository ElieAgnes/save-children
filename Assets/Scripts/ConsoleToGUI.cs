using UnityEngine;
     
    namespace DebugStuff
    {
        public class ConsoleToGUI : MonoBehaviour
        {
    //#if !UNITY_EDITOR
            static string myLog = "";
            private string output;
            private string stack;
            private bool isActive = false;
    
            void OnEnable()
            {
                Application.logMessageReceived += Log;
            }
    
            void OnDisable()
            {
                Application.logMessageReceived -= Log;
            }

            void Start()
            {
                toggle();
            }

            void Update()
            {
                if(Input.GetKeyDown(KeyCode.F8))
                {
                    if(isActive)
                    {
                        Debug.Log("ACTIVE MA GUEULE");
                    }
                    isActive = !isActive;
                }
            }

            void toggle()
            {
                // if(isActive)
                // {
                //     myLog.SetActive(true);
                // }
                // else
                // {
                //     myLog.SetActive(false);
                // }
            }
    
            public void Log(string logString, string stackTrace, LogType type)
            {
                output = logString;
                stack = stackTrace;
                myLog = output + "\n" + myLog;
                if (myLog.Length > 5000)
                {
                    myLog = myLog.Substring(0, 4000);
                }
            }
    
            void OnGUI()
            {
                //if (!Application.isEditor) //Do not display in editor ( or you can use the UNITY_EDITOR macro to also disable the rest)
                if(isActive)
                {
                    myLog = GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height - 10), myLog);
                }
            }
    //#endif
        }
    }