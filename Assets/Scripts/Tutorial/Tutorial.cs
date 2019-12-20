using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TutorialScenarious;

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
    public SpriteRenderer _bg_rend;



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

    public IEnumerator FocusBG()
    {
        float _time = 0;
        float _elapsedTime = 1;

        _bg_rend.color = new Color(0, 0, 0, 0);
        _bg_rend.gameObject.SetActive(true);

        while(_time < _elapsedTime)
        {
            _bg_rend.color = Color.Lerp(_bg_rend.color, new Color(0,0,0,0.6f), _time / _elapsedTime);

            _time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator UnfocusBG()
    {
        float _time = 0;
        float _elapsedTime = 1;

        _bg_rend.color = new Color(0, 0, 0, 0.6f);
        while (_time < _elapsedTime)
        {
            _bg_rend.color = Color.Lerp(_bg_rend.color, new Color(0, 0, 0, 0), _time / _elapsedTime);

            _time += Time.deltaTime;
            yield return null;
        }

        _bg_rend.gameObject.SetActive(false);

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

namespace TutorialScenarious
{

    public class _Tutorial_Scenario_Fish : ITutorialScenario
    {
        public int _step = 0;

        public IEnumerator Do(TutorialStep _sender)
        {
            _sender._target.OnInteractHandler += Interact;

            GameLogic.instance._object.DeActivate();
            GameLogic.instance._spawner.DeActivate();

            var bg = _sender.GetTutorial.StartCoroutine(_sender.GetTutorial.FocusBG());
            yield return bg;

            GameLogic.instance._object.Init();

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

            GameLogic.instance._spawner.Init();
            GameLogic.instance._spawner.Interact();
            GameLogic.instance._spawner.DeActivate();
            _sender._target = GameLogic.instance._spawner.GetCurrentEnemy();


            _sender._target.OnInteractHandler += Interact;
            while (Vector2.Distance(_sender._target.transform.position, _sender.GetTutorial._steps[0]._target.transform.position) > 3)
            {
                yield return null;
            }
            _sender._target.StopAllCoroutines();


            while (_step == 0)
            {
                var cutAnim = _sender.GetTutorial.StartCoroutine(_sender.GetTutorial.CutAnimation(_sender._target.transform));
                yield return cutAnim;
            }

            var bg = _sender.GetTutorial.StartCoroutine(_sender.GetTutorial.UnfocusBG());
            yield return bg;

            GameLogic.instance._object.Init();
            _sender._target.OnInteractHandler -= Interact;

        }

        public void Interact()
        {
            _step++;
        }
    }
}
