/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering_Script : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public float yAxis, GasInput, BreakInput;
    // Start is called before the first frame update
    void Start()
    {
        print(LogitechGSDK.LogiSteeringInitialize(false));
    }

    // Update is called once per frame
    void Update()
    {
        if(LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            yAxis = rec.lY;

            if(rec.lX > 0)
            {
                GasInput = 0;
            }else if(rec.lX < 0)
            {
                GasInput = rec.lY / -32768f;
            }

            if(rec.lRz > 0)
            {
                BreakInput = 0;
            }else if(rec.lRz < 0)
            {
                BreakInput = rec.lRz / -32768f;
            }
        }
    }
}
*/