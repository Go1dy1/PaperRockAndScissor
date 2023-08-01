using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using StateUnit = Storage.StateUnit;

public class Card : MonoBehaviour
{
[SerializeField] private StateUnit _currentState;
[SerializeField] private Transform _pos;
[SerializeField] private ParticleSystem _puff;
[SerializeField] private AudioSource _death;
[SerializeField] protected Transform _tower;
[SerializeField] protected float _healPoint;
[SerializeField] protected float _Damage;
[SerializeField] protected float _ModifyDamage;
protected NavMeshAgent Agent;
public float _broadcastHealPoint ;
protected const int ZeroHp = 0;
private bool _direction = false;


    private void Awake()
    { 
        _broadcastHealPoint = _healPoint;
        _currentState = StateUnit.Ide;
        Agent = GetComponent <NavMeshAgent>();    

    }

    public void Start()
    {
        gameObject.GetComponent<Card>();
    }

    private Vector3 GetMousePosition()
    {

        var mainCamera= Camera.main;
        if (mainCamera != null)
        {
            var ray =mainCamera.ScreenPointToRay (Input.mousePosition);
            var plane = new Plane(Vector3.up, new Vector3 (0,0.5f,0));
            plane.Raycast(ray, out float enter);
            
            return ray.GetPoint(enter);
        }

        return default;
    }

    protected void WalkToTowerPosition(NavMeshAgent agent, Transform tower)
    {
        if (Input.GetMouseButton(0)&& !_direction && gameObject != null)
        {
        print("WalkToTowerPosition TRUE");
            _currentState = StateUnit.WalkToCastle;
            if (PosCollider.AccsesPoint == true && gameObject != null)
            {
                print("PosCollider.AccsesPoint == TRUE");
                _direction = true;
                transform.DOMove(GetMousePosition(), 1);
            }
        }

        if (_direction && _currentState == StateUnit.WalkToCastle)
        {
            agent.SetDestination(tower.position);
        }
    }
   
    protected void SpawnEffect()
    {
        var cardPosition = gameObject.transform.position;
        Instantiate(_puff,cardPosition,Quaternion.identity);
        Instantiate(_death,cardPosition,Quaternion.identity);

    }
    protected void ComeBack()
    {

        if(gameObject!=null)transform.DOMove(_pos.position,0.2f,false);
        NavmeshStart();

    }
    async void NavmeshStart()
    {
        await Task.Delay(200);
       if(Agent!=null) Agent.isStopped = false;

    }
}





