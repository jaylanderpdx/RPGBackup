using UnityEngine;
using System.Collections;
using CharacterControl;
public class Pause : MonoBehaviour {


   

        public static Pause instance;

        // Use this for initialization
        void Start()
        {
            instance = this;

        }
     void Awake()
    {
        instance = this;
    }
        public static void Go()
        {

        BaseCharacterController[] characterlist = instance.gameObject.GetComponentsInChildren<BaseCharacterController>();
        Debug.Log("Pausing..");

        foreach (BaseCharacterController chars in characterlist)
        {
            Debug.Log(chars.name);
            chars.Pause();
        }

            instance.enabled = false;
        }

        public static void Resume()
        {
            instance.enabled = true;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }