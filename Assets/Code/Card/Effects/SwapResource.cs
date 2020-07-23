using GameResources;


namespace Effects {
    public class SwapResource : Effect
    {

        public ResourceType Source;
        public ResourceType Dest;

        public override void Apply()
        {
            var pool = ResourcePool.gPool;
            pool.Shift(Dest, pool.Resources[Source]);
        }

        public override string ToString()
        {
            return $"{Source.String()} > {Dest.String()}";
        }
    }
}