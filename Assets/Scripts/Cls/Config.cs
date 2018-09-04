using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/2810940969";
     public static string hedieuhanh="ios5";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/6761616961";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/8238350169";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/7900978589";
                         public static string hedieuhanh = "and5";

#endif

}
