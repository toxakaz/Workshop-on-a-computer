﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Task1
{
    public class MyImage
    {
        public const int FileNotExist = 1;
        public const int FileReadError = 2;
        public const int UnexpectedError = 3;
        public const int InvalidInput = 4;
        public const int ImageNotCreated = 5;

        public static int WriteErrorName(int code)
        {
            switch (code)
            {
                case 0:
                    return 0;
                case 1:
                    Console.WriteLine(" > FileNotExist");
                    return 1;
                case 2:
                    Console.WriteLine(" > FileReadError");
                    return 2;
                case 3:
                    Console.WriteLine(" > UnexpectedError");
                    return 3;
                case 4:
                    Console.WriteLine(" > InvalidInput");
                    return 4;
                case 5:
                    Console.WriteLine(" > ImageNotCreated");
                    return 5;
                default:
                    return -1;
            }
        }

        int width;
        int height;
        short bitCount;    //3 or 4

        byte[,,] bitMap;
        bool isСreated = false;
        double[] shadeCoefficient = { 0.299, 0.587, 0.114 };

        public byte GetFromFile(string path)
        {
            try
            {
                Stream reader = File.OpenRead(path);
                Bitmap bitmap = new Bitmap(reader);
                height = bitmap.Height;
                width = bitmap.Width;
                bitCount = 3;
                reader.Close();
                bitMap = new byte[width, height, 3];
                for (int j = 0; j < height; j++)
                    for (int i = 0; i < width; i++)
                    {
                        Color pixel = bitmap.GetPixel(i, j);
                        bitMap[i, j, 0] = pixel.R;
                        bitMap[i, j, 1] = pixel.G;
                        bitMap[i, j, 2] = pixel.B;
                    }
                bitmap.Dispose();
                isСreated = true;
                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte PutInFile(string path)
        {
            try
            {
                Bitmap bitmap = new Bitmap(width, height);
                for (int j = 0; j < height; j++)
                    for (int i = 0; i < width; i++)
                        bitmap.SetPixel(i, j, Color.FromArgb(bitMap[i, j, 0], bitMap[i, j, 1], bitMap[i, j, 2]));

                bitmap.Save(path);
                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        static byte[,] CreateMask(int size, Func<int, int, int> Func)
        {
            if (size <= 0)
                return null;
            if (size % 2 == 0)
                size++;

            byte[,] mask = new byte[size, size];
            int m = size / 2;

            for (int j = -m; j <= m; j++)
                for (int i = -m; i <= m; i++)
                    if (Func(i, j) > 0)
                        mask[i + m, j + m] = 1;
                    else
                        mask[i + m, j + m] = 0;

            return mask;
        }
        public static byte[,] CreateSquareMask(int size)
        {
            int Func(int i, int j)
            {
                return 1;
            }

            return CreateMask(size, Func);
        }
        public static byte[,] CreateCircleMask(int size)
        {
            int Func(int i, int j)
            {
                if (Math.Pow(i, 2) + Math.Pow(j, 2) <= Math.Pow(size / 2, 2))
                    return 1;
                else
                    return 0;
            }

            return CreateMask(size, Func);
        }
        public static byte[,] CreateCrossMask(int size)
        {
            int Func(int i, int j)
            {
                if (i == 0 || j == 0)
                    return 1;
                else
                    return 0;
            }

            return CreateMask(size, Func);
        }
        public static byte[,] CreateDiagonalCrossMask(int size)
        {
            int Func(int i, int j)
            {
                if (Math.Abs(i) == Math.Abs(j))
                    return 1;
                else
                    return 0;
            }

            return CreateMask(size, Func);
        }
        public static byte[,] CreateEmptySquareMask(int size)
        {
            int Func(int i, int j)
            {
                if (Math.Abs(i) == size / 2 || Math.Abs(j) == size / 2)
                    return 1;
                else
                    return 0;
            }

            return CreateMask(size, Func);
        }
        public static byte[,] CreateMaskByCode(int size, int code)
        {
            switch (code)
            {
                case 0:
                    return CreateSquareMask(size);
                case 1:
                    return CreateCircleMask(size);
                case 2:
                    return CreateCrossMask(size);
                case 3:
                    return CreateDiagonalCrossMask(size);
                case 4:
                    return CreateEmptySquareMask(size);
                default:
                    return null;
            }
        }
        double UseMask(int x, int y, int c, double[,] mask, double maxSum)
        {
            int maxX = mask.GetLength(0) / 2;
            int maxY = mask.GetLength(1) / 2;
            double sum = 0;
            for (int j = -maxY; j <= maxY; j++)
                for (int i = -maxX; i <= maxX; i++)
                    if ((y + j) >= 0 && (y + j) < height && (x + i) >= 0 && (x + i) < width)
                        sum += bitMap[x + i, y + j, c] * mask[i + maxX, j + maxY];
                    else
                        maxSum -= mask[i + maxX, j + maxY];
            if (maxSum == 0)
                return -1;
            return sum / maxSum;
        }
        public byte Median(byte[,] maskMap)
        {
            try
            {
                if (!isСreated)
                    return ImageNotCreated;
                if (maskMap.GetLength(0) % 2 == 0 || maskMap.GetLength(1) % 2 == 0)
                    return InvalidInput;

                byte[] arr = new byte[maskMap.Length];
                int len;

                byte[,,] bitMapNew = new byte[width, height, bitCount];

                int maxX = maskMap.GetLength(0) / 2;
                int maxY = maskMap.GetLength(1) / 2;
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                        for (int c = 0; c <= 2; c++)
                        {
                            len = 0;
                            for (int j = -maxY; j <= maxY; j++)
                                for (int i = -maxX; i <= maxX; i++)
                                    if ((y + j) >= 0 && (y + j) < height && (x + i) >= 0 && (x + i) < width && maskMap[i + maxX, j + maxY] != 0)
                                    {
                                        arr[len] = bitMap[x + i, y + j, c];
                                        len++;
                                    }
                            if (len == 0)
                                return InvalidInput;
                            Array.Sort(arr, 0, len);
                            bitMapNew[x, y, c] = arr[len / 2];
                        }
                bitMap = bitMapNew;

                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte Middle(byte[,] maskMap)
        {
            try
            {
                if (!isСreated)
                    return ImageNotCreated;
                if (maskMap.GetLength(0) % 2 == 0 || maskMap.GetLength(1) % 2 == 0)
                    return InvalidInput;

                int count = 0;

                double[,] mask = new double[maskMap.GetLength(0), maskMap.GetLength(1)];

                for (int j = 0; j < maskMap.GetLength(1); j++)
                    for (int i = 0; i < maskMap.GetLength(0); i++)
                        if (maskMap[i, j] != 0)
                        {
                            mask[i, j] = 1;
                            count++;
                        }
                        else
                            mask[i, j] = 0;

                byte[,,] bitMapNew = new byte[width, height, bitCount];
                double code;

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                        for (int c = 0; c <= 2; c++)
                        {
                            code = UseMask(x, y, c, mask, count);
                            if (code >= 0)
                                bitMapNew[x, y, c] = (byte)code;
                            else
                                return InvalidInput;
                        }

                bitMap = bitMapNew;

                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte Gaussian(byte[,] maskMap, double sigma)
        {
            if (sigma <= 0)
                return InvalidInput;
            try
            {
                if (!isСreated)
                    return ImageNotCreated;
                if (maskMap.GetLength(0) % 2 == 0 || maskMap.GetLength(1) % 2 == 0)
                    return InvalidInput;

                int maxX = maskMap.GetLength(0);
                int maxY = maskMap.GetLength(1);
                double[,] kern = new double[maxX, maxY];
                maxX = maxX / 2;
                maxY = maxY / 2;
                double sumKern = 0;
                for (int j = -maxY; j <= maxY; j++)
                    for (int i = -maxX; i <= maxX; i++)
                        if (maskMap[i + maxX, j + maxY] != 0)
                        {
                            kern[i + maxX, j + maxY] = Math.Exp(-(Math.Pow(i, 2.0) + Math.Pow(j, 2.0)) / (2 * Math.Pow(sigma, 2.0))) / (2 * Math.PI * Math.Pow(sigma, 2.0));
                            sumKern += kern[i + maxX, j + maxY];
                        }
                        else
                            kern[i + maxX, j + maxY] = 0;
                if (sumKern == 0)
                    return InvalidInput;

                byte[,,] bitMapNew = new byte[width, height, bitCount];
                double code;

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                        for (int c = 0; c <= 2; c++)
                        {
                            code = UseMask(x, y, c, kern, sumKern);
                            if (code >= 0)
                                bitMapNew[x, y, c] = (byte)code;
                            else
                                return InvalidInput;
                        }

                bitMap = bitMapNew;

                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte Shade()
        {
            try
            {
                double Shade;
                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        Shade = 0;
                        for (int c = 0; c <= 2; c++)
                            Shade += bitMap[x, y, c] * shadeCoefficient[c];
                        for (int c = 0; c <= 2; c++)
                            bitMap[x, y, c] = (byte)Shade;
                    }

                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte Sobel(char type, double threshold)
        {
            try
            {
                if ((type != 'x' && type != 'y' && type != 'c') || threshold <= 0)
                    return InvalidInput;

                double gX = 0;
                double gY = 0;
                double[,] gXMask = new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                double[,] gYMask = new double[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
                //double Shade;

                byte[,,] bitMapNew = new byte[width, height, bitCount];

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                        if (y > 0 && y < height - 1 && x > 0 && x < width - 1)
                        {
                            //Shade = 0;
                            for (int c = 0; c <= 2; c++)
                            {
                                if (type != 'y')
                                    gX = Math.Abs(UseMask(x, y, c, gXMask, 1));
                                if (type != 'x')
                                    gY = Math.Abs(UseMask(x, y, c, gYMask, 1));

                                if (gX < 0 || gY < 0)
                                    return UnexpectedError;

                                if (type == 'x')
                                    bitMapNew[x, y, c] = (byte)gX;
                                else if (type == 'y')
                                    bitMapNew[x, y, c] = (byte)gY;
                                else
                                    bitMapNew[x, y, c] = (byte)Math.Sqrt(Math.Pow(gX, 2) + Math.Pow(gY, 2));
                            }
                            /*
                            if (Shade > 255 / threshold)
                                Shade = 255;
                            else
                                Shade = 0;
                                
                            for (int c = 0; c <= 2; c++)
                                bitMapNew[x, y, c] = (byte)Shade;
                                */
                        }

                bitMap = bitMapNew;

                return 0;
            }
            catch
            {
                return UnexpectedError;
            }
        }
        public byte FilterByCode(int filterType, int size, int mask_type, double sigma, double threshold)
        {
            try
            {
                switch (filterType)
                {
                    case 0:
                        return Median(CreateMaskByCode(size, mask_type));
                    case 1:
                        return Middle(CreateMaskByCode(size, mask_type));
                    case 2:
                        return Gaussian(CreateMaskByCode(size, mask_type), sigma);
                    case 3:
                        return Shade();
                    case 4:
                        return Sobel('x', threshold);
                    case 5:
                        return Sobel('y', threshold);
                    case 6:
                        return Sobel('c', threshold);
                    default:
                        return InvalidInput;
                }
            }
            catch
            {
                return UnexpectedError;
            }
        }
    }
}