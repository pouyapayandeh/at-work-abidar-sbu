﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using at_work_abidar_sbu.HardwareInterface;

namespace at_work_abidar_sbu.HardwareAPI
{
    enum Orientation
    {
        Front,
        Rear,
        Left,
        Right
    }

    class Navigation
    {
        CentralBoard board;
        MotorControl motor;
        DX dynamixel;
        Thread NavigationThread;

        private bool running;
        private bool Moving;

        int desiredEncoderValue;
        MotorControl.Motors encoderToWatch;
        
        private byte Speed;
                
        public Navigation()
        {
            board = new CentralBoard();
            motor = new MotorControl();
            dynamixel = new DX();
            running = false;
            Moving = false;
            Speed = 0;
        }

        ~Navigation()
        {
            End();
        }

        private void ThreadWorker()
        {
            int currentEncoderValue = 0;

            while(running)
            {
                if(Moving)
                {
                    currentEncoderValue = Math.Abs(motor.GetEncoderValue(encoderToWatch));
                    if(currentEncoderValue > desiredEncoderValue)
                    {
                        Moving = false;
                        desiredEncoderValue = 0;
                        motor.SetDestination(0, 0, 0);
                    }
                }
            }
        }

        public void Initialize()
        {
            if (!running)
            {
                board.SelectLaser(true, CentralBoard.Laser.Left);
                board.SelectLaser(true, CentralBoard.Laser.Right);

                motor.Start();
                board.Start();
                running = true;
                Moving = false;

                NavigationThread = new Thread(new ThreadStart(ThreadWorker));
                NavigationThread.Start();
            }
        }

        public void End()
        {
            if (running)
            {
                motor.Stop();
                board.Stop();
                running = false;
                Moving = false;
            }
        }

        public bool IsRunning()
        {
            return running;
        }

        public bool IsMoving()
        {
            return Moving;
        }

        public void SetSpeed(byte speed)
        {
            this.Speed = speed;
        }

        public void Go(float xCm, float yCm)
        {
            if (Moving)
                return;

            motor.ResetEncoder();

            if (xCm == 0 && yCm == 0)
                return;

            desiredEncoderValue = Math.Abs((int)((xCm != 0 ? xCm : yCm) * (998 / 35)));

            if (xCm == 0 || yCm == 0)
            {
                encoderToWatch = MotorControl.Motors.FrontLeft;     //All wheels can be used
            }
            else
            {
                if ((xCm < 0 && yCm > 0) || (xCm > 0 && yCm < 0))
                {
                    encoderToWatch = MotorControl.Motors.FrontRight;
                }
                else
                {
                    encoderToWatch = MotorControl.Motors.FrontLeft;
                }
                desiredEncoderValue = (int)(desiredEncoderValue * 1.414213562373);
            }

            int xSpeed = (xCm > 0 ? Speed : -Speed);
            int ySpeed = (yCm > 0 ? Speed : -Speed);

            if (xCm == 0)
                xSpeed = 0;

            if (yCm == 0)
                ySpeed = 0;

            motor.SetDestination(xSpeed, ySpeed, 0);

            Moving = true;
        }

        public void Rotate(float degree)
        {
            if (Moving)
                return;

            Moving = true;
        }

        public float GetDistance(Orientation or, CentralBoard.Laser laser)
        {
            float result = 0.0f;

            switch(or)
            {
                case Orientation.Front:
                    
                    break;
                case Orientation.Rear:

                    break;
                case Orientation.Left:

                    break;
                case Orientation.Right:

                    break;
            }

            Thread.Sleep(400);                  //Let Laser update value

            result = board.GetLaserValue(laser) / 10;

            return result;
        }

    }
}