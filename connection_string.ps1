param (
  [Parameter(Mandatory = $true)][string]$dbServer,
  [Parameter(Mandatory = $true)][string]$dbDatabase,
  [Parameter(Mandatory = $true)][string]$dbUsername,
  [Parameter(Mandatory = $true)][string]$dbPassword
)

$json = '{
    "ConnectionString": "Server=' + $dbServer + ';Database=' + $dbDatabase + ';User=' + $dbUsername + ';Password=' + $dbPassword + ';"
}'

$json | dotnet user-secrets set