﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using at_work_abidar_sbu.HardwareInterface;
using System.Threading;
using at_work_abidar_sbu.AI.Navigation;
using at_work_abidar_sbu.AI.Planning;
using at_work_abidar_sbu.GraphicUtils;
using at_work_abidar_sbu.HardwareAPI;
using Point = at_work_abidar_sbu.AI.Navigation.Point;

namespace at_work_abidar_sbu
{
    public partial class MainForm : Form
    {
        Arm arm;

        public MainForm()
        {
            InitializeComponent();
        }

        private Map map;
        private Point robot;
        private List<Point> rallyPoint;
        private void cameraTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraTestForm cameraTestForm = new CameraTestForm();
            cameraTestForm.ShowDialog();
        }

        private void configsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm propertiesForm = new PropertiesForm();
            propertiesForm.ShowDialog();
        }

        private void mapBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitMapBuilderForm mapBuilderForm = new InitMapBuilderForm();
            mapBuilderForm.ShowDialog();
        }

        private void qRTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QrCodeTestForm qrCodeTestForm = new QrCodeTestForm();
            qrCodeTestForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void motorTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotorControlForm mf = new MotorControlForm();
            mf.ShowDialog();
        }

        private void loadMapMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                map = Map.Load(openFileDialog1.FileName);
                Render();
            }
        }

        private void Render()
        {
            Renderer renderer = new Renderer();


            var r = renderer.EmptyFrame(pictureBox1.Width, pictureBox1.Height, Color.White)
                .DrawMap(map)
                .DrawRobot(robot, map)
                .DrawPath(path, map);
            if (route != null)
                r = r.DrawLaseres(robot, map, (int) route.LL, (int) route.LF, (int) route.RR, (int) route.RF);

            pictureBox1.Image = r.GetBitmap();

        }

        private RoutePlanner route;
        private PathShape path;
        private Navigation nav;
        private void navigateBtn_Click(object sender, EventArgs e)
        {
            CreatePathForm createPathForm = new CreatePathForm();
            createPathForm.pathFinder =new PathFinder();
            createPathForm.map = map;
            nav = Navigation.i;
            createPathForm.FormClosing += (o, form) =>
            {
                map = createPathForm.map;
                path = new PathShape();
                path.path = createPathForm.pathFinder.getPath();
                route = new RoutePlanner(path,map,createPathForm.pathFinder);
                rallyPoint = route.NormalizePath();
                robot = rallyPoint[0] ?? new Point(0, 0);
                //rallyPoint.RemoveAt(0);

              
              //  nav.Initialize();
                nav.SetSpeed(10);
                moved = true;
                Timer1.Enabled = true;
            };
            createPathForm.Show();
        }

        private bool moved = false;
        private int R = 44;
        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (nav.IsMoving())
                moved = true;
            else
            {
                if (moved)
                {
                    moved = false;
                    if (rallyPoint.Count > 0)
                    {

                        
                        var robotl = rallyPoint[0];


                        robot = route.RobotPositionFromLasers();
                        Console.WriteLine("Robot: {0} {1}", robot.x, robot.y);
                        Console.WriteLine("Robot: {0} {1} {2} {3}", route.LL, route.LF, route.RF, route.RR);
                       // Render();

                        if (route.pathFinder.setSrc((int) (robotl.x - R / 2), (int) (robotl.y - R / 2), R, R, 2,
                            route.LL, route.LF, route.RR, route.RF))
                        {
                            route.pathFinder.findPath();
                            Console.WriteLine("rec");
                        }
                            


                        path = new PathShape();
                        Console.WriteLine("Path Hash" + path.GetHashCode());
                        path.path = route.pathFinder.getPath();
                        route.path = path;
                        rallyPoint = route.NormalizePath();
                        rallyPoint.RemoveAt(0);
                        while (rallyPoint.Count > 1)
                        {
                            double dx = rallyPoint[0].x - robot.x;
                            double dy = rallyPoint[0].y - robot.y;
                            if (dx * dx + dy * dy < 4)
                                rallyPoint.RemoveAt(0);
                            else
                                break;
                        }

                        if (rallyPoint.Count > 0)
                        {
                            double dx = rallyPoint[0].x - robot.x;
                            double dy = rallyPoint[0].y - robot.y;
                            Console.WriteLine((float)(dx));
                            Console.WriteLine((float)(dy));

                            if (Math.Abs(dx) <= Math.Abs(dy))
                                dx = 0;
                            else
                            {
                                dy = 0;
                            }
                           
                            Navigation.i.Go((float)(dx),(float) (-dy));
                        }
                            
                    }
                }
            }
            Render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            route = new RoutePlanner(null,map,null);
            robot = route.RobotPositionFromLasers();
            Console.WriteLine("Robot: {0} {1}",robot.x,robot.y);
            Console.WriteLine("Robot: {0} {1} {2} {3}", route.LL, route.LF, route.RF, route.RR);
            Render();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Ending Navigation");
            Navigation.i.End();
        }

        private void objectRecognitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectRecognitionTestForm test = new ObjectRecognitionTestForm();
            test.Show();
        }

        private void armTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArmControl armControl = new ArmControl();
            armControl.Show();
        }
    }
}