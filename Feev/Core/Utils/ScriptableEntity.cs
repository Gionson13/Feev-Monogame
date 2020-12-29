namespace Feev.Utils
{
    public class ScriptableEntity
    {
        internal Entity owner;

        protected internal virtual void OnInitialize() { }
        protected internal virtual void OnUpdate() { }

        protected ref T GetComponent<T>() where T : struct
        {
            return ref owner.GetComponent<T>();
        }
        protected ref T AddComponent<T>() where T : struct
        {
            return ref owner.AddComponent<T>();
        }
        protected void RemoveComponent<T>() where T : struct
        {
            owner.RemoveComponent<T>();
        }
        protected bool HasComponent<T>() where T : struct
        {
            return owner.HasComponent<T>();
        }
        protected Entity GetEntity(string tag)
        {
            foreach (Entity entity in Globals.entities)
            {
                string entityTag = entity.GetComponent<TagComponent>().Tag;

                if (entityTag == tag)
                    return entity;
            }

            return null;
        }

        public void Exit() => Globals.shouldExit = true;
    }
}
