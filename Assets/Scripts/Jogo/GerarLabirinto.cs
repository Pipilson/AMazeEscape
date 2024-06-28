using System.Collections.Generic;
using UnityEngine;

public static class GerarLabirinto
{
    static int height;
    static int width;
    static int[][] maze;
    static public string generateMaze(int h, int w)
    {
        height = h;
        width = w;
        height = height % 2 == 0 ? height + 1 : height;
        width = width % 2 == 0 ? width + 1 : width;
        maze = new int[height][];

        for (int i = 0; i < height; i++)
        {
            maze[i] = new int[width];
            for (int j = 0; j < width; j++)
                maze[i][j] = 1;
        }

        //Random rand = new Random();
        int r = Random.Range(0, height);

        while (r % 2 == 0)
        {
            r = Random.Range(0, height);
        }

        int c = Random.Range(0, width);

        while (c % 2 == 0)
        {
            c = Random.Range(0, width);
        }

        maze[r][c] = 0;
        recursion(r, c);
        maze[1][1] = 0;
        maze[height - 2][width - 2] = 3;
        string str = "";

        for (int i = 0; i < maze.Length; i++)
        {
            for (int j = 0; j < maze[i].Length; j++)
            {
                str = string.Concat(str, maze[i][j].ToString());
            }

            str = string.Concat(str, "\r\n");
        }

        return str;
    }

    static public void recursion(int r, int c)
    {
        int[] randDirs = generateRandomDirections();

        for (int i = 0; i < randDirs.Length; i++)
        {
            switch (randDirs[i])
            {
                case 1:

                    if (r - 2 <= 0)
                    {
                        continue;
                    }

                    if (maze[r - 2][c] != 0)
                    {
                        maze[r - 2][c] = 0;
                        maze[r - 1][c] = 0;
                        recursion(r - 2, c);
                    }

                    break;

                case 2:

                    if (c + 2 >= width - 1)
                    {
                        continue;
                    }

                    if (maze[r][c + 2] != 0)
                    {
                        maze[r][c + 2] = 0;
                        maze[r][c + 1] = 0;
                        recursion(r, c + 2);
                    }

                    break;

                case 3:

                    if (r + 2 >= height - 1)
                    {
                        continue;
                    }

                    if (maze[r + 2][c] != 0)
                    {
                        maze[r + 2][c] = 0;
                        maze[r + 1][c] = 0;
                        recursion(r + 2, c);
                    }

                    break;

                case 4:

                    if (c - 2 <= 0)
                    {
                        continue;
                    }

                    if (maze[r][c - 2] != 0)
                    {
                        maze[r][c - 2] = 0;
                        maze[r][c - 1] = 0;
                        recursion(r, c - 2);
                    }

                    break;
            }
        }
    }

    static public int[] generateRandomDirections()
    {
        List<int> randoms = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            randoms.Add(i + 1);
        }

        Shuffle(randoms);
        return randoms.ToArray();

    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}