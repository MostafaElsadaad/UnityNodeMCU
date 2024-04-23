using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Databasemanager : MonoBehaviour {
    public Vector3 offset = new Vector3(0, 0f, 0);
    public float smoothSpeed = 0.125f;
    public Vector3 cameracon = new Vector3();
    private Vector3 Cam_velocity = Vector3.zero;
    /*    public InputField Name;
        public InputField Data;
    */
    // public Text nameText;
    // public Text DataText;
    public Text temperature;
    public Text temperaturemin;
    public Text temperaturemax;
    public Text temperatureaverage;
    public Text humidity;
    public Text humiditymin;
    public Text humiditymax;
    public Text humidityaverage;
    public Text waterL;
    public Text waterLmin;
    public Text waterLmax;
    public Text waterLaverage;
    public Text temperatureM;
    public Text humidityM;
    public Text waterLM;
    public float temp;
    private float tempmin = 9999;
    private float tempmax = -9999;
    public float tempavg;
    public int humi;
    public int humimin = 9999;
    public int humimax = -9999;
    public int humiavg;
    public float water;
    public float watermin = 9999;
    public float wateravg;
    public float watermax = -9999;
    private List<float> _temp = new List<float>();
    private List<int> _humi = new List<int>();
    private List<float> _water = new List<float>();
    bool sett = false;
    float lasttime = 0f;
    int Tindex = 0;
    private string userID;
    private DatabaseReference dbReference;
    public bool tempbut = false;
    public bool humibut = false;
    public bool waterbut = false;
    public bool mainbut = false;
    public Button mainButt;
    public Button humiButt;
    public Button tempButt;
    public Button waterButt;
    void Start() {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }


    private void FixedUpdate() {
        GetUserInfo();
        if (sett == false) {
            tempmin = 9999;
            tempmax = temp;
            tempavg = temp;
            humimin = 9999;
            humimax = humi;
            humiavg = humi;
            watermin = 9999;
            watermax = water;
            wateravg = water;
            sett = true;
        }


        float t1 = Time.time;
        if (lasttime + 3f < t1) {
            lasttime = t1;

            _temp.Add(temp);
            _humi.Add(humi);
            _water.Add(water);
            if (_temp.Count > 20) {
                _temp.RemoveAt(0);
            }
            if (_humi.Count > 20) {
                _humi.RemoveAt(0);
            }
            if (_water.Count > 20) {
                _water.RemoveAt(0);
            }
        }


        float average = _temp.Average();
        int average2 = (int)_humi.Average();
        float average3 = _water.Average();
        if (tempmax < _temp.Max()) {
            tempmax = _temp.Max();
        }
        if (tempmin > _temp.Min()) {
            tempmin = _temp.Min();
        }

        if (humimax < _humi.Max()) {
            humimax = _humi.Max();
        }
        if (humimin > _humi.Min()) {
            humimin = _humi.Min();
        }

        if (watermax < _water.Max()) {
            watermax = _water.Max();
        }
        if (watermin > _water.Min()) {
            watermin = _water.Min();
        }


        tempavg = average;
        temperature.text = "Current \n Temperature \n " + temp.ToString() + " C";
        temperatureM.text = "Temperature \n " + temp.ToString() + " C";
        temperaturemin.text = "Min \n " + tempmin.ToString() + " C";
        temperaturemax.text = "Max \n " + tempmax.ToString() + " C";
        temperatureaverage.text = "Average \n " + tempavg.ToString() + " C";

        humiavg = average2;
        humidity.text = "Current \n Humidity \n " + humi.ToString() + "%";
        humidityM.text = "Humidity \n " + humi.ToString() + "%";
        humiditymin.text = "Min \n " + humimin.ToString() + "%";
        humiditymax.text = "Max \n " + humimax.ToString() + "%";
        humidityaverage.text = "Average \n " + humiavg.ToString() + "%";

        wateravg = average3;
        waterL.text = "Current \n Water Level \n " + water.ToString() + " cm";
        waterLM.text = "Water Level \n " + water.ToString() + " cm";
        waterLmin.text = "Min \n " + watermin.ToString() + " cm";
        waterLmax.text = "Max \n " + watermax.ToString() + " cm";
        waterLaverage.text = "Average \n " + wateravg.ToString() + " cm";

        /*        string result = "List contents: ";
                foreach (var item in _temp) {
                    result += item.ToString() + ", ";
                }

                Debug.Log(result);
                Debug.Log("count = " + _temp.Count);
                Debug.Log("current index = " + Tindex);
                Debug.Log("AVG = " + average);*/
    }



    /*    public void CreateUser() {
            User newUser = new User(Name.text, int.Parse(Data.text));
            string json = JsonUtility.ToJson(newUser);

            dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
        }*/

    public IEnumerator GetName(Action<string> onCallback) {
        //var userNameData = dbReference.Child("users").Child(userID).Child("name").GetValueAsync();
        var userNameData = dbReference.Child("message").GetValueAsync();
        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null) {
            DataSnapshot snapshot = userNameData.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
    public IEnumerator GetData(Action<int> onCallback) {
        //var userdataData = dbReference.Child("users").Child(userID).Child("data").GetValueAsync();
        var userdataData = dbReference.Child("humi").GetValueAsync();
        yield return new WaitUntil(predicate: () => userdataData.IsCompleted);

        if (userdataData != null) {
            DataSnapshot snapshot = userdataData.Result;

            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }

    public IEnumerator GetData1(Action<float> onCallback) {
        //var userdataData = dbReference.Child("users").Child(userID).Child("data").GetValueAsync();
        var userdataData1 = dbReference.Child("temp").GetValueAsync();
        yield return new WaitUntil(predicate: () => userdataData1.IsCompleted);

        if (userdataData1 != null) {
            DataSnapshot snapshot = userdataData1.Result;

            onCallback.Invoke(float.Parse(snapshot.Value.ToString()));
        }
    }

    public IEnumerator GetData2(Action<float> onCallback) {
        //var userdataData = dbReference.Child("users").Child(userID).Child("data").GetValueAsync();
        var userdataData2 = dbReference.Child("water").GetValueAsync();
        yield return new WaitUntil(predicate: () => userdataData2.IsCompleted);

        if (userdataData2 != null) {
            DataSnapshot snapshot = userdataData2.Result;

            onCallback.Invoke(float.Parse(snapshot.Value.ToString()));
        }
    }

    public void GetUserInfo() {
        /*        StartCoroutine(GetName((string namee) => {
                    nameText.text = "Name: " + namee;

                }));*/

        StartCoroutine(GetData((int dataa) => {
            // DataText.text = "humidity: " + dataa.ToString() + "%";
            humi = dataa;
        }));
        StartCoroutine(GetData1((float dataa) => {
            // temperature.text = "Temperature: " + dataa.ToString() + " C";
            temp = dataa;
        }));
        StartCoroutine(GetData2((float dataa) => {
            // water.text = "Water Level: " + dataa.ToString() + " cm";
            water = dataa;
        }));
    }


    public void LateUpdate() {
        if (tempbut) {
            
            StartCoroutine(movetopos(new Vector3(-2.47f, 1.07f, -35.31f),new Vector3(-5.054f, 13.73f, 0)));
        }

        if (humibut) {
            StartCoroutine(movetopos(new Vector3(-26.66f, 2.9f, -11.28f), new Vector3(-5.054f, -16.7f, 0)));
        }

        if (waterbut) {
            StartCoroutine(movetopos(new Vector3(-9.059f, 3.87f, -24.89f), new Vector3(7.5f, 49.97f, 0)));
        }

        if(mainbut) {
            StartCoroutine(movetopos(new Vector3(-1.184f, 2.80871f, -24.869f), new Vector3(0, 65f, 0)));
        }

    }
    public void movecameratotemp() {
        if(tempbut == true) { return; }
        if (humibut == true) { return; }
        if (waterbut == true) { return; }
        if (mainbut == true) { return; }
        tempbut = true;
    }
    public void movecameratohumi() {
        if (tempbut == true) { return; }
        if (humibut == true) { return; }
        if (waterbut == true) { return; }
        if (mainbut == true) { return; }
        humibut = true;
    } 
    public void movecameratowater() {
        if (tempbut == true) { return; }
        if (humibut == true) { return; }
        if (waterbut == true) { return; }
        if (mainbut == true) { return; }
        waterbut = true;
    }

    public void movecameratomain() {
        if (tempbut == true) { return; }
        if (humibut == true) { return; }
        if (waterbut == true) { return; }
        if (mainbut == true) { return; }
        mainbut = true;
    }
    /*    private void movetopos(Vector3 DesiredPos) {
            Vector3 SmoothedPos = Vector3.SmoothDamp(Camera.main.transform.position, DesiredPos, ref Cam_velocity, 1f);
            Camera.main.transform.position = SmoothedPos;
        }*/

    IEnumerator movetopos(Vector3 DesiredPos,Vector3 desiredrot) {
        mainButt.enabled = false;
        humiButt.enabled = false;
        tempButt.enabled = false;
        waterButt.enabled = false;
        Vector3 SmoothedPos = Vector3.SmoothDamp(Camera.main.transform.position, DesiredPos, ref Cam_velocity, 1f);
        Camera.main.transform.position = SmoothedPos;

        //Camera.main.transform.rotation = Quaternion.Euler(desiredrot);
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, Quaternion.Euler(desiredrot), 30f * Time.deltaTime);
        bool finishedmovement = ((Camera.main.transform.position - DesiredPos).magnitude < (new Vector3(0.005f,0.005f,0.005f).magnitude));
        Debug.Log("hh = " + finishedmovement);
        yield return new WaitUntil(() => finishedmovement == true);
        Debug.Log("h2 = " + finishedmovement);
        tempbut = false;
        humibut = false;
        waterbut = false;
        mainbut = false;
        mainButt.enabled = true;
        humiButt.enabled = true;
        tempButt.enabled = true;
        waterButt.enabled = true;
    }



    /*    public void UpdateName() {
            dbReference.Child("users").Child(userID).Child("name").SetValueAsync(Name.text);

        }

        public void UpdateData() {
            dbReference.Child("users").Child(userID).Child("data").SetValueAsync(Data.text);

        }*/

}
