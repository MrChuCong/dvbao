using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using System.Text;
using System.Drawing;
using Cogitance.DVizion;

namespace WrongWayDrivingDetector
{
    public class Detector
    {
        private dvImageM dvImage;
        private byte[] background;
        private byte[] current;
        private byte[] mask;
        private byte[] tmp;
        private Queue<int> queue;
        private List<Rectangle> objects;
        private List<Rectangle> optimizedObjects;
        private List<Rectangle> wrongWayVehicles;
        private bool firstFrame;
        private int size;
        private int maskSize;
        private int width;
        private int height;
        private int count;
        private int minx;
        private int maxx;
        private int miny;        
        private int maxy;
        private byte[] color = { 255, 255, 0, 0 };
        private int refreshRate = 3;
        private int refreshPercent = 50;
        private byte thresholdValue = 20;
        private int minPixel = 100;
        private int minSize = 20;
        private int optimizedMinSize = 50;
        private int maxObjects = 5;
        private int t = 3;
        private int m = 8;
        private int h = 800;

        #region Properties

        public int RefreshRate
        {
            get { return refreshRate; }
            set { refreshRate = value; }
        }

        public int RefreshPercent
        {
            get { return refreshPercent; }
            set
            {
                if (1 <= value && value <= 99) refreshPercent = value;
            }
        }
                
        public byte ThresholdValue
        {
            get { return thresholdValue; }
            set { thresholdValue = value; }
        }

        public int MinPixel
        {
            get { return minPixel; }
            set { minPixel = value; }
        }

        public int MinSize
        {
            get { return minSize; }
            set { minSize = value; }
        }

        public int OptimizedMinSize
        {
            get { return optimizedMinSize; }
            set { optimizedMinSize = value; }
        }

        public int MaxObjects
        {
            get { return maxObjects; }
            set { maxObjects = value; }
        }

        public int T
        {
            get { return t; }
            set { t = value; }
        }

        public int M
        {
            get { return m; }
            set { m = value; }
        }

        public int H
        {
            get { return h; }
            set { h = value; }
        }

        #endregion

        public Detector(int size, int width, int height)
        {
            this.dvImage = new dvImageM();
            this.background = new byte[size];
            this.current = new byte[size];
            this.mask = new byte[size / 3];
            this.tmp = new byte[size / 3];
            this.queue = new Queue<int>();
            this.objects = new List<Rectangle>();
            this.optimizedObjects = new List<Rectangle>();
            this.wrongWayVehicles = new List<Rectangle>();
            this.firstFrame = true;
            this.size = size;
            this.maskSize = size / 3;
            this.width = width;
            this.height = height;
            this.count = 0;
        }

        public bool Apply(IntPtr buffer)
        {
            if (firstFrame)
            {
                Marshal.Copy(buffer, background, 0, size);
                firstFrame = false;
                return false;
            }
            Marshal.Copy(buffer, current, 0, size);
            Morph();
            Difference();
            Threshold();
            Erosion();
            ScanObjects();
            OptimizeObjects();
            ScanWrongWayVehicles();            
            dvImage.Initialize(buffer, width, height);
            dvImage.GDIBegin();
            foreach (Rectangle rectangle in wrongWayVehicles)
            {
                dvImage.GDIRectangle(rectangle.Left, rectangle.Top,
                    rectangle.Right, rectangle.Bottom, color, 3);
            }
            dvImage.GDIEnd();
            return wrongWayVehicles.Count > 0;
        }

        private void Morph()
        {
            if (count++ == refreshRate)
            {
                count = 0;
                for (int i = 0; i < size; i++)
                {
                    background[i] = (byte)
                        ((background[i] * (100 - refreshPercent) +
                        current[i] * refreshPercent) / 100);
                }
            }
        }

