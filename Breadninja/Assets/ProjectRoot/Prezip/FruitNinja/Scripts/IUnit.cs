using Unity.VisualScripting;

namespace Root
{
    public interface IUnit
    {
        void Construct(GameConfig gameConfig);

        void Push();
    }
}