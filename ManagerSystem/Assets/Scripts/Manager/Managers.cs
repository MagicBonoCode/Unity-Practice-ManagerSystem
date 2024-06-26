using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private static Managers Instance
    {
        get
        {
            Init();
            return s_instance;
        }
    }

    private DataManager _data = new DataManager();
    private EventManager _event = new EventManager();
    private ObjectManager _object = new ObjectManager();
    private PoolManager _pool = new PoolManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private UIManager _ui = new UIManager();

    public static DataManager Data { get { return Instance._data; } }
    public static EventManager Event { get { return Instance._event; } }
    public static ObjectManager Object { get { return Instance._object; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static UIManager UI { get { return Instance._ui; } }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject gameObject = GameObject.Find("_Managers");
            if (gameObject == null)
            {
                gameObject = new GameObject { name = "_Managers" };
                gameObject.AddComponent<Managers>();
            }

            DontDestroyOnLoad(gameObject);
            s_instance = gameObject.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._event.Init();
        }
    }

    public static void Clear()
    {
        Event.Clear();
        Pool.Clear();
        Object.Clear();
        UI.Clear();
    }
}
