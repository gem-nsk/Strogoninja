using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Knife _knife;
    public Spawner _spawner;
    public ObjectRotation _object;
    public Person _Person;
    public InputManager _Input;
    public ObjectInteractionBasement _Bg;
    public Score _Score;
    public MusicController _Music;
    public GameCanvas _canvas;
    public Level _Level;
    public Tutorial _Tutorial;
    public SkinController _Skins;

    public GameState _state;

    public GameState_FirstMenu _GameState_FirstMenu;
    public GameState_Menu _GameState_Menu;
    public GameState_InGame _GameState_InGame;
    public GameState_DeathScreen _GameState_DeathScreen;

    public static GameLogic instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //GameInitiation
    public void Start()
    {
        _GameState_DeathScreen = new GameState_DeathScreen(this);
        _GameState_FirstMenu = new GameState_FirstMenu(this);
        _GameState_InGame = new GameState_InGame(this);
        _GameState_Menu = new GameState_Menu(this);

        _state = _GameState_FirstMenu;
        _state.Activate();

        _Score.Init();
    }

    public void SwitchState(GameState state)
    {
        _state.Deactivate();
        _state = state;
        _state.Activate();
    }

    public void Loose()
    {
        SwitchState(_GameState_DeathScreen);
        _Score.ResetTotalScore();
    }

    public void Restart()
    {
        _state.Restart();
    }

    public void CheckScore(int score)
    {
        if(score >= _Level._Settings._TargetPoints)
        {
            Win();
        }
    }

    void Win()
    {
        _Level.Setlevel(_Level._Settings._levelNumber + 1);
        SwitchState(_GameState_Menu);
        _canvas.WinScreen();
        _spawner.DeActivate();
        _spawner.DeleteEnemy();
        Debug.Log("Win");

    }

    public void Nextlevel()
    {
        SwitchState(_GameState_InGame);
    }

    public IEnumerator MoveObjectToPos(Transform obj, Vector2 pos, float ElapsedTime)
    {
        float _time = 0;
        while (_time < ElapsedTime)
        {
            obj.position = Vector2.Lerp(obj.position, pos, _time / ElapsedTime);
            _time += Time.deltaTime;
            yield return null;
        }
    }
}

public class GameState
{
    protected GameLogic _GameLogic;

    public GameState(GameLogic gameLogic)
    {
        _GameLogic = gameLogic;
    }

    public virtual void Activate() { }
    public virtual void Deactivate() { }
    public virtual void Share() { }
    public virtual void Restart() { }
}

public class GameState_FirstMenu : GameState
{
    public GameState_FirstMenu(GameLogic gameLogic) : base(gameLogic) { }

    public IEnumerator Init()
    {
       // _GameLogic._object.Init();



        yield return null;
    }

    public override void Activate()
    {
        Debug.Log("First menu inited");

        _GameLogic.StartCoroutine(Init());

        _GameLogic._Person.gameObject.SetActive(true);
        _GameLogic._Person.transform.position = new Vector2(0, -2.5f);

        _GameLogic._object.transform.position =  new Vector3(-0.15f, -2.88f);
        _GameLogic._object.transform.rotation = Quaternion.Euler(0, 0, 0);

        _GameLogic._canvas.Init();
        _GameLogic._Bg.transform.position = new Vector2(0, 5);

        _GameLogic._Input.Tap.AddListener(WaitForTouch);
        _GameLogic._Level.Init();

        _GameLogic._Skins.Init();
    }

    void WaitForTouch()
    {
        _GameLogic._Person.Interact();
        _GameLogic._canvas._isOn = false;
        _GameLogic.StartCoroutine(Animate());

        Debug.Log("Touched");
        _GameLogic._Input.Tap.RemoveListener(WaitForTouch);
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(0.1f);

        _GameLogic._object.Init();

        var PersonAnim = _GameLogic.StartCoroutine(_GameLogic.MoveObjectToPos(_GameLogic._Person.transform, new Vector2(0, -10), 2));
        var objAnim = _GameLogic.StartCoroutine(_GameLogic.MoveObjectToPos(_GameLogic._object.transform, Vector2.zero, 1));
        var bgAnim = _GameLogic.StartCoroutine(_GameLogic.MoveObjectToPos(_GameLogic._Bg.transform, Vector2.zero, 2));


        yield return objAnim;

        _GameLogic.SwitchState(_GameLogic._GameState_InGame);
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}

public class GameState_Menu : GameState
{
    public GameState_Menu(GameLogic gameLogic) : base(gameLogic) { }

    public IEnumerator Init()
    {
        
        yield return null;
    }

    public override void Activate()
    {
        Debug.Log("Menu Inited");

        //CoroutineManager.instance.InitCoroutine(_logic._state._State.Init(FirstStart));
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}

public class GameState_InGame : GameState
{
    public GameState_InGame(GameLogic gameLogic) : base(gameLogic) { }

    public override void Activate()
    {
        _GameLogic._object.transform.position = new Vector3(0,0);
        _GameLogic._Bg.transform.position = new Vector3(0, 0);
        _GameLogic._Person.transform.position = new Vector3(0, -10);

        //_GameLogic._object.Init();
        _GameLogic._canvas.InGame();
        _GameLogic._Score.ResetScore();
        _GameLogic._object.Init();
        _GameLogic._knife.Init();
        _GameLogic._spawner.Init();
        _GameLogic._Music.PlayGameMusic();

        _GameLogic._Tutorial.Init();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _GameLogic._spawner.DeActivate();
        _GameLogic._object.DeActivate();
        _GameLogic._Person.DeActivate();
        _GameLogic._knife.DeActivate();
    }
}

public class GameState_DeathScreen : GameState
{
    public GameState_DeathScreen(GameLogic gameLogic) : base(gameLogic) { }

    public override void Activate()
    {
        base.Activate();

        _GameLogic._Score.Interact();

        _GameLogic.StartCoroutine(Animate());
        Debug.Log("Deathscreen");
    }

    IEnumerator Animate()
    {
        var PersonAnim = _GameLogic.StartCoroutine(_GameLogic.MoveObjectToPos(_GameLogic._Person.transform, new Vector2(0, -10), 2));
        var bgAnim = _GameLogic.StartCoroutine(_GameLogic.MoveObjectToPos(_GameLogic._Bg.transform, new Vector3(0, -5), 1));

        _GameLogic._Music.StopGameMusic();
        _GameLogic._Music.PlayDeathClip();

        yield return new WaitForSeconds(0.6f);

        _GameLogic._canvas.DeathScreen();
    }


    public override void Deactivate()
    {
        _GameLogic.StopCoroutine(Animate());
        base.Deactivate();
    }

    public override void Restart()
    {
        base.Restart();
        _GameLogic.SwitchState(_GameLogic._GameState_InGame);
    }
}
