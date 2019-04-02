using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Rendering {
    public struct Vertex {
        public const int Size = (4 + 4) * 4; // size of struct in bytes

        private readonly Vector4 _position;
        private readonly Color4 _color;

        public Vertex(Vector4 position, Color4 color) {
            _position = position;
            _color = color;
        }
    }

    public struct TexturedVertex {
        public const int Size = (4 + 2) * 4; // size of struct in bytes

        private readonly Vector4 _position;
        private readonly Vector2 _textureCoordinate;

        public TexturedVertex(Vector4 position, Vector2 textureCoordinate) {
            _position = position;
            _textureCoordinate = textureCoordinate;
        }
    }
}
