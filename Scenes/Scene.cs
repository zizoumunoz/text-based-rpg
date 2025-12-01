using System;
using System.Collections.Generic;
using System.Text;

namespace VGP133_Final_Assignment.Scenes
{
    public abstract class Scene
    {
        public abstract void Update();
        public abstract void Render();

        private string? _sceneName;

        protected string? SceneName { get => _sceneName; set => _sceneName = value; }
    }
}
