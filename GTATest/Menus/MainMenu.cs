using System.Drawing;
using GTA;
using mlgthatsme.GUI;

namespace GTATest.Menus
{
    public class MainMenu : BaseMenu
    {
        private readonly Button _btn1, _btn3, _btn4, _btn5, _btn6, _btn7;
        private readonly Devider _div1, _div2, _div3;
        private readonly TickBox _tick1, _tick2, _tick3;

        public MainMenu()
        {
            TitleText = "Main Menu";
            TitleColor = Color.LightBlue;
            CustomThemeColor = Color.MidnightBlue;

            _div2 = new Devider("My Business");

            _btn1 = new Button("Contacts");
            _btn3 = new Button("Properties");
            _btn5 = new Button("Inventory");

            _div1 = new Devider("Goods");

            _btn6 = new Button("Weapons");
            _btn4 = new Button("Vehicles");
            _btn7 = new Button("Drops");

            _div3 = new Devider("Debug");

            _tick1 = new TickBox("Blackout") {IsChecked = true};
            _tick1.OnPress += (sender, args) => World.SetBlackout(_tick1.IsChecked);

            _tick3 = new TickBox("Despawn Entities") {IsChecked = SpawnScript.DoDespawn};
            _tick3.OnPress += (sender, args) => SpawnScript.DoDespawn = _tick3.IsChecked;
        }

        public override void InitControls()
        {
            base.InitControls();

            AddMenuItem(_div2);

            AddMenuItem(_btn1);
            AddMenuItem(_btn3);
            AddMenuItem(_btn5);

            AddMenuItem(_div1);

            AddMenuItem(_btn6);
            AddMenuItem(_btn4);
            AddMenuItem(_btn7);

            AddMenuItem(_div3);

            AddMenuItem(_tick1);
            AddMenuItem(_tick3);
        }
    }
}
