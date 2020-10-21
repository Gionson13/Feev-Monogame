using Feev.Debug;
using Leopotam.Ecs;
using Microsoft.Xna.Framework;
using System;

namespace Feev.Utils
{
    public class Entity
    {
        private EcsEntity _entity;

        public event TransformEventHandler OnTransformChanged;

        public Entity()
        {
            _entity = Globals.ecsWorld.NewEntity();
            Initialize($"Untitled ({_entity.GetInternalId()})");
        }

        public Entity(string tag)
        {
            _entity = Globals.ecsWorld.NewEntity();
            Initialize(tag);
        }

        private void Initialize(string tag)
        {
            ref TagComponent tagComponent = ref _entity.Get<TagComponent>();
            ref TransformComponent transformComponent = ref _entity.Get<TransformComponent>();

            tagComponent.Tag = tag;
            transformComponent.owner = this;
            transformComponent.Position = Vector2.Zero;
            transformComponent.Rotation = 0f;
            transformComponent.Scale = Vector2.One;

            Globals.entities.Add(this);
        }

        public void Update()
        {
            if (_entity.Has<ScriptComponent>())
            {
                ref ScriptComponent script = ref _entity.Get<ScriptComponent>();
                script.Update();
            }

            if (_entity.Has<AnimatedSpriteComponent>())
            {
                ref AnimatedSpriteComponent animatedSprite = ref _entity.Get<AnimatedSpriteComponent>();
                animatedSprite.Update();
            }

            if (_entity.Has<ButtonComponent>())
            {
                ref ButtonComponent button = ref _entity.Get<ButtonComponent>();
                button.Update();
            }
        }

        internal void Draw()
        {
            if (_entity.Has<SpriteComponent>())
            {
                ref SpriteComponent sprite = ref _entity.Get<SpriteComponent>();
                sprite.Draw();
            }

            if (_entity.Has<AnimatedSpriteComponent>())
            {
                ref AnimatedSpriteComponent animatedSprite = ref _entity.Get<AnimatedSpriteComponent>();
                animatedSprite.Draw();
            }

            if (_entity.Has<TilemapComponent>())
            {
                ref TilemapComponent tilemap = ref _entity.Get<TilemapComponent>();
                tilemap.Draw();
            }
        }

        internal void DrawUI()
        {
            if (_entity.Has<ButtonComponent>())
            {
                ref ButtonComponent button = ref _entity.Get<ButtonComponent>();
                button.Draw();
            }

            if (_entity.Has<LabelComponent>())
            {
                ref LabelComponent label = ref _entity.Get<LabelComponent>();
                label.Draw();
            }
        }

        public ref T GetComponent<T>() where T : struct
        {
            if (_entity.Has<T>()) 
                return ref _entity.Get<T>();
            else 
                throw new Exception("Entity does not have component of type " + typeof(T));
        }
        public ref T AddComponent<T>() where T : struct
        {
            return ref _entity.Get<T>();
        }
        public void RemoveComponent<T>() where T : struct
        {
            if (typeof(TagComponent) == typeof(T) || typeof(TransformComponent) == typeof(T))
            {
                Log.Error("Cannot remove " + typeof(T) + " from entity");
                return;
            }

            _entity.Del<T>();
        }
        public bool HasComponent<T>() where T : struct
        {
            return _entity.Has<T>();
        }

        internal void TransformChanged(Vector2 position, float rotation, Vector2 scale)
        {
            OnTransformChanged?.Invoke(this, new TransformEventArgs(position, rotation, scale));
        }

    }
}
