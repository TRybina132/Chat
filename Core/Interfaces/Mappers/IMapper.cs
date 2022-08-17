namespace Core.Interfaces.Mappers
{
    public interface IMapper<Entity, ViewModel>
    {
        ViewModel Map(Entity entity);
    }
}
