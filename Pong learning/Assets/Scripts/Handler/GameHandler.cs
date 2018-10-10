using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    private KeyInputManager _input;
    private GameObjectHandler _goHandler;
    public GameObject ballPref;

    public void SpawnBall()
    {
        //refreshing object reference
        Destroy(GameObject.FindGameObjectWithTag("Ball"));
        GameObjectHandler objhandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameObjectHandler>();
        objhandler.RemoveObject("Ball");
        objhandler.InsertObject(GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>().ballPref,"Ball");
        Instantiate<GameObject>(objhandler.ReceiveObject("Ball"), new Vector3(0, 0, 0), Quaternion.identity);        
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().OnDeath += GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>().SpawnBall;
    }

    public void MoveTheBall()
    {
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().canMove = true;
    }

    void Start () {
        _input = GameObject.FindGameObjectWithTag("Input").GetComponent<KeyInputManager>();
       
        _goHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameObjectHandler>();
        _goHandler.InsertObject(GameObject.FindGameObjectWithTag("Player"), "Player");
        _goHandler.InsertObject(GameObject.FindGameObjectWithTag("Cpu"), "Cpu");

        _goHandler.InsertObject(ballPref, "Ball");
        Instantiate<GameObject>(_goHandler.ReceiveObject("Ball"), new Vector3(0, 0, 0), Quaternion.identity);


        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().OnDeath += SpawnBall;
        
        _input.AddDelicate(MoveTheBall, "Start", KeyInputManager.keyInputType.OnHold);
        _input.AddDelicate(_goHandler.ReceiveObject("Player").GetComponent<PongBar>().MoveUp, "Up", KeyInputManager.keyInputType.OnHold);
        _input.AddDelicate(_goHandler.ReceiveObject("Player").GetComponent<PongBar>().MoveDown, "Down", KeyInputManager.keyInputType.OnHold);
    }
	
	void Update () {
		
	}
}
