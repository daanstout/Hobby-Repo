using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using ResourceGatherer.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer {
    public sealed class MainWindow : GameWindow {
        private int _program;
        private double _time;
        private readonly string _title = "Resource Gatherer";
        private List<RenderObject> _renderObjects = new List<RenderObject>();
        private readonly string vertexShaderDir = @"Shaders\VertexShader.vs";
        private readonly string fragmentShaderDir = @"Shaders\FragmentShader.fs";
        private Matrix4 _modelView;
        private readonly Color4 _backColor = new Color4(0.1f, 0.1f, 1.0f, 0.3f);
        private bool _doRotate = true;
        private Matrix4 _projectionMatrix;

        public MainWindow() : base(1280, // initial width
                                    720, // initial height
                                    GraphicsMode.Default,
                                    "dreamstatecoding",  // initial title
                                    GameWindowFlags.Default,
                                    DisplayDevice.Default,
                                    4, // OpenGL major version
                                    5, // OpenGL minor version
                                    GraphicsContextFlags.ForwardCompatible) => Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

        protected override void OnResize(EventArgs e) {
            GL.Viewport(0, 0, Width, Height);
            CreateProjection();
        }

        protected override void OnLoad(EventArgs e) {
            VSync = VSyncMode.Off;
            CreateProjection();
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.HotPink)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.BlueViolet)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.Red)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.LimeGreen)));

            CursorVisible = true;

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs eventArgs) => Exit();

        public override void Exit() {
            Debug.WriteLine("Exit called");

            // Dispose of all the render objects
            foreach (RenderObject obj in _renderObjects)
                obj.Dispose();

            // Delete the program
            GL.DeleteProgram(_program);
            base.Exit();
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            _time += e.Time;
            if (_doRotate) {
                float k = (float)_time * 0.05f;
                Matrix4 r1 = Matrix4.CreateRotationX(k * 13.0f);
                Matrix4 r2 = Matrix4.CreateRotationY(k * 13.0f);
                Matrix4 r3 = Matrix4.CreateRotationZ(k * 3.0f);
                Matrix4 t1 = Matrix4.CreateTranslation((float)(Math.Sin(k * 5f) * 0.5f), (float)(Math.Cos(k * 5f) * 0.5f), 0f);
                _modelView = r1 * r2 * r3 * t1;
            }

            HandleKeyboard();
        }

        private void HandleKeyboard() {
            // Get the keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // If the escape key is pressed, exit
            if (keyState.IsKeyDown(Key.Escape))
                Exit();
            if (keyState.IsKeyDown(Key.Space))
                _doRotate = !_doRotate;
        }

        private int CompileShader(ShaderType type, string path) {
            // Create the shaders based on the type
            int shader = GL.CreateShader(type);
            // read the contents of the shader file
            string src = File.ReadAllText(path);
            // Add the source to the shader
            GL.ShaderSource(shader, src);
            // Compile the shader
            GL.CompileShader(shader);
            // Get info from the shader log
            string info = GL.GetShaderInfoLog(shader);
            // If it is not empty, write it to debug
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLine($"GL.CompileShader [{type}] had info log: {info}");
            return shader;
        }

        private int CreateProgram() {
            try {
                // Create a program in the graphics card
                int program = GL.CreateProgram();
                // Load the shaders into the graphics card
                List<int> shaders = new List<int> {
                    CompileShader(ShaderType.VertexShader, vertexShaderDir),
                    CompileShader(ShaderType.FragmentShader, fragmentShaderDir)
                };

                // Attach the shaders to the program
                foreach (int shader in shaders)
                    GL.AttachShader(program, shader);

                // Link the program
                GL.LinkProgram(program);

                // Get info from the program info
                string info = GL.GetProgramInfoLog(program);
                // If it is not empty, write it to debug
                if (!string.IsNullOrWhiteSpace(info))
                    throw new Exception($"CompileShaders ProgramLinking had errors: {info}");

                // Detach and delete the shaders
                foreach (int shader in shaders) {
                    GL.DetachShader(program, shader);
                    GL.DeleteShader(shader);
                }

                return program;
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            Title = $"{_title}: (Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(_backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);
            GL.UniformMatrix4(20, false, ref _projectionMatrix);
            float c = 0f;
            foreach (RenderObject renderObject in _renderObjects) {
                renderObject.Bind();
                for (int i = 0; i < 5; i++) {
                    float k = i + (float)(_time * (0.05f + (0.1 * c)));
                    Matrix4 t2 = Matrix4.CreateTranslation(
                        (float)(Math.Sin(k * 5f) * (c + 0.5f)),
                        (float)(Math.Cos(k * 5f) * (c + 0.5f)),
                        -2.7f);
                    Matrix4 r1 = Matrix4.CreateRotationX(k * 13.0f + i);
                    Matrix4 r2 = Matrix4.CreateRotationY(k * 13.0f + i);
                    Matrix4 r3 = Matrix4.CreateRotationZ(k * 3.0f + i);
                    Matrix4 modelView = r1 * r2 * r3 * t2;
                    GL.UniformMatrix4(21, false, ref modelView);
                    renderObject.Render();
                }
                c += 0.3f;
            }
            GL.PointSize(10);
            SwapBuffers();
        }

        private void CreateProjection() {

            float aspectRatio = (float)Width / Height;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                60 * ((float)Math.PI / 180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000f);                     // far plane
        }
    }
}
