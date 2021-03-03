using P01_StudentSystem.Data;

using System;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
        }
    }
}
