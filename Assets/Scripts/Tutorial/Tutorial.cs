using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TutorialStep
{
   public ObjectInteractionBasement _target;
    public ITutorialScenario Scenario;

    public Tutorial GetTutorial { get { return GameLogic.instance._Tutorial; } }
}

public interface ITutorialScenario
{
    IEnumerator Do(TutorialStep _sender);
    void Interact();
}

public class Tutorial : ObjectInteractionBasement
{
    private const string _tutKey = "_tut";

    public Transform Helper;

    public TutorialStep[] _steps = {
        new TutorialStep() { Scenario = new _Tutorial_Scenario_Fish() },
        new TutorialStep() { Scenario = new _Tutorial_Scenario_Enemy() }
    };
    private int _currentStep = 0;


    public override void Init()
    {
        base.Init();
        if (GameLogic.instance._Level._Settings._levelNumber == 1)
        {
            //Init tutorial
            Interact();
            Helper.gameObject.SetActive(true);
        }
    }

    //tutorial steps
    public override void Interact()
    {
        base.Interact();

        if(_currentStep >= _steps.Length)
        {
            //Stop tutorial
            StopTutorial();
        }
        else
        {

        //main here
        StartCoroutine(_steps[_currentStep].Scenario.Do(_steps[_currentStep]));

        _currentStep++;

        }
    }


    public IEnumerator CutAnimation(Transform _target)
    {

        float _time = 0;
        Helper.position = new Vector2(_target.position.x - 3, _target.position.y);
        while (_time < 1)
        {
            if (_target != null)

                Helper.position = new Vector2(Mathf.Lerp(Helper.transform.position.x, _target.position.x + 3, _time), _target.position.y);

            _time += Time.unscaledDeltaTime;
            yield return null;
        }
    }

    public void StopTutorial()
    {

    }

}
public class _Tutorial_Scenario_Fish : ITutorialScenario
{
    public int _step = 0;

    public IEnumerator Do(TutorialStep _sender)
    {
        _sender._target.OnInteractHandler += Interact;

        GameLogic.instance._spawner.DeActivate();

        while (_step <= 5)
        {
            var cutAnim = _sender.GetTutorial.StartCoroutine(_sender.GetTutorial.CutAnimation(_sender._target.transform));
            yield return cutAnim;
        }

        Debug.Log("test");
        GameLogic.instance._object.DeActivate();

        _sender._target.OnInteractHandler -= Interact;
        _sender.GetTutorial.Interact();
    }

    public void Interact()
    {
        _step++;
        Debug.Log("HANDLER");
    }
}

public class _Tutorial_Scenario_Enemy : ITutorialScenario
{
    public int _step = 0;

    public IEnumerator Do(TutorialStep _sender)
    {
        //start spawning

       
        GameLogic.instance._spawner.Interact();
        _sender._target = GameLogic.instance._spawner.GetCurrentEnemy();


        _sender._target.OnInteractHandler += Interact;
        while (Vector2.Distance(_sender._target.transform.position, _sender.GetTutorial._steps[0]._target.transform.position) > 3)
        {
            yield return null;
        }
            _sender._target.StopAllCoroutines();


        while(_step == 0)
        {
            var cutAnim = _sender.GetTutorial.StartCoroutine(_sender.GetTutorial.CutAnimation(_sender._target.transform));
            yield return cutAnim;
        }

        GameLogic.instance._object.Init();
        _sender._target.OnInteractHandler -= Interact;

    }

    public void Interact()
    {
        _step++;
    }
}