        private void Difference()
        {
            int p1 = 0;
            int p2 = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int red = Math.Abs(current[p1] - background[p1]);
                    p1++;
                    int green = Math.Abs(current[p1] - background[p1]);
                    p1++;
                    int blue = Math.Abs(current[p1] - background[p1]);
                    p1++;
                    int max = red;
                    if (green > max) max = green;
                    if (blue > max) max = blue;
                    mask[p2++] = (byte)max;
                }
            }
        }

        private void Threshold()
        {
            for (int i = 0; i < maskSize; i++)
            {
                if (mask[i] > thresholdValue) mask[i] = 255;
                else mask[i] = 0;
            }
        }

        private void Erosion()
        {
            mask.CopyTo(tmp, 0);
            int p = width + 1;
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    if (mask[p] == 0 || mask[p - 1] == 0 || mask[p + 1] == 0 ||
                        mask[p - width] == 0 || mask[p + width] == 0) tmp[p] = 0;
                    p++;
                }
                p += 2;
            }
            tmp.CopyTo(mask, 0);
        }

        private void ScanObjects()
        {
            objects.Clear();
            mask.CopyTo(tmp, 0);
            int p = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (tmp[p] == 255)
                    {
                        queue.Clear();
                        queue.Enqueue(p);
                        tmp[p] = 0;
                        minx = height + 1;
                        maxx = -1;
                        miny = width + 1;
                        maxy = -1;
                        int num = 1;
                        while (queue.Count > 0)
                        {
                            int x = queue.Dequeue();
                            num++;
                            Visit(x);
                        }
                        if (num > minPixel && maxx - minx > minSize && maxy - miny > minSize)
                        {
                            objects.Add(new Rectangle(
                                miny, height - maxx, maxy - miny, maxx - minx));
                        }
                    }
                    p++;
                }
            }
        }

        private void Visit(int index)
        {
            int x = index / width;
            int y = index % width;
            if (x < minx) minx = x;
            if (x > maxx) maxx = x;
            if (y < miny) miny = y;
            if (y > maxy) maxy = y;
            if (x > 0 && tmp[index - width] == 255)
            {
                queue.Enqueue(index - width);
                tmp[index - width] = 0;
            }
            if (x < height - 1 && tmp[index + width] == 255)
            {
                queue.Enqueue(index + width);
                tmp[index + width] = 0;
            }
            if (y > 0 && tmp[index - 1] == 255)
            {
                queue.Enqueue(index - 1);
                tmp[index - 1] = 0;
            }
            if (y < width - 1 && tmp[index + 1] == 255)
            {
                queue.Enqueue(index + 1);
                tmp[index + 1] = 0;
            }
        }

        private int Compare(Rectangle rect1, Rectangle rect2)
        {
            int s1 = rect1.Width * rect1.Height;
            int s2 = rect2.Width * rect2.Height;
            if (s1 == s2) return 0;
            if (s1 > s2) return -1;
            return 1;
        }

        private void OptimizeObjects()
        {
            optimizedObjects.Clear();
            bool[] free = new bool[objects.Count];
            for (int i = 0; i < free.Length; i++) free[i] = true;
            for (int i = 0; i < objects.Count; i++)
            {
                if (free[i])
                {
                    free[i] = false;
                    Rectangle rect = objects[i];
                    for (int j = i + 1; j < objects.Count; j++)
                    {
                        if (free[j] && rect.IntersectsWith(objects[j]))
                        {
                            free[j] = false;
                            if (objects[j].X < rect.X) rect.X = objects[j].X;
                            if (objects[j].Y < rect.Y) rect.Y = objects[j].Y;
                            if (objects[j].Right > rect.Right) rect.Width =
                                objects[j].Right - rect.X;
                            if (objects[j].Bottom > rect.Bottom) rect.Height =
                                objects[j].Bottom - rect.Y;
                        }
                    }
                    if (rect.Left > width / 5 &&
                        rect.Top > height / 5 &&
                        rect.Right < width * 4 / 5 &&
                        rect.Width > optimizedMinSize && rect.Height > optimizedMinSize)
                    {
                        optimizedObjects.Add(rect);
                    }
                }
            }
            if (optimizedObjects.Count > maxObjects)
            {
                optimizedObjects.Sort(Compare);
                optimizedObjects.RemoveRange(maxObjects, optimizedObjects.Count - maxObjects);
            }
        }

        private void ScanWrongWayVehicles()
        {
            wrongWayVehicles.Clear();
            foreach (Rectangle rectangle in optimizedObjects)
            {
                int left = CountPixel(rectangle.Top, rectangle.Bottom,
                    rectangle.Left, ((m - t) * rectangle.Left + t * rectangle.Right) / m);
                int right = CountPixel(rectangle.Top, rectangle.Bottom,
                    (t * rectangle.Left + (m - t) * rectangle.Right) / m, rectangle.Right);
                if (right - left > h)
                {
                    wrongWayVehicles.Add(rectangle);
                }
            }
        }

        private int CountPixel(int top, int bottom, int left, int right)
        {
            int result = 0;
            for (int i = top; i <= bottom; i++)
            {
                for (int j = left; j <= right; j++)
                {
                    if (mask[(height - i) * width + j] == 255) result++;
                }
            }
            return result;
        }
    }
}
