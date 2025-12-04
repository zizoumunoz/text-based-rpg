using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using VGP133_Final_Assignment.Components;
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

        public virtual void Unload()
        {
            _background.Unload();
        }

        private string? _sceneName;

        protected Sprite _background =
            new Sprite("Assets/character_creation/book_sketch.png", new System.Numerics.Vector2(0f, 0f), 5f);

        protected Sprite Background { get => _background; set => _background = value; }

        protected string? SceneName { get => _sceneName; set => _sceneName = value; }
        protected SceneHandler Handler { get; }
    }
}
