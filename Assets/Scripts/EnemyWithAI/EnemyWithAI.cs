using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyWithAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform patrolPointsParent;
    [SerializeField] int initialLife = 3;
    [SerializeField] float reachDistance = 2f;
    [SerializeField] float waitingTime = 3f;
    [SerializeField] float timeBetweenCoins = 2f;

    [SerializeField] GameObject coin;

    [SerializeField] float timeBetweenHits = 3f;

    [SerializeField] Slider lifeSlider;

    [SerializeField] Canvas winCanvas;

    NavMeshAgent agent;
    EnemySight sight;
    
    private bool hasMadeDamage = false;
    enum State
    {
        Patrol,
        Following,
        Death,
        Waiting,
    }

    int currenPatrolPoint = 0;
    int currentLife;
    State currentState;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sight = GetComponent<EnemySight>();

        currentLife = initialLife;

        lifeSlider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        transform.LookAt(camera.transform.position);

        UpdateSenses();

        UpdateDecissionMaking();

        UpdateState();
    }

    void UpdateSenses()
    {
         target=sight.GetPlayerInSight();
    }

    void UpdateDecissionMaking()
    {
        
        if (currentLife <= 0f)
        {
            SetState(State.Death);
        }
        else if (hasMadeDamage)
        {
            SetState(State.Waiting);
        }
        else if (target!=null)
        {
            SetState(State.Following);          
        }       
        else
        {
            SetState(State.Patrol);            
        }
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case State.Patrol:
                UpdatePatrol();
                break;
            case State.Following:
                UpdateFollowingState();
                break;
            case State.Death:
                UpdateDeath();
                break;
            case State.Waiting:
                UpdateWaiting();
                break;
        }
    }


    void SetState(State newstate)
    {
        //revisamos si el nuevo estado es igual al actual y asi no tener que hacer nada
        //si es diferente pues si que empezamos a revisar y actualizar el estado
        if (currentState == newstate) 
        {
            return;
        }
        switch(currentState)
        {
            case State.Patrol:
                ExitPatrolState();
                break;
            case State.Following:
                ExitFollowingState();
                break;
            case State.Death:
                ExitDeathState();
                break;
            case State.Waiting:
                ExitWaitingState();
                break;

        }
        currentState=newstate;

        switch(currentState)
        {
            case State.Patrol:
                EnterPatrolState();
                break;
            case State.Following:
                EnterFollowingState();
                break;
            case State.Death:
                EnterDeathState();
                break;
            case State.Waiting:
                EnterWaitingState();
                break;

        }

    }

    #region Patrol
    //GESTION ESTADO PATRULLA
    void EnterPatrolState()
    {
        //no necesario 
    }

    float lastTimeCoin = 0f;
    void UpdatePatrol()
    {
        lastTimeCoin += Time.deltaTime;

        Vector3 nextPosition = patrolPointsParent.GetChild(currenPatrolPoint).position;
            agent.SetDestination(nextPosition);
            if (Vector3.Distance(nextPosition,transform.position) < reachDistance)
            {
                currenPatrolPoint++;
                if (currenPatrolPoint >= patrolPointsParent.childCount)
                {
                    currenPatrolPoint = 0;
                }
            }

        if (lastTimeCoin > timeBetweenCoins)
        {
            lastTimeCoin = 0;

            Instantiate(coin, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity);

        }
    }

    void ExitPatrolState()
    {
        agent.SetDestination(transform.position);
    }
    #endregion

    #region Following
    //GESTION ESTADO SEGUIMIENTO
    void EnterFollowingState()
    {        
        
    }

    void UpdateFollowingState()
    {
        agent.SetDestination(target.position);
    }

    void ExitFollowingState()
    {
        agent.SetDestination(transform.position);
    }
    #endregion

    #region Death
    //GESTION ESTADO MUERTE
    void EnterDeathState()
    {
       // score.UpdateScore(100);
       winCanvas.gameObject.SetActive(true);
    }
    void UpdateDeath()
    {

        Destroy(gameObject, 2f); 
    }
    
    void ExitDeathState()
    {
        
    }
    #endregion

    #region Waiting
    //GESTION ESTADO ESPERANDO
    float lastTimeDamage = 0;

    void EnterWaitingState()
    {
        agent.SetDestination(transform.position);
    }

    void UpdateWaiting()
    {
        if (Time.time - lastTimeDamage > waitingTime)
        {
            hasMadeDamage = false;
        }

    }
    void ExitWaitingState()
    {
        // no aplica
        //creamos el método para tenerlo por si hicera falta.
    }
    #endregion

    float timeWhenHit = 0;
    public void ReceiveHit()
    {
        // Only receive a hit each timeBetweenHits seconds
        if (Time.time - timeWhenHit > timeBetweenHits){
            timeWhenHit = Time.time;
            
            currentLife--;

            float sliderValue = (float)currentLife / (float)initialLife;
            Debug.Log($"Enemy Receive Hit {sliderValue}");
            lifeSlider.value = sliderValue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastTimeDamage = Time.time;
            hasMadeDamage = true;

            Debug.Log("Player Damage");
        }
    }
}
