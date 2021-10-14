using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FillingGround.SpellSystem.Interface
{
    public interface IGlobalCooldown
    {
        public abstract IEnumerator GlobalCooldown();
    }
}