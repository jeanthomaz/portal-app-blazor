namespace Persistence;

public class RdsConfig
{
    private string _dbName = "projeto_integrador";
    private string _dbUser = "postgres";
    private string _dbEndpoint = "database-1.cdefwwi9togm.us-east-1.rds.amazonaws.com";
    private int _dbPort = 5432;

    private readonly string _awsRegion = "us-east-1";
    private readonly string _secretName = "rds!db-f92556ec-d3b3-416b-a1fb-9a4ed0f44021";

    public async Task<string> GetConnectionString()
    {
        string password = "wS(iLnzV(xp7%tf$D[wR:98Sv<0_";
        return $"Host={_dbEndpoint};Port={_dbPort};Database={_dbName};Username={_dbUser};Password={password}";
    }
}