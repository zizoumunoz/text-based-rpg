using System;
using System.Collections.Generic;
using System.Text;
using VGP133_Final_Assignment.Scenes;

namespace VGP133_Final_Assignment.Core
{
    public class SceneHandler
    {
        private Scene? _currentScene;

        public Scene? CurrentScene { get => _currentScene; set => _currentScene = value; }
    }
}
