using SigmaCandidate.DTOs;
using SigmaCandidate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.OtherUtilities
{
    public class HelperMethods
    {
        public static Candidate CreateCandidate()
        {
            return new Candidate
            {
                Id = 2,
                FirstName = "ayoub",
                LastName = "bouiziu",
                //Email = "john.doe@example.com",
                //PhoneNumber = "123-111-9999",
                //CallTime = "Morning",
                Comment = "Testcccomment"
            };
        }

        public static CandidateDto CreateCandidateDto()
        {
            return new CandidateDto
            {
                FirstName = "Ayoub",
                LastName = "Bouizou",
                //Email = "ayoub@gmail.com",
                //PhoneNumber = "111-111-3210",
                //CallTime = "Afternoon",
                Comment = "ccomment"
            };
        }

        public static List<Candidate> GetTestCandidateList()
        {
            var candidates = new List<Candidate>
            {
                new Candidate { Id = 1, FirstName = "Ayoub", LastName = "Bouiz", Email = "ayoub@gmaik.com" },
                new Candidate { Id = 2, FirstName = "Issam", LastName = "Bouiz", Email = "issam.smith@gmail.com" },
                // Add more test candidates as needed
            };
            return candidates;
        }
    }
}
