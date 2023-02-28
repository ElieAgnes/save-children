using UnityEngine;
     
namespace DebugStuff
{
    public class ConsoleToGUI : MonoBehaviour
    {
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

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F8))
            {
                isActive = !isActive;
                if(isActive)
                {
                    Debug.Log("Console enable");
                }
                else
                {
                    Debug.Log("Console disable");
                }
            }
        }

        public void Log(string logString, string stackTrace, LogType type)
        {
            output = logString;
            stack = stackTrace;
            myLog = "[" + System.DateTime.Now.ToString("hh:mm:ss") + "] " + output + "\n" + myLog;
            if (myLog.Length > 5000)
            {
                myLog = myLog.Substring(0, 4000);
            }
        }

        void OnGUI()
        {
            if(isActive)
            {
                myLog = GUI.TextArea(new Rect(10, 10, Screen.width - 20, Screen.height/2), myLog);
            }
        }
    }
}