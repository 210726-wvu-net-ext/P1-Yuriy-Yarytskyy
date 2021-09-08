using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.SqlServer;
using Entity = BakeryShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop.UnitTests.DL
{
    public class RepositoryTest
    {
        public class CheckAdmin
        {
            [Fact]
            public void AdminTest()
            {
                bool login = false;
                string adminUN = "ADMIN";
                string adminUP = "CODE";

                string expectedUN = "ADMIN";
                string expectedUP = "CODE";
                if (adminUN == expectedUN && adminUP == expectedUP)
                {
                    bool outcome = true;
                    Assert.True(outcome);
                }

            }
        }

        public class IsAdmin
        {
            [Fact]
            public void CheckIfUserAdmin()
            {
                bool login = false;
                string adminUN = "ADMIN";
                string adminUP = "CODE";
                string[] userNames = {"John", "Paul", "Yuriy", "ADMIN"};

                for (int i = 0; i < userNames.Length; i++)
                {
                    if (userNames[i] == adminUN)
                    {
                        login = true;
                    }
                }
            }
        }

        public class IsAdminPasswor
        {
            [Fact]
            public void CheckPassword()
            {
                bool login = true;
                string adminUN = "ADMIN";
                string adminUP = "CODE";
                string[] userPasswords = {"PASSword", "NULLL", "Passcode", "Code"};

                for (int i = 0; i < userPasswords.Length; i++)
                {
                    if (userPasswords[i] == adminUP)
                    {
                        login = false;
                    }
                }
            }
        }

        public class TestRatingAvg
        {
            [Fact]
            public void TestRating()
            {
                int sum = 0;
                int tracker = 0;
                decimal actual, expected;
                decimal[] NumOfRatings = { 4, 3, 2, 1, 5, 5, 5, 3, 4, 4, 1, 3, 4, 5, 3 };

                for (int i = 0; i < NumOfRatings.Length; i++)
                {
                    sum += i;
                    tracker++;
                }
                actual = sum / tracker;
                expected = 3.46m;
                if (actual == expected)
                {
                    bool outcome = true;
                    Assert.True(outcome);
                }
            }


        }

        public class TestRatingRange
        {
            [Fact]
            public void TestRating()
            {
                int rating = 6;
                bool result = true;

                if (rating > 5)
                {
                    result = false;
                }

                Assert.False(result, "Rating range is 1-5");
            }

        }
    }
}
   

