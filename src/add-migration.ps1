param (
    [string]$MigrationName
)

if (-not $MigrationName) {
    Write-Host "Please provide a migration name."
    exit 1
}

# Define paths
$apiProjectPath = "vigilant-umbrella-api"
$infrastructureProjectPath = "vigilant-umbrella-infrastructure"

# Define the environment
$env:ASPNETCORE_ENVIRONMENT = "Development"

# Run migrations
dotnet ef migrations add $MigrationName --project $infrastructureProjectPath --startup-project $apiProjectPath