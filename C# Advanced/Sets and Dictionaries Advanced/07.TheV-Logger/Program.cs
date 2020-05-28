using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var followersOfVlogger = new Dictionary<string, SortedSet<string>>();
            var vLoggerFollowing = new Dictionary<string, HashSet<string>>();


            while (true)
            {
                var command = Console.ReadLine()
                    .Split(new char[] { ' ' }
                    , StringSplitOptions.
                    RemoveEmptyEntries);

                if (command[0] == "Statistics")
                {
                    break;
                }

                else if (command[1] == "joined")
                {
                    var vLoggerName = command[0];
                    if (!followersOfVlogger.ContainsKey(vLoggerName))
                    {
                        followersOfVlogger[vLoggerName] = new SortedSet<string>();
                        vLoggerFollowing[vLoggerName] = new HashSet<string>();
                    }

                }
                else if (command[1] == "followed")
                {
                    var vLoggerName1 = command[0];
                    var vLoggerName2 = command[2];
                    if (followersOfVlogger.ContainsKey(vLoggerName1)
                        && followersOfVlogger.ContainsKey(vLoggerName2)
                        && vLoggerName1 != vLoggerName2)
                    {
                        followersOfVlogger[vLoggerName2].Add(vLoggerName1);
                        vLoggerFollowing[vLoggerName1].Add(vLoggerName2);
                    }
                }
            }
            Console.WriteLine("The V-Logger has a total of {0} vloggers in its logs."
                , followersOfVlogger.Count);

            followersOfVlogger = followersOfVlogger
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vLoggerFollowing[x.Key].Count)
                .ToDictionary(a => a.Key, b => b.Value);
            int counter = 1;

            var mostFamousVlogger = followersOfVlogger.First();
            var mostFamousVloggerName = mostFamousVlogger.Key;
            var mostFamousVLoggerFollowers = mostFamousVlogger.Value;
            var mostFamousVLoggerFollowingsCount = vLoggerFollowing[mostFamousVloggerName].Count;
            Console.WriteLine("{0}. {1} : {2} followers, {3} following"
                , counter++
                , mostFamousVloggerName
                , mostFamousVLoggerFollowers.Count
                , mostFamousVLoggerFollowingsCount);

            foreach (var follower in mostFamousVLoggerFollowers)
            {
                Console.WriteLine("*  {0}", follower);
            }

            foreach (var vlogger in followersOfVlogger.Skip(1))
            {
                Console.WriteLine("{0}. {1} : {2} followers, {3} following"
                    , counter++
                    , vlogger.Key
                    , followersOfVlogger[vlogger.Key].Count
                    , vLoggerFollowing[vlogger.Key].Count);
            }

        }
    }
}
