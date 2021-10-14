namespace FillingGround.SpellSystem.Interface
{
    public interface IHasteable
    {
        public float HasteMaxValue{get;}
        public float HasteMultiplier {get; set;}
        public float HastePrecentage { get; set; }
        public abstract float HasteReduction();
        public abstract void UpdateSpellCooldown();
    }
}