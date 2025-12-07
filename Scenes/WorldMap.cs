using VGP133_Final_Assignment.Core;
using Raylib_cs;

namespace VGP133_Final_Assignment.Scenes
{
    public class WorldMap : Scene
    {
        public WorldMap(SceneHandler sceneHandler) : base(sceneHandler)
        {
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawText("WorldMap Scene", 0, 0, 20, Color.Black);
        }

        public override void Update()
        {

        }

        // Sprites



    }
}
