//using System;
//using System.Collections.Generic;
//using System.Linq;
//using KhatoPito.DP;

//namespace KhatoPito
//{
//    public class Programm
//    {
//        public class People
//        {

//            public int Height { get; set; }
//            public int Position { get; set; }
//        }

//        public static void Main()
//        {
//            int[,] people = new int[6, 2] { { 7, 0 }, { 4, 4 }, { 7, 1 }, { 5, 0 }, { 6, 1 }, { 5, 2 } };

//            var peopleList = new List<People>();
//            var len = people.GetLength(0);

//            for (int i = 0; i < len; i++)
//            {

//                peopleList.Add(new People
//                {
//                    Height = people[i, 0],
//                    Position = people[i, 1],
//                });
//            }

//            var sortedPeopleList = peopleList.OrderByDescending(x => x.Height).ThenBy(x => x.Position).ToList();

//            var resultList = new List<People>();
//            foreach (var p in sortedPeopleList)
//            {
//                resultList.Insert(p.Position, p);
//            }

//            var result = new int[len, 2];
//            for (int i = 0; i < len; i++)
//            {
//                result[i, 0] = resultList[i].Height;
//                result[i, 1] = resultList[i].Position;
//            }

//           // return   result;

//            //Console.WriteLine(FindDuplicateNum.FindDuplicate(new int[] { 1, 3, 4, 2, 1, 5 }));
//            //    Console.ReadLine();
//        }

//    }
//}

using System.Collections.Generic;
using System.Linq;

public class People
{

    public int Height { get; set; }
    public int Position { get; set; }
}

public class Solutions
{
    public int[][] ReconstructQueue(int[][] people)
    {

        var peopleList = new List<People>();
        var len = people.GetLength(0);

        for (int i = 0; i < len; i++)
        {

            peopleList.Add(new People
            {
                Height = people[i][0],
                Position = people[i][1],
            });
        }

        var sortedPeopleList = peopleList.OrderByDescending(x => x.Height).ThenBy(x => x.Position).ToList();

        var resultList = new List<People>();
        // this is the key part    
        foreach (var p in sortedPeopleList)
        {
            resultList.Insert(p.Position, p);
        }

        var result = new int[len, 2];
        for (int i = 0; i < len; i++)
        {
            result[i, 0] = resultList[i].Height;
            result[i, 1] = resultList[i].Position;
        }

        var item = result;

        return null;
    }
}