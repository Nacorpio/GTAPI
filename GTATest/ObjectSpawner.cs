using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTA.Math;

namespace GTATest
{
    public class ObjectSpawner : Script
    {
        private Camera _camera;
        private readonly List<int> _props = new List<int>();

        private bool _active;
        private int _index;

        private readonly UIText _propLabel = new UIText("N/A", new Point(Game.ScreenResolution.Width / 2, Game.ScreenResolution.Height - 100), 0.4f);

        private class PropModel
        {
            /// <summary>
            /// Initializes an instance of the PropModel class.
            /// </summary>
            /// <param name="handle">The prop handle.</param>
            public PropModel(int handle) : this(new Prop(handle))
            {}

            /// <summary>
            /// Initializes an instance of the PropModel class.
            /// </summary>
            /// <param name="prop">The prop.</param>
            public PropModel(Prop prop)
            {
                if (prop == null) {
                    return;
                }

                Prop = prop;

                Vector3 max, min;
                prop.Model.GetDimensions(out max, out min);

                Max = max;
                Min = min;
            }

            /// <summary>
            /// Gets the cubic area of this PropModel.
            /// </summary>
            public float CubicArea => Height*Width*Length;

            /// <summary>
            /// Gets the base area of this PropModel.
            /// </summary>
            public float BaseArea => Width*Length;

            /// <summary>
            /// Gets the height of this PropModel.
            /// </summary>
            public float Height => Min.Z - Max.Z;

            /// <summary>
            /// Gets the width of this PropModel.
            /// </summary>
            public float Width => Min.X - Max.X;

            /// <summary>
            /// Gets the length of this PropModel.
            /// </summary>
            public float Length => Min.Y - Max.Y;

            /// <summary>
            /// Gets the Prop of this PropModel.
            /// </summary>
            public Prop Prop { get; }

            /// <summary>
            /// Gets the max Vector3 of this PropModel.
            /// </summary>
            public Vector3 Max { get; }

            /// <summary>
            /// Gets the min Vector3 of this PropModel.
            /// </summary>
            public Vector3 Min { get; }
        }

        public ObjectSpawner()
        {
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode) {

                case Keys.C:

                    if (_props.Count == 0) {
                        return;
                    } 

                    _active = !_active;
                    Game.Player.CanControlCharacter = !_active;

                    if (_active) {
                        MoveTo(_index);
                        World.RenderingCamera = _camera;
                    } else {
                        World.RenderingCamera = null;
                    }

                    break;

                case Keys.D:

                    if (!_active) return;

                    if (_index + 1 <= _props.Count - 1) {
                        _index++;
                    } else {
                        _index = 0;
                    }

                    MoveTo(_index);
                    break;

                case Keys.A:

                    if (!_active) return;

                    if (_index - 1 > 0) {
                        _index--;
                    } else {
                        _index = _props.Count - 1;
                    }

                    MoveTo(_index);
                    break;

            }
        }

        private void MoveTo(int index)
        {
            var propModel = new PropModel(_props[index]);

            if (_camera == null) {
                _camera = World.CreateCamera(propModel.Prop.Position, Vector3.Zero, 100f);
            }

            _camera.Position = propModel.Prop.Position + (Vector3.RelativeTop * 1.10f) + (Vector3.RelativeBack * propModel.BaseArea);
            _camera.PointAt(propModel.Prop);

            _propLabel.Caption = $"Height: ~g~{propModel.Height}\n" +
                                 $"~w~Width: ~g~{propModel.Width}\n" +
                                 $"~w~Length: ~g~{propModel.Length}";
        }

        private float _range = 5f;
        private void OnTick(object sender, EventArgs eventArgs)
        {
            var props = World.GetNearbyProps(Game.Player.Character.Position, _range);
            props.ToList().Where(prop => !_props.Contains(prop.Handle)).ToList().ForEach(prop => _props.Add(prop.Handle));

            _props.ForEach(prop =>
            {
                var p = new Prop(prop);
                if (p.Position.DistanceTo(Game.Player.Character.Position) > _range)
                    _props.Remove(p.Handle);
            });

            if (_active) {
                var model = new PropModel(_props[_index]);
                World.DrawMarker(MarkerType.HorizontalCircleSkinny, model.Prop.Position + (Vector3.WorldUp * 0.5f), Vector3.Zero, Vector3.Zero, new Vector3(model.BaseArea, model.BaseArea, 0), Color.White);
                _propLabel.Draw();
            }
        }
    }
}
