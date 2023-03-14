using _03_WebApi_With_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace _03_WebApi_With_MongoDB.Services
{
    public class CandidatesService
    {
        private readonly IMongoCollection<Candidate> _candidatesCollection;

        public CandidatesService(
            IOptions<CandidatesDatabaseSettings> candidateStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                candidateStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                candidateStoreDatabaseSettings.Value.DatabaseName);

            _candidatesCollection = mongoDatabase.GetCollection<Candidate>(
                candidateStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Candidate>> GetAsync() =>
            await _candidatesCollection.Find(_ => true).ToListAsync();

        public async Task<Candidate?> GetAsync(string id) =>
            await _candidatesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Candidate newcandidate) =>
            await _candidatesCollection.InsertOneAsync(newcandidate);

        public async Task UpdateAsync(string id, Candidate updatedcandidate) =>
            await _candidatesCollection.ReplaceOneAsync(x => x.Id == id, updatedcandidate);

        public async Task RemoveAsync(string id) =>
            await _candidatesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
