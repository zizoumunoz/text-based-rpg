using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;

namespace VGP133_Final_Assignment.Game
{
    public class Map : IDrawable
    {
        public Map()
        {
            for (int column = 0; column < _mapTiles.GetLength(1); column++)
            {
                _mapTiles[0, column] =
                    new Ocean(new Vector2(205 + 30 * column, 21), _monsters);
                _mapTiles[4, column] =
                    new Ocean(new Vector2(205 + 30 * column, 141), _monsters);
            }

            _mapTiles[1, 0] =
                new Forest(new Vector2(205, 51), _monsters);
            _mapTiles[1, 1] =
                new Forest(new Vector2(235, 51), _monsters);
            _mapTiles[1, 2] =
                new Forest(new Vector2(265, 51), _monsters);
            _mapTiles[1, 3] =
                new Mountain(new Vector2(295, 51), _monsters);
            _mapTiles[1, 4] =
                new Mountain(new Vector2(325, 51), _monsters);

            _mapTiles[2, 0] =
                new Village(new Vector2(205, 81), _monsters);
            _mapTiles[2, 1] =
                new Forest(new Vector2(235, 81), _monsters);
            _mapTiles[2, 2] =
                new Forest(new Vector2(265, 81), _monsters);
            _mapTiles[2, 3] =
                new Mountain(new Vector2(295, 81), _monsters);
            _mapTiles[2, 4] =
                new Castle(new Vector2(325, 81), _monsters);

            _mapTiles[3, 0] =
                new Forest(new Vector2(205, 111), _monsters);
            _mapTiles[3, 1] =
                new Forest(new Vector2(235, 111), _monsters);
            _mapTiles[3, 2] =
                new Mountain(new Vector2(265, 111), _monsters);
            _mapTiles[3, 3] =
                new Mountain(new Vector2(295, 111), _monsters);
            _mapTiles[3, 4] =
                new Mountain(new Vector2(325, 111), _monsters);

            _playerPixelLocation = _mapTiles[0, 2].Location;
            _playerTileLocation = new Vector2(2, 0);

            _playerSprite = new Text(
                "x",
                _playerPixelLocation,
                20 * UIScale,
                Color.Red
             );
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            for (int column = 0; column < _mapTiles.GetLength(1); column++)
            {
                _mapTiles[0, column].Render();
                _mapTiles[1, column].Render();
                _mapTiles[2, column].Render();
                _mapTiles[3, column].Render();
                _mapTiles[4, column].Render();
                RenderPlayer();
            }
        }

        public void MovePlayer(char direction)
        {
            // Can't move to rows 0 and 4
            switch (direction)
            {
                case 'N':
                    if (_playerTileLocation.Y - 1 >= 0)
                    {
                        _playerTileLocation.Y--;
                    }
                    break;
                case 'S':
                    if (_playerTileLocation.Y + 1 <= 4)
                    {
                        _playerTileLocation.Y++;
                    }
                    break;
                case 'E':
                    if (_playerTileLocation.X + 1 <= 4)
                    {
                        _playerTileLocation.X++;
                    }
                    break;
                case 'W':
                    if (_playerTileLocation.X - 1 >= 0)
                    {
                        _playerTileLocation.X--;
                    }
                    break;
                default:
                    break;
            }

            _playerSprite.Position =
                _mapTiles[(int)_playerTileLocation.Y, (int)_playerTileLocation.X].Location;


        }

        private void RenderPlayer()
        {
            _playerSprite.Render();
        }

        Text _playerSprite;
        private Vector2 _playerPixelLocation;
        private Vector2 _playerTileLocation;

        private Terrain[,] _mapTiles = new Terrain[5, 5];
        List<Monster> _monsters = new List<Monster>();

        public Terrain[,] MapTiles { get => _mapTiles; set => _mapTiles = value; }
        public Vector2 PlayerTileLocation { get => _playerTileLocation; set => _playerTileLocation = value; }
    }
}
