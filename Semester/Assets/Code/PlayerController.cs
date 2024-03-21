using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.Audio;
using Unity.VisualScripting;
using StarterAssets;
using UnityEngine.UI;

namespace Puzzle
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;

        private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
        private KeywordRecognizer keywordRecognizer;

        private bool isGravityFlipped = false;
        private Rigidbody _rigidbody;
        private Vector3 originalGravity;

        public Image normalState;
        public Image workingState;

        public Light followingLight;
        public bool isLightOn = false;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            originalGravity = Physics.gravity;

            //Associates Words as Passwords
            keywordActions.Add("Room", DoorOpen); //Tutorial House Password
            keywordActions.Add("Vase", DoorOpen); //House 1 Password
            keywordActions.Add("Doom", DoorOpen); //House 2 Password

            //Assigning Words to Functions
            //keywordActions.Add("Appear", Appear);
            keywordActions.Add("Disappear", Disappear);
            keywordActions.Add("Flip", FlipGravity);
            keywordActions.Add("Light", ChangeLight);

            keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            keywordRecognizer.Start();

            //Checks if Keyword is working
            Debug.Log("Keyword Recognizer Started: " + keywordRecognizer.IsRunning);
        }

        private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log("Keyword: " + args.text);
            keywordActions[args.text].Invoke();
        } //Allows keywords to be recognized

        private void Awake()
        {
            instance = this;
        }

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Mouse mouseInput = Mouse.current;
                Vector2 mousePosition = mouseInput.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 2f))
                {
                    NoteController targetNote = hit.transform.GetComponent<NoteController>();
                    if (targetNote)
                    {
                        targetNote.Interact();
                    }
                }
            }

        }

        public void work()
        {
            normalState.gameObject.SetActive(false);
            workingState.gameObject.SetActive(true);
        } //Voice Tester UI changes to green
        public void normal()
        {
            normalState.gameObject.SetActive(true);
            workingState.gameObject.SetActive(false);
        } //Voice Tester UI changes back to white

        private void DoorOpen()
        {
            float interactRange = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                //print(collider.name);
                if (collider.GetComponent<Door>())
                {
                    //print("I found the door");
                    Door targetdoor = collider.GetComponent<Door>();
                    if (targetdoor.GetPassword() == "Room")
                    { 
                        targetdoor.Interact();
                        work();
                        Invoke("normal", 1);
                    }
                    if(targetdoor.GetPassword() == "Vase")
                    {
                        targetdoor.Interact();
                        work();
                        Invoke("normal", 1);
                    }
                }
            }
        }

        /*private void Appear()
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                //print(collider.name);
                if (collider.GetComponent<AppearableObject>())
                {
                    //print("I found the closet");
                    AppearableObject targetObject = collider.GetComponent<AppearableObject>();
                    targetObject.Appear();
                    work();
                    Invoke("normal", 1);
                }
            }
        }*/
        
        private void Disappear()
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                //print(collider.name);
                if (collider.GetComponent<AppearableObject>())
                {
                    //print("I found the door");
                    AppearableObject targetObject = collider.GetComponent<AppearableObject>();
                    targetObject.Disappear();
                    work();
                    Invoke("normal", 1);
                }
            }
        } //Object Disappear

        void FlipGravity()
        {

            isGravityFlipped = !isGravityFlipped;
            work();
            Invoke("normal", 1);

            if (isGravityFlipped )
            {
                _rigidbody.MoveRotation(Quaternion.Euler(180f, 0f, 0f));
                Physics.gravity = new Vector3(0, -originalGravity.y, 0);
                GetComponent<FirstPersonController>().Gravity = 15;
                GetComponent<FirstPersonController>()._verticalVelocity = 0;
               
            }
            else
            {
                transform.position -= new Vector3(0,5,0);
                transform.rotation = Quaternion.identity;
                //_rigidbody.MoveRotation(Quaternion.Euler(180f, 0f, 0f));
                Physics.gravity = new Vector3(0, originalGravity.y, 0);
                GetComponent<FirstPersonController>().Gravity = -15;
                GetComponent<FirstPersonController>()._verticalVelocity = 0;
            }

        } //Flips Character Gravity

        void ChangeLight()
        {
            isLightOn = !isLightOn;
            work();
            Invoke("normal", 1);
            if (isLightOn)
            {
                //followingLight.GetComponent<LightController>().TurnOn;
                //GetComponent<LightController>().TurnOn;
                followingLight.intensity = 5f;
            }
            else {
                followingLight.intensity = 1f;
            }
        }
    }
}
