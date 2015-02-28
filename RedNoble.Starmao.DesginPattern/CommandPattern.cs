//命令模式，封装方法调用

using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    public class CommandPattern
    {
        public class Fan
        {
            public const int HIGH = 3;
            public const int MEDIUM = 2;
            public const int LOW = 1;
            public const int OFF = 0;
            private readonly string _name;

            public Fan(string name)
            {
                _name = name;
                Speed = OFF;
            }

            public int Speed { get; set; }

            public void High()
            {
                Console.WriteLine("{0}高速风扇开启了", _name);
                Speed = HIGH;
            }

            public void Medium()
            {
                Console.WriteLine("{0}中速风扇开启了", _name);
                Speed = MEDIUM;
            }

            public void Low()
            {
                Console.WriteLine("{0}低速风扇开启了", _name);
                Speed = LOW;
            }

            public void Off()
            {
                Console.WriteLine("{0}风扇关闭了", _name);
                Speed = OFF;
            }
        }

        public class FanHighCommand : ICommand
        {
            private readonly Fan _fan;

            private int _speed;

            public FanHighCommand(Fan fan)
            {
                _fan = fan;
            }

            public void Excute()
            {
                _speed = _fan.Speed;
                _fan.High();
            }

            public void Undo()
            {
                switch (_speed)
                {
                    case Fan.HIGH:
                        _fan.High();
                        break;
                    case Fan.MEDIUM:
                        _fan.Medium();
                        break;
                    case Fan.LOW:
                        _fan.Low();
                        break;
                    case Fan.OFF:
                        _fan.Off();
                        break;
                }
            }
        }

        public class FanLowCommand : ICommand
        {
            private readonly Fan _fan;

            private int _speed;

            public FanLowCommand(Fan fan)
            {
                _fan = fan;
            }

            public void Excute()
            {
                _speed = _fan.Speed;
                _fan.Low();
            }

            public void Undo()
            {
                switch (_speed)
                {
                    case Fan.HIGH:
                        _fan.High();
                        break;
                    case Fan.MEDIUM:
                        _fan.Medium();
                        break;
                    case Fan.LOW:
                        _fan.Low();
                        break;
                    case Fan.OFF:
                        _fan.Off();
                        break;
                }
            }
        }

        public class FanMediumCommand : ICommand
        {
            private readonly Fan _fan;

            private int _speed;

            public FanMediumCommand(Fan fan)
            {
                _fan = fan;
            }

            public void Excute()
            {
                _speed = _fan.Speed;
                _fan.Medium();
            }

            public void Undo()
            {
                switch (_speed)
                {
                    case Fan.HIGH:
                        _fan.High();
                        break;
                    case Fan.MEDIUM:
                        _fan.Medium();
                        break;
                    case Fan.LOW:
                        _fan.Low();
                        break;
                    case Fan.OFF:
                        _fan.Off();
                        break;
                }
            }
        }

        public class FanOffCommand : ICommand
        {
            private readonly Fan _fan;

            private int _speed;

            public FanOffCommand(Fan fan)
            {
                _fan = fan;
            }

            public void Excute()
            {
                _speed = _fan.Speed;
                _fan.Off();
            }

            public void Undo()
            {
                switch (_speed)
                {
                    case Fan.HIGH:
                        _fan.High();
                        break;
                    case Fan.MEDIUM:
                        _fan.Medium();
                        break;
                    case Fan.LOW:
                        _fan.Low();
                        break;
                    case Fan.OFF:
                        _fan.Off();
                        break;
                }
            }
        }

        public class FanRemoteControl
        {
            private readonly ICommand[] _iOffCommands;
            private readonly ICommand[] _iOnCommands;
            private ICommand _undoCommand;

            public FanRemoteControl()
            {
                _iOnCommands = new ICommand[3];
                _iOffCommands = new ICommand[3];
                var noCommand = new NoCommand();
                for (int i = 0; i < 3; i++)
                {
                    _iOnCommands[i] = noCommand;
                    _iOffCommands[i] = noCommand;
                }
                _undoCommand = noCommand;
            }

            public void SetCommand(int i, ICommand onCommand, ICommand offCommand)
            {
                _iOnCommands[i] = onCommand;
                _iOffCommands[i] = offCommand;
            }

            public void OnClick(int i)
            {
                _iOnCommands[i].Excute();
                _undoCommand = _iOnCommands[i];
            }

            public void OffClick(int i)
            {
                _iOffCommands[i].Excute();
                _undoCommand = _iOffCommands[i];
            }

            public void Undo()
            {
                _undoCommand.Undo();
            }
        }

        public interface ICommand
        {
            /// <summary>
            ///     执行
            /// </summary>
            void Excute();

            /// <summary>
            ///     撤销
            /// </summary>
            void Undo();
        }

        public class Light
        {
            public Light(string name)
            {
                Name = name;
            }

            public string Name { get; set; }

            public void On()
            {
                Console.WriteLine("{0}灯开启了", Name);
            }

            public void Off()
            {
                Console.WriteLine("{0}灯关闭了", Name);
            }
        }

        public class LigthOffCommand : ICommand
        {
            private readonly Light _light;

            public LigthOffCommand(Light light)
            {
                _light = light;
            }

            public void Excute()
            {
                _light.Off();
            }

            public void Undo()
            {
                _light.On();
            }
        }

        public class LigthOnCommand : ICommand
        {
            private readonly Light _light;

            public LigthOnCommand(Light light)
            {
                _light = light;
            }

            public void Excute()
            {
                _light.On();
            }

            public void Undo()
            {
                _light.Off();
            }
        }

        public class NoCommand : ICommand
        {
            public void Excute()
            {
            }

            public void Undo()
            {
            }
        }

        public class RemoteControl
        {
            private readonly ICommand[] _iOffCommands;
            private readonly ICommand[] _iOnCommands;
            private ICommand _undoCommand;

            public RemoteControl()
            {
                _iOnCommands = new ICommand[3];
                _iOffCommands = new ICommand[3];
                ICommand noCommand = new NoCommand();
                for (int i = 0; i < 3; i++)
                {
                    _iOnCommands[i] = noCommand;
                    _iOffCommands[i] = noCommand;
                }
                _undoCommand = noCommand;
            }

            public void SetCommand(int i, ICommand onCommand, ICommand offCommand)
            {
                _iOnCommands[i] = onCommand;
                _iOffCommands[i] = offCommand;
            }

            public void OnClick(int i)
            {
                _iOnCommands[i].Excute();
                _undoCommand = _iOnCommands[i];
            }

            public void OffClick(int i)
            {
                _iOffCommands[i].Excute();
                _undoCommand = _iOffCommands[i];
            }

            public void Undo()
            {
                _undoCommand.Undo();
            }
        }

        public class SenceTest
        {
            [Test]
            public void Test()
            {
                #region 电灯测试

                var wsLight = new Light("卧室");
                var wsLigthOnCommand = new LigthOnCommand(wsLight);
                var wsLigthOffCommand = new LigthOffCommand(wsLight);

                var ktLight = new Light("客厅");
                var ktLigthOnCommand = new LigthOnCommand(ktLight);
                var ktLigthOffCommand = new LigthOffCommand(ktLight);

                var lightRemoteControl = new RemoteControl();
                lightRemoteControl.SetCommand(0, wsLigthOnCommand, wsLigthOffCommand);
                lightRemoteControl.SetCommand(1, ktLigthOnCommand, ktLigthOffCommand);

                lightRemoteControl.OnClick(0);
                lightRemoteControl.OffClick(0);

                lightRemoteControl.OnClick(1);
                lightRemoteControl.Undo();
                lightRemoteControl.OffClick(1);

                lightRemoteControl.Undo();

                #endregion
            }

            [Test]
            public void FanTest()
            {
                var ktFan = new Fan("客厅");
                var ktFanHighCommand = new FanHighCommand(ktFan);
                var ktFanMediumCommand = new FanMediumCommand(ktFan);
                var ktFanLowCommand = new FanLowCommand(ktFan);
                var ktFanOffCommand = new FanOffCommand(ktFan);

                var fanRemoteControl = new RemoteControl();
                fanRemoteControl.SetCommand(0, ktFanHighCommand, ktFanOffCommand);
                fanRemoteControl.SetCommand(1, ktFanMediumCommand, ktFanOffCommand);
                fanRemoteControl.SetCommand(2, ktFanLowCommand, ktFanOffCommand);

                fanRemoteControl.OnClick(0);
                //fanRemoteControl.OffClick(0);
                fanRemoteControl.OnClick(1);
                fanRemoteControl.OnClick(2);
                fanRemoteControl.OnClick(0);
                fanRemoteControl.Undo();
            }
        }
    }
}