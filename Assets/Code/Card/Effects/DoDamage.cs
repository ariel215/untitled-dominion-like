using GameResources;
namespace Effects
{

    public class DoDamage : Effect
    {

        public int Amount;

        public Opponent Target;


        public override void Apply()
        {
            ResourcePool.gPool.Shift(
                ResourceType.Damage, Amount
                );
        }

        public override string ToString()
        {
            return $"+{Amount} {ResourceType.Damage.String()}";
        }
    }
}