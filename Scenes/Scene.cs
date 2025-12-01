using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using VGP133_Final_Assignment.Core;

namespace VGP133_Final_Assignment.Scenes
{
    public abstract class Scene
    {
        public Scene(SceneHandler sceneHandler)
        {
                Handler = sceneHandler;
        }

        public abstract void Update();
        public abstract void Render();

        private string? _sceneName;

        protected string? SceneName { get => _sceneName; set => _sceneName = value; }
        protected SceneHandler Handler { get; }
    }
}
