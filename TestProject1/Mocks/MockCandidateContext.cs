using Microsoft.EntityFrameworkCore;
using Moq;
using SigmaCandidate.Data;
using SigmaCandidate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Mocks
{
    public class MockCandidateContext
    {
        public static Mock<IQueryable<Candidate>> Candidates { get; private set; }

        static MockCandidateContext()
        {
            var candidates = new List<Candidate>
            {
                new Candidate { Id = 1, FirstName = "Ayoub", LastName = "Bouizou" },
                new Candidate { Id = 2, FirstName = "Issam", LastName = "Bouizou" },
            }.AsQueryable();

            Candidates = new Mock<IQueryable<Candidate>>();
            Candidates.As<IQueryable<Candidate>>().Setup(m => m.Provider).Returns(candidates.Provider);
            Candidates.As<IQueryable<Candidate>>().Setup(m => m.Expression).Returns(candidates.Expression);
            Candidates.As<IQueryable<Candidate>>().Setup(m => m.ElementType).Returns(candidates.ElementType);
            Candidates.As<IQueryable<Candidate>>().Setup(m => m.GetEnumerator()).Returns(candidates.GetEnumerator());
        }
    }
}
