using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;
using SigmaCandidate.Data;
using SigmaCandidate.DTOs;
using SigmaCandidate.Models;
using SigmaCandidate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Services
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateDto>();
                // Add other mappings as needed
            });

            return config.CreateMapper();
        }
    }
    internal class CandidateServiceTests
    {
        private CandidateService _candidateService;
        private Mock<CandidateContext> _mockContext;

        [SetUp]
        public void Setup()
        {
            // Setup mock CandidateContext and DbSet
            _mockContext = new Mock<CandidateContext>();
            var mockDbSet = new Mock<DbSet<Candidate>>();

            // Setup mock DbSet methods
            mockDbSet.Setup(d => d.Add(It.IsAny<Candidate>())).Returns((Candidate c) =>
            {
                var entityEntry = new Mock<EntityEntry<Candidate>>();
                entityEntry.Setup(e => e.Entity).Returns(c);
                return entityEntry.Object;
            });
            mockDbSet.Setup(d => d.FindAsync(It.IsAny<int>())).ReturnsAsync((int id) => new Candidate { Id = id });
            mockDbSet.Setup(d => d.Remove(It.IsAny<Candidate>())).Verifiable();

            _mockContext.Setup(c => c.Candidates).Returns(mockDbSet.Object);

            // Create CandidateService with mock context
            _candidateService = new CandidateService(_mockContext.Object, AutoMapperConfiguration.CreateMapper());
            //

        }

        [Test]
        public async Task AddCandidateAsync_ValidCandidate_ReturnsNewCandidateDto()
        {
            // Arrange
            var candidateDto = new CandidateDto { FirstName = "Ayoub", LastName = "bouizou", Email = "ayoub@gmail.com" };

            // Act
            var result = await _candidateService.AddCandidateAsync(candidateDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(candidateDto.FirstName, result.FirstName);
            Assert.AreEqual(candidateDto.LastName, result.LastName);
            Assert.AreEqual(candidateDto.Email, result.Email);
        }

        [Test]
        public async Task GetCandidateByIdAsync_ExistingId_ReturnsCandidateDto()
        {
            // Arrange
            int existingId = 1;
            var existingCandidate = new Candidate { Id = existingId, FirstName = "ayoub", LastName = "bouizou", Email = "ayoub@gmail.com" };
            _mockContext.Setup(c => c.Candidates.FindAsync(existingId)).ReturnsAsync(existingCandidate);

            // Act
            var result = await _candidateService.GetCandidateByIdAsync(existingId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingId, result.Id);
            Assert.AreEqual(existingCandidate.FirstName, result.FirstName);
            Assert.AreEqual(existingCandidate.LastName, result.LastName);
            Assert.AreEqual(existingCandidate.Email, result.Email);
            // Add more assertions as needed
        }
    }
}
