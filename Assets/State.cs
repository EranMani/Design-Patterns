using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class State
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP, RUNAWAY
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    // Detect player in distance and angle
    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        player = _player;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    // Progress the state through each of the different stages
    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        // Get direction vector from player to npc position
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);

        // Figure out if player is within NPC line of sight
        // Find the angle between the direction and the forward vector which will be half of its total visibility
        // -- To get 60 degrees field of view for the NPC then we give it a visAngle of half of that, which is 30
        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < shootDist)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind()
    {
        Vector3 direction = npc.transform.position - player.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < 2 && angle < 30)
        {
            return true;
        }
        return false;
    }
}

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player):
        base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        else if (Random.Range(0, 100) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) :
        base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        // Find the nearest waypoint to the NPC and assign it as next waypoint to go
        // Init value with highest possible
        float lastDist = Mathf.Infinity;
        for (int i = 0; i < GameEnvironment.Singleton.CheckPoints.Count; i++)
        {
            GameObject thisWP = GameEnvironment.Singleton.CheckPoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            // Run on all waypoints, compare distances and update accordingly
            if (distance < lastDist)
            {
                // Update current index as the nearest waypoint to the NPC
                // i-1 happens becuase in update it always increment the current index
                currentIndex = i-1;
                lastDist = distance;
            }
        }

        anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        // Count all waypoints and move agent one after the other
        if (agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironment.Singleton.CheckPoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            agent.SetDestination(GameEnvironment.Singleton.CheckPoints[currentIndex].transform.position);
        }

        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        else if (IsPlayerBehind())
        {
            nextState = new RunAway(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}

public class Pursue : State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) :
        base(_npc, _agent, _anim, _player)
    {
        name = STATE.PURSUE;
        agent.speed = 5;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.position);
        // When NPC is following the player
        // Although setting destination, this might take time to update
        // To continue, we need to check first if the agent done calculating its path
        if (agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                nextState = new Patrol(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        base.Exit();
    }
}

public class Attack : State
{
    float rotationSpeed = 2.0f;
    AudioSource shoot;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) :
        base(_npc, _agent, _anim, _player)
    {
        name = STATE.ATTACK;
        shoot = _npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        anim.SetTrigger("isShooting");
        agent.isStopped = true;
        shoot.Play();
        base.Enter();
    }

    public override void Update()
    {
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.position);
        // Rotate the character around but avoid tilt in the X or the Z axis
        // Rotate NPC on the spot which is around its UP vector
        direction.y = 0;

        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                Quaternion.LookRotation(direction),
                                Time.deltaTime * rotationSpeed);

        if (!CanAttackPlayer())
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isShooting");
        shoot.Stop();
        base.Exit();
    }
}

public class RunAway : State
{
    GameObject safeLocation;
    public RunAway(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) :
        base(_npc, _agent, _anim, _player)
    {
        name = STATE.RUNAWAY;
        safeLocation = GameObject.FindGameObjectWithTag("Safe");
    }

    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        // Create a path of the NPC agent
        agent.isStopped = false;
        agent.speed = 6;
        agent.SetDestination(safeLocation.transform.position);
        base.Enter();
    }

    public override void Update()
    {
        if (agent.remainingDistance < 1)
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
