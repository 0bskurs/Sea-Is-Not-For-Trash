using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    
    List<Resolution> predefined16by9Resolutions = new List<Resolution>
    {
        // 16:9 Aspect Ratio Resolutions
        new Resolution { width = 720, height = 400 },
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 1600, height = 900 },
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 2560, height = 1440 },
        new Resolution { width = 3200, height = 1800 },
        new Resolution { width = 3840, height = 2160 },
       
    };
    List<Resolution> predefined4by3Resolutions = new List<Resolution>
    {
        // 4:3 Aspect Ratio Resolutions
        new Resolution { width = 800, height = 600 },
        new Resolution { width = 1024, height = 768 },
        new Resolution { width = 1280, height = 960 },
        new Resolution { width = 1400, height = 1050 },
        new Resolution { width = 1600, height = 1200 },
        new Resolution { width = 2048, height = 1536 },
        new Resolution { width = 2800, height = 2100 }
    };
    List<Resolution> predefined3by2Resolutions = new List<Resolution>
    {
        // 3:2 Aspect Ratio Resolutions
        
    };


    List<Resolution> possibleResolutionsForUsersMonitor = new List<Resolution> { };

    void Start()
    {
        PopulateResolutionDropdown();
        
    }

    void PopulateResolutionDropdown()
    {
        
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        Vector2Int usersLargestResolution = GetLargestDisplaysResolution();
        int usersWidth = usersLargestResolution.x;
        int usersHeight = usersLargestResolution.y;

        if (Camera.main.aspect >= 1.7)
        {

            for (int i = 0; i < predefined16by9Resolutions.Count; i++)
            {
                Resolution currentRes = predefined16by9Resolutions[i];

                if (usersWidth >= currentRes.width && usersHeight >= currentRes.height)
                {
                    //Resolution is possible for users screen size so add it as an option
                    string option = currentRes.width + "x" + currentRes.height;
                    options.Add(option);
                    currentResolutionIndex = i;
                    possibleResolutionsForUsersMonitor.Add(currentRes);

                }
                else
                {
                    break; //At highest possible resolution for user so stop checking for more options
                }
                Debug.Log("16:9");
            }
        }
        else if (Camera.main.aspect >= 1.5)
        {

            Debug.Log("3:2");
        }
        else if (Camera.main.aspect >= 1.3)
        {
            for (int i = 0; i < predefined4by3Resolutions.Count; i++)
            {
                Resolution currentRes = predefined4by3Resolutions[i];

                if (usersWidth >= currentRes.width && usersHeight >= currentRes.height)
                {
                    //Resolution is possible for users screen size so add it as an option
                    string option = currentRes.width + "x" + currentRes.height;
                    options.Add(option);
                    currentResolutionIndex = i;
                    possibleResolutionsForUsersMonitor.Add(currentRes);

                }
                else
                {
                    break; //At highest possible resolution for user so stop checking for more options
                }

            }
            Debug.Log("4:3");
        }

        



        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetResolution(currentResolutionIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = possibleResolutionsForUsersMonitor[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //This script used to use "Screen.currentResolution" to grab the width and height. The issue with that was it wouldn't sense if a new larger monitor was plugged into the device. Therefore would't show the higher resolution for it (Data inside PlayerPref on screens was not updating)
    //The below method fixes the aforementioned problem by looping through all the users displays and returning the highest valued resolution in the form of a vector2Int with the width set as x and the height set as y 
    private Vector2Int GetLargestDisplaysResolution()
    {
        int largestResWidth = 0;
        int largestResHeight = 0;

        for (int i = 0; i < Display.displays.Length; i++)
        {
            Display myDisplay = Display.displays[i];
            int myWidth = myDisplay.systemWidth;
            int myHeight = myDisplay.systemHeight;
            //Debug.LogError("Display DETECTED: " + myWidth + "x" + myHeight); //Uncomment this line for debugging purposes to see which displays are being detected

            if (myWidth > largestResWidth && myHeight > largestResHeight)
            {
                largestResWidth = myWidth;
                largestResHeight = myHeight;
            }
        }

        return new Vector2Int(largestResWidth, largestResHeight);
    }
}
