using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Scenes
{
    public abstract class Scene : IDrawable
    {
        public Scene(SceneHandler sceneHandler)
        {
            Handler = sceneHandler;
        }

        public abstract void Update();
        public abstract void Render();

        private string? _sceneName;
        protected static Vector2 s_origin = new Vector2(0, 0);

        protected string? SceneName { get => _sceneName; set => _sceneName = value; }
        protected SceneHandler Handler { get; }
    }
}
