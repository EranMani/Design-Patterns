﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim);
}

public class PerformJump : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isJumping");
    }
}

public class PerformPunchAttack : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isPunching");
    }
}

public class PerformKickAttack : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("isKicking");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {
        
    }
}
