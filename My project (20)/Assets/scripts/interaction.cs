using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class interaction : MonoBehaviour
{
    public Transform Joint;
    public GameObject PlayerGO;
    public bool HororMode = false;
    public GameObject player;
    public int Fun;
    public GameObject BackroomsEndingGO;
    public GameObject lightObjectMain;
    public GameObject lightObjectCoridor;
    public GameObject lightObjectKitchen;
    public GameObject lightObjectBathroom;

    public GameObject TVon;
    public GameObject TVoff;

    public Animator DoorBathroom;

    public Animator FrigdeLeft;
    public Animator FrigdeRight;
    public GameObject Lights;

    public FirstPersonController fpc;
    public bool PcPlayer = false;

    public AudioSource light;
    public AudioSource DoorBathroomSound;
    public AudioSource SheerHeartAttackSound;
    public AudioSource HorHor;

    bool partyMode = false;
    public bool WasActiveHor;


    public GameObject ScaryEye;

    bool wasActivatedEyes;

    public Transform holdPosition1;

    public Transform holdPosition2;


    public Transform holdPosition3;


    GameObject Holding;
    Rigidbody HoldingRB;
    bool Holdingbool = false;

    public bool playingHor;

    GameObject Holding2;
    Rigidbody HoldingRB2;
    bool Holdingbool2 = false;
     
    public Light lightSource;
    public AudioSource music;

    public int countingLight;
    bool stopcounting;

    public Animator Phone;
    public bool holdingPhone = false;
    public GameObject Lighting;

    public Piano pianoCode;

    public bool pianoPlaying;

    public GameObject backrooms;

    public AudioSource Keyboard1;
    public AudioSource Keyboard2;
    public AudioSource KeyboardEnter;
    public AudioSource KeyboardSpace;
    public AudioSource KeyboardMouse;

    public int randomKey;

    public GameObject Bed;
    public bool BedEnding;

    public GameObject Miror;
    bool EndingSecret;
    public GameObject Closet;
    public GameObject Shoeske;

    public Animator ClosetLeft;
    public Animator ClosetRight;

    public LIghts TimeInGame;

    public GameObject nightLightOn;
    public GameObject nightLightOff;

    public TMP_Text Quest;
    public GameObject QuestTextGO;
    public string questString;
    public List<char> QuestList =new List<char>();


    public List<GameObject> PCApps = new List<GameObject>();
    public GameObject PCScreen;
    public AudioSource PCButton;

    public AudioSource HungryAudio;
    bool FrigdeWasOppened = false;

    bool NeedsFood = false;

    public GameObject PhoneCall;

    bool PhoneMenu = false;

    public GameObject cursorGO;
    public GameObject cursorSelect;
    public List<string> Selected = new List<string>();

    bool checkCamera = false;

    public GameObject number;
    public NumberManager numberManager;

    public GameObject Menu;
    bool MenuActive;
    public bool electricity = true;

    bool Tvon = false;
    bool LightmainOn = true;
    bool LightCorridorOn = true;
    bool LightKitchenOn = true;
    bool LightBathroomOn = true;
    bool PCOn = true;
    bool nightLightOnBool = false;

    public GameObject PizzaDelievery;
    public bool eated;
    public GameObject PizzaGo;
    public bool HoldingPizza;
    public GameObject Pizzaghost;
    public GameObject PizzaEmpty;

    public Animator blackScreen;

    public Transform RemotePosition;
    public GameObject Remote;
    Rigidbody RemoteRB;
    bool HoldingTVRemote = false;
    public GameObject MenuGO;
    Vector3 originalPos;
    public float shakeDuration = 0f;
    public float Intensivity = 0.2f;
    public AudioSource EatSound;
    bool CatFoodHoolding=false;
    public GameObject CatFoodGO;

    public GameObject Cat;
    public GameObject CatCutscene;

    public bool canOpenMenu=true;
    public Saving Save;

    public TV RemoteSkript;

    bool ifTriedBackrooms=false;

    public GameObject CorridorFloor;
    void Awake()
    {
    }
    void Start()
    {
        InvokeRepeating("ChangeColor", 0f, 0.25f);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 3))
            {
                if (hit.collider.name == "SwitchMain")
                {
                    if (electricity == true)
                    {
                        ToggleLight1();
                    }
                }
                else if (hit.collider.name == "SwitchCoridor")
                {

                    if (electricity == true)
                    {
                        ToggleLight2();
                    }
                }
                else if (hit.collider.name == "SwitchKitchen")
                {

                    if (electricity == true)
                    {
                        ToggleLight3();
                    }
                }
                else if (hit.collider.name == "SwitchBathroom")
                {

                    if (electricity == true)
                    {
                        ToggleLight4();
                    }
                }
                else if (hit.collider.name == "DoorBathroom")
                {
                    OpenBathroom();
                    DoorBathroomSound.Play();
                }
                else if (hit.collider.name == "TV")
                {

                    if (electricity == true)
                    {
                        TVOn();
                    }
                }
                else if (hit.collider.name == "Fridge")
                {
                    FridgeOpen();
                }
                else if (hit.collider.name == "PC")
                {
                    PcOpen();
                }
                else if (hit.collider.name == "ShearHeartAttack")
                {
                    SheerHeartAttack();
                }
                else if (hit.collider.name == "HoldPos1" || hit.collider.name == "PizzaReall"|| hit.collider.name == "CatFood(Clone)")
                {
                    if (Holdingbool == false && Holdingbool2 == false && HoldingTVRemote == false)
                    {
                        Holding = hit.transform.gameObject;
                        Hold1();
                    }
                }
                else if (hit.collider.name == "HoldPos2" || hit.collider.name == "PizzaAd")
                {
                    if (Holdingbool == false && Holdingbool2 == false && HoldingTVRemote == false)
                    {
                        Holding2 = hit.transform.gameObject;
                        Hold2();
                    }
                }
                else if (hit.collider.name == "Piano")
                {
                    if (electricity == true)
                    {
                        PianoActivate();
                    }
                }
                else if (hit.collider.name == "Bed")
                {
                    if (!lightObjectCoridor.activeSelf && !lightObjectMain.activeSelf && !lightObjectKitchen.activeSelf && !lightObjectBathroom.activeSelf && nightLightOn.activeSelf && !TVon.activeSelf && !PCScreen.activeSelf)
                    {
                        LayOnBed();
                    }
                    else if (lightObjectCoridor.activeSelf || lightObjectMain.activeSelf || lightObjectKitchen.activeSelf || lightObjectBathroom.activeSelf || TVon.activeSelf)
                    {
                        ResetText();
                        questString = ("Выключите Свет");
                        TextMaker();


                    }
                    else if (PCScreen.activeSelf)
                    {
                        ResetText();
                        questString = ("Выключите Компьютер");
                        TextMaker();

                    }
                    else if (!nightLightOn.activeSelf)
                    {
                        ResetText();
                        questString = ("Включите Ночник");
                        TextMaker();

                    }
                }
                else if (hit.collider.name == "Closet")
                {
                    ClosetOpen();
                }
                else if (hit.collider.name == "WallSecret")
                {
                    if (!Closet.activeSelf)
                    {
                        Shoeske.SetActive(true);
                    }
                }
                else if (hit.collider.name == "Moon")
                {

                    if (electricity == true)
                    {
                        MoonSwitch();
                    }
                }
                else if (hit.collider.name == "PCBlock")
                {
                    PCTurnOff();
                }
                else if (hit.collider.name == "braker")
                {
                    electricitySwitch();
                }
                else if (hit.collider.name == "DoorEnter")
                {
                    if (PizzaDelievery.activeSelf)
                    {
                        PizzaGo.SetActive(true);
                        GetPizza();
                        ResetText();
                        questString = "Отнесите пиццу на куxню";
                        TextMaker();
                    }
                }
                else if (hit.collider.name == "TVRemote")
                {
                    if (Holdingbool == false && Holdingbool2 == false && HoldingTVRemote == false)
                    {
                        HoldTvRemote();
                        RemoteSkript.PickedUp();
                    }
                }
                else if (hit.collider.name == "PizzaGhost" && HoldingPizza == true)
                {
                    Holdingbool = false;
                    HoldingRB = null;
                    Holding = null;
                    HoldingPizza = false;
                    PizzaGo.transform.position = hit.transform.position;
                    PizzaGo.transform.rotation = hit.transform.rotation;
                    blackScreen.SetTrigger("Back2Black");
                    eated = true;
                    Invoke("Eated", 1);
                }
                else if (hit.collider.name == "CatDish" && CatFoodHoolding)
                {
                    Cat.SetActive(true);
                    CatCutscene.SetActive(true);
                    Holdingbool = false;
                    HoldingRB = null;
                    Destroy(Holding);
                    Holding =null;
                    CatFoodHoolding = false;
                  
                }
            }
        }
        RaycastHit lookAt;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out lookAt, 3))
        {

            for (int i = 0; i < Selected.Count; i++)

            {
                if (lookAt.collider.name == Selected[i] && fpc.playerCanMove == true && fpc.cameraCanMove == true && Holdingbool == false && Holdingbool2 == false)
                {

                    cursorGO.SetActive(false);
                    cursorSelect.SetActive(true);
                    break;
                }
                else if (lookAt.collider.name != Selected[i] && fpc.playerCanMove == true && fpc.cameraCanMove == true)
                {
                    cursorGO.SetActive(true);
                    cursorSelect.SetActive(false);
                }
                else if (fpc.playerCanMove == false || fpc.cameraCanMove == false || Holdingbool == true || Holdingbool2 == true || HoldingTVRemote == true)
                {
                    cursorGO.SetActive(false);
                    cursorSelect.SetActive(false);
                    break;
                }
            }
        }
        else
        {
            if (PhoneMenu == false)
            {
                cursorGO.SetActive(true);
                cursorSelect.SetActive(false);
            }
        }

        if ((Input.GetKeyDown(KeyCode.Escape)) && pianoPlaying == false && PcPlayer == false)
        {
            Pause();
        }
        if (number.activeSelf && PhoneMenu == true)
        {
            numberManager.Activate();
        }
        else
        {
            numberManager.Deactivate();
        }
        if (PcPlayer == true && Input.GetKeyDown(KeyCode.Escape))
        {
            PcPlayer = false;
            fpc.cutsceneEnd = true;
        }
        if (pianoPlaying == true && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            pianoCode.PianoIsActive = false;
            fpc.cutsceneEnd = true;
            pianoPlaying = false;
        }
        if (Holdingbool == true)
        {
            if (Holding.name == "CatFood(Clone)")
            {
                Holding.transform.position = holdPosition1.position;
                Holding.transform.rotation = holdPosition3.rotation;
            }
            else
            {
                Holding.transform.position = holdPosition1.position;
                Holding.transform.rotation = holdPosition1.rotation;
                HoldingRB.isKinematic = true;
            }
        }
        if (Holdingbool2)
        {
            Holding2.transform.position = holdPosition2.position;
            Holding2.transform.rotation = holdPosition2.rotation;
            HoldingRB2.isKinematic = true;
        }
        if (HoldingTVRemote)
        {
            Remote.transform.position = RemotePosition.position;
            Remote.transform.rotation = RemotePosition.rotation;
            RemoteRB.isKinematic = true;
        }
        //if ((!lightObjectCoridor.activeSelf && !lightObjectMain.activeSelf && !lightObjectKitchen.activeSelf && !lightObjectBathroom.activeSelf) && fpc.ifInCoridor == false && !Lighting.activeSelf)
        //{
        //    if (wasActivatedEyes == false)
        //   {
        //        Fun = Random.Range(0, 5);
        //        randomizeFun();
        //        if (Fun == 1)
        //        {
        //            ScaryEye.SetActive(true);
        //           Invoke("EyesOff", 2);
         //       }
          //      wasActivatedEyes = true;
           // }
        //}
        //else
        //{
         //   ScaryEye.SetActive(false);
          //  wasActivatedEyes = false;
        //}
        if (Input.GetButtonDown("Fire2") && Holdingbool == true)
        {
            Holdingbool = false;
            HoldingRB.velocity = new Vector3(0, 0, 0);
            HoldingRB.isKinematic = false;
            if (CatFoodGO != null)
            {
                CatFoodHoolding = false;
                CatFoodGO.GetComponent<Collider>().enabled = true;
            }
        }
        if (Input.GetButtonDown("Fire2") && Holdingbool2 == true)
        {
            Holdingbool2 = false;
            HoldingRB2.velocity=new Vector3(0,0,0);
            HoldingRB2.isKinematic = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && HoldingTVRemote == true)
        {
            HoldingTVRemote = false;
            RemoteRB.isKinematic = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && pianoPlaying == false && PcPlayer == false && PhoneMenu == false)
        {
            PhoneTurnOn();
        }
        if (Input.GetButtonDown("Fire2") && holdingPhone == true && PhoneMenu == false)
        {
            Lighting.SetActive(!Lighting.activeSelf);
        }
        else if (holdingPhone == false || PhoneMenu == true)
        {
            Lighting.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q) && holdingPhone == true && PhoneMenu == true)
        {
            PhoneUnCenter();
            Phone.SetTrigger("Center");
        }
        else if (Input.GetKeyDown(KeyCode.Q) && holdingPhone == true && PhoneMenu == false && Holdingbool == false && HoldingTVRemote == false)
        {
            PhoneCenter();
        }

        if ((!lightObjectCoridor.activeSelf && !lightObjectMain.activeSelf && !lightObjectKitchen.activeSelf && !lightObjectBathroom.activeSelf) && fpc.ifInBathroom == true && !Lighting.activeSelf)
        {
            if (WasActiveHor == false)
            {
                Fun = Random.Range(0, 5);
                if (Fun == 1 && playingHor == false)
                {
                    HorHor.Play();
                    Invoke("HorOff", 8f);
                }
                WasActiveHor = true;
            }
        }
        else
        {
            WasActiveHor = false;
            HorHor.Stop();
        }
        if (!lightObjectCoridor.activeSelf && fpc.ifInCoridor == true && RemoteSkript.ChannelNumber == 6)
        {
            if (ifTriedBackrooms == false)
            {
                Fun = Random.Range(0, 10);
                if (Fun == 1)
                {
                    CorridorFloor.SetActive(false);
                }
                ifTriedBackrooms = true;
            }
        }
        else
        {
            ifTriedBackrooms = false;
        }
        if (PlayerGO.transform.position.y < -5)
        {
            PlayerGO.transform.position = new Vector3(-18.82238f, 5.687f, 0.4169817f);
            PlayerGO.transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0, 135, 0);
            backrooms.SetActive(true);
            fpc.playerCanMove = false;
            fpc.cameraCanMove = false;
            canOpenMenu = false;
            Save.EndingBackroomsInt = 1;
            Save.Save();
            Invoke("ToMenu", 33);
        }

        if (PcPlayer == true && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space) && !Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Fire2") && !Input.GetKeyDown(KeyCode.Return))
        {
            randomKey = Random.Range(0, 3);
            if (randomKey == 1)
            {
                Keyboard1.Play();
            }
            else
            {
                Keyboard2.Play();
            }
        }
        else if (PcPlayer == true && Input.GetKeyDown(KeyCode.Space))
        {
            KeyboardSpace.Play();
        }
        else if (PcPlayer == true && Input.GetKeyDown(KeyCode.Return))
        {
            KeyboardEnter.Play();
        }
        else if (PcPlayer == true && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")))
        {
            KeyboardMouse.Play();
        }

        if (Miror.activeSelf)
        {
            RaycastHit look;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out look, 5))
            {
                if (look.collider.name == "Mirror" && Lighting.activeSelf)
                {
                    Closet.SetActive(false);
                }
            }
        }
        if (Holding != null)
        {
            if (Holding.name == "PizzaReall"&&Holdingbool==true)
            {
                HoldingPizza = true;
                Pizzaghost.SetActive(true);
                PizzaGo.GetComponent<Collider>().enabled = false;
            }
            else { HoldingPizza = false; Pizzaghost.SetActive(false); PizzaGo.GetComponent<Collider>().enabled = true; }
        }
        if (questString=="")
        {
            QuestTextGO.SetActive(false);
        }
        else
        {
           QuestTextGO.SetActive(true);
        }
        if (Holdingbool == true && Holdingbool == true)
        {
            if (Holding.name== "CatFood(Clone)")
            {
                CatFoodGO = Holding;
                CatFoodHoolding = true;
                CatFoodGO.GetComponent<Collider>().enabled = false;
            }
            else if (CatFoodGO != null)
            {
                CatFoodHoolding = false;
                CatFoodGO.GetComponent<Collider>().enabled = true;
            }

        }
       

    }
    void HorOff()
    {
        playingHor = false; 
    }
    void EyesOff()
    {
        ScaryEye.SetActive(false);
        wasActivatedEyes = false;
    }

    void ToggleLight1()
    {
        LightmainOn = !LightmainOn;
        lightObjectMain.SetActive(!lightObjectMain.activeSelf);
        light.Play();
        countingLight += 1;
        stopcounting = true;
        if (partyMode == true && !lightObjectMain.activeSelf)
        {
            countingLight = 0;
            partyMode = false;
        }
        Invoke("StopCount", 3);
        if (countingLight >= 5)
        {
            partyMode = true;
        }
    }
    void StopCount()
    {
        if (stopcounting == false)
        {
            countingLight = 0;
            stopcounting = true;
        }
    }
    void ToggleLight2()
    {
        LightCorridorOn = !LightCorridorOn;
        lightObjectCoridor.SetActive(!lightObjectCoridor.activeSelf);
        light.Play();
    }
    void ToggleLight3()
    {
        LightKitchenOn = !LightKitchenOn;
        lightObjectKitchen.SetActive(!lightObjectKitchen.activeSelf);
        light.Play();
    }
    void ToggleLight4()
    {
        LightBathroomOn = !LightBathroomOn;
        lightObjectBathroom.SetActive(!lightObjectBathroom.activeSelf);
        light.Play();
    }
    void OpenBathroom()
    {
        DoorBathroom.SetTrigger("Open");
    }
    void TVOn()
    {
        Tvon = !Tvon;
        TVon.SetActive(!TVon.activeSelf);
        TVoff.SetActive(!TVoff.activeSelf);
    }
    void FridgeOpen()
    {
        FrigdeLeft.SetTrigger("Open");
        FrigdeRight.SetTrigger("Open");
        Invoke("LightsOn", 1);

    }
    void LightsOn()
    {
        if (electricity == true)
        {
            Lights.SetActive(!Lights.activeSelf);
            if (FrigdeWasOppened == false)
            {
                FrigdeWasOppened = true;
                TextOnHungry();
            }
        }

        
    }
    void PcOpen()
    {
        if (holdingPhone == true)
        {
            PhoneTurnOn();
        }
        if (PCScreen.activeSelf)
        {
            if (Holdingbool == true)
            {
                Holdingbool = false;
                HoldingRB.isKinematic = false;
            }
            else if (Holdingbool2 == true)
            {
                Holdingbool2 = false;
                HoldingRB2.isKinematic = false;
            }
            else if (HoldingTVRemote == true)
            {
                HoldingTVRemote = false;
                RemoteRB.isKinematic = false;
            }
            fpc.cutscene = true;
            PcPlayer = true;
        }
    }
    void randomizeFun()
    {
        if (HororMode = false)
        {
            Fun = 0;
        }
    }
    void SheerHeartAttack()
    {
        SheerHeartAttackSound.Play();
    }
    void Hold1()
    {
        HoldingRB = Holding.GetComponent<Rigidbody>();
        Holdingbool = true;
        if (holdingPhone == true)
        {
            PhoneTurnOn();
        }
    }
    void Hold2()
    {
        HoldingRB2 = Holding2.GetComponent<Rigidbody>();
        Holdingbool2 = true;
        
    }
    void HoldTvRemote()
    {
        RemoteRB = Remote.GetComponent<Rigidbody>();
        HoldingTVRemote = true;
        if (holdingPhone == true)
        {
            PhoneTurnOn();
        }
    }
    void PhoneTurnOn()
    {
        if (pianoPlaying == false && PcPlayer == false)
        {
            Phone.SetTrigger("Dostat");
            holdingPhone = !holdingPhone;
        }

    }
    void PianoActivate()
    {
        if (holdingPhone == true)
        {
            PhoneTurnOn();
        }
        Cursor.lockState = CursorLockMode.Locked;
        pianoCode.PianoIsActive = true;
        pianoPlaying = true;
        fpc.Piano = true;
    }
    void ChangeColor()
    {
        if (partyMode == true)
        {
            float r = Random.Range(0.2f, 0.9f);
            float g = Random.Range(0.2f, 0.9f);
            float b = Random.Range(0.2f, 0.9f);
            lightSource.color = new Color(r, g, b);
            if (!TVon.activeSelf)
            {
                if (!music.isPlaying)
                {
                    music.PlayOneShot(music.clip);
                }
            }
        }
        else
        {
            lightSource.color = new Color(1, 1, 1);
            music.Stop();

        }
    }
    void LayOnBed()
    {   
        if (Holdingbool == true)
        {
            Holdingbool = false;
            HoldingRB.isKinematic = false;
        }
    else if (Holdingbool2 == true)
        {
          Holdingbool2 = false; 
          HoldingRB2.isKinematic = false;
        }
    else if(HoldingTVRemote==true)
        {
            HoldingTVRemote = false;
            RemoteRB.isKinematic = false;
        }

        if (holdingPhone == true)
        {
            PhoneTurnOn();
        }

        TimeInGame.TimeStop = true;
            TimeInGame.sleeping = true;
            canOpenMenu = false;
            fpc.playerCanMove = false;
            fpc.cameraCanMove = false;
            Bed.SetActive(true);
            Invoke("ChangeTime", 8f);
            Invoke("ToMenu", 26);
            Save.EndingSleepInt=1;
            Save.Save();
        
    }
    void ChangeTime()
    {
        TimeInGame.Time = 360;
    }
    void ClosetOpen()
    {
        ClosetRight.SetTrigger("Open");
        ClosetLeft.SetTrigger("Open");
    }
    void MoonSwitch()
    {
        nightLightOnBool = !nightLightOnBool;
        nightLightOff.SetActive(!nightLightOff.activeSelf);
        nightLightOn.SetActive(!nightLightOn.activeSelf);
    }
    
    void PCTurnOff()
    {
        PCButton.Play();
        if (PCOn == true)
        {
            for (int i = 0; i < PCApps.Count; i++)

            {
                PCApps[i].SetActive(false);
            }
            PCScreen.SetActive(false);
            PCOn = false;
        }
        else if (PCOn == false)
        {

            if (electricity == true)
            {
                PCScreen.SetActive(true);
                PCOn = true;
            }
        }

    }
    public void Hungry()
    {
        if (eated == false)
        {
            originalPos = gameObject.transform.localPosition;
            NeedsFood = true;

            HungryAudio.Play();

            Invoke("TextOnHungry", 4);

            Invoke("NextGrow", Random.Range(30, 50));
        }
    }
    public void NextGrow()
    {
        if (eated == false)
        {
            ResetText();
            Intensivity = Intensivity * 2f;
            HungryAudio.volume = Intensivity;
            HungryAudio.Play();
            StartCoroutine(ShakeCoroutine());
            Invoke("NextGrow", Random.Range(30, 50));
            TextOnHungry();
        }
    }

    IEnumerator ShakeCoroutine()
    {
        float currentDuration = 2.5f;
        float shakeAmount = Intensivity;

        while (currentDuration > 0)
        {
            Vector3 offset = Random.insideUnitSphere * shakeAmount;
            offset.z = 0;
            gameObject.transform.position = Joint.position;
            gameObject.transform.position += offset;
            currentDuration -= Time.deltaTime;
            shakeAmount = Mathf.Lerp(shakeAmount, 0, Time.deltaTime);
            yield return null;
        }
        gameObject.transform.position = Joint.position;
    }

    void TextOnHungry()
    {
        if (NeedsFood)
        {
            
            if (FrigdeWasOppened == false)
            {
                ResetText();
                questString = "Найдите Еду";
                    TextMaker();
            }
            else
            {
                ResetText();
                questString = "Закажите Пиццу \n достаньте телефон и нажите Q";
                TextMaker();
            }

            
        }
    }
    void PhoneCenter()
    {

        Quaternion currentRotation = transform.rotation;
        gameObject.transform.rotation = Quaternion.Euler(0, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        fpc.playerCanMove = false;
        fpc.cameraCanMove = false;
        PhoneCall.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        cursorGO.gameObject.SetActive(false);
        cursorSelect.SetActive(false);
        Phone.SetTrigger("Center");
        PhoneMenu = true;
    }
    public void PhoneUnCenter()
    {
        fpc.playerCanMove = true;
        fpc.cameraCanMove = true;
        PhoneCall.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        cursorGO.gameObject.SetActive(true);
        PhoneMenu = false;
    }
    //void MenuClose()
    //{
       // Menu.SetActive(false);
      //  Time.timeScale = 1;
        //MenuActive = false;
      //  fpc.playerCanMove = true;
    //    fpc.cameraCanMove = true;
    //    cursorGO.gameObject.SetActive(true);
    //    Cursor.lockState = CursorLockMode.Locked;
    //}
    //void MenuOpen()
    //{
      //  if (canOpenMenu == true)
       // {
        //    fpc.playerCanMove = false;
         //   fpc.cameraCanMove = false;
      //      Menu.SetActive(true);
        //    Time.timeScale = 0;
     //       MenuActive = true;
       //     cursorGO.gameObject.SetActive(false);
         //   cursorSelect.SetActive(false);
          //  Cursor.lockState = CursorLockMode.Confined;
       // }
    //}


    void electricitySwitch()
    {
        light.Play();
        if (electricity == true)
        {
            lightObjectMain.SetActive(false);
            lightObjectCoridor.SetActive(false);
            lightObjectKitchen.SetActive(false);
            lightObjectBathroom.SetActive(false);
            nightLightOff.SetActive(true);
            nightLightOn.SetActive(false);
            TVon.SetActive(false);
            TVoff.SetActive(true);
            if (pianoCode.PianoIsActive == true)
            {
                pianoCode.PianoIsActive = false;
                fpc.cutsceneEnd = true;
                pianoPlaying = false;
            }
            PCScreen.SetActive(false);
            electricity = false;
        }
       else if(electricity == false)
        {
            if (Tvon == true)
            {
                TVon.SetActive(true);
                TVoff.SetActive(false);
            }
            if (LightmainOn == true)
            {
                lightObjectMain.SetActive(true);
            }
            if (LightCorridorOn == true)
            {
                lightObjectCoridor.SetActive(true);
            }
            if (LightKitchenOn == true)
            {
                lightObjectKitchen.SetActive(true);
            }
            if (LightBathroomOn == true)
            {
                lightObjectBathroom.SetActive(true);
            }
            if (PCOn == true)
            {
                PCScreen.SetActive(true);
            }
            if (nightLightOnBool == true)
            {
                nightLightOff.SetActive(false);
                nightLightOn.SetActive(true);
            }

            electricity = true;
        }
    }
    public void electricityOff()
    {
        if (electricity == true)
        {
            light.Play();
            lightObjectMain.SetActive(false);
            lightObjectCoridor.SetActive(false);
            lightObjectKitchen.SetActive(false);
            lightObjectBathroom.SetActive(false);
            nightLightOff.SetActive(true);
            nightLightOn.SetActive(false);
            TVon.SetActive(false);
            TVoff.SetActive(true);
            if (pianoCode.PianoIsActive == true)
            {
                pianoCode.PianoIsActive = false;
                fpc.cutsceneEnd = true;
                pianoPlaying = false;
            }
            PCScreen.SetActive(false);
            electricity = false;
        }
        
    }
    void GetPizza()
    {
        blackScreen.SetTrigger("Back2Black");
        Invoke("TakePizza", 1);
    }
    void TakePizza()
    {
        Holding = PizzaGo;
        Hold1();
        HoldingPizza = true;
        PizzaDelievery.SetActive(false); 
    }
    void TextMaker()
    {
        CancelInvoke("ResetText");
        foreach (char symbol in questString)
        {
            QuestList.Add(symbol);
        }
        StartCoroutine(TextUpdate());
    }
    IEnumerator TextUpdate()
    {
        for (int i = 0; i < QuestList.Count; i++)

        {
           Quest.text=Quest.text+QuestList[i];
            yield return new WaitForSeconds(0.05f);
        }
        Invoke("ResetText", 3 + (QuestList.Count * 0.05f));
    }
    void ResetText()
    {
        QuestList.Clear();
        Quest.text = "";
        questString = "";
    }
   public void Pause()
    {

        if (!MenuGO.activeSelf)
        {
            if (canOpenMenu == true)
            {
                fpc.cameraCanMove = false;
                MenuGO.SetActive(true);
                Time.timeScale = 0;
                cursorGO.gameObject.SetActive(false);
                cursorSelect.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else
        {
            MenuGO.SetActive(false);
            if (PhoneMenu == true)
            {

            }
            else
            {
                fpc.cameraCanMove = true;
                cursorGO.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
            Time.timeScale = 1;
        }
    }
    //public void UnPause()
    //{
      //  MenuGO.SetActive(false);
      //  if (PhoneMenu == true)
      //  {

      //  }
     //   else
     //   {
//fpc.cameraCanMove = true;
  //          cursorGO.gameObject.SetActive(true);
    //        Cursor.lockState = CursorLockMode.Locked;
      //  }
        //Time.timeScale = 1;
    //}
    void Eated()
    {
        PizzaEmpty.SetActive(true);
        Pizzaghost.SetActive(false);
        EatSound.Play();
        PizzaGo.SetActive(false);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}