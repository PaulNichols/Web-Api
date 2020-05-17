
#to get going follow http://mlogdberg.com/apimanagement/arm-template-creator


#if you have problems with execution policy execute powershell as an administrator
Set-ExecutionPolicy -ExecutionPolicy Unrestricted

Install-Module -Name APIManagementTemplate
Update-Module -Name APIManagementTemplate

#Set the name of the API Mangement instance
$apimanagementname = 'pauln-apim-racq-breakfix-01-ase'

#Set the resource group 
$resourcegroupname = 'Rg-AE-ICC-PaulN'

#Set the subscription id 
$subscriptionid = '9be925a1-1eab-4b41-9225-eb95d8573933'

#Set the tenant to use when login ing, make sure it has the right tennant
$tenant = 'racq.onmicrosoft.com'

#optional set filter for a specific api (using standard REST filter, with path we can select api based on the API path)
$filter = "path eq 'vehicles'"

 
#setting the output filename
$filenname = 'apim.apis.json'

## How to install armclient odcumented here https://github.com/projectkudu/ARMClient
## hard coded client ip/secret of the Octopus Service principle if necessary
#armclient spn $tenant fed3e8aa-4b79-40ca-9755-273d9fb02c7f +fF+Etk28VdTO/aO0g0ewdaQp2Yq9NefHwEnbEYrdWc=
#armclient token subscription
#$token=Get-Clipboard

#Get-APIManagementTemplate  -APIManagement $apimanagementname -FixedServiceNameParameter $true -ParametrizePropertiesOnly $true -ExportAuthorizationServers 1 -APIFilters $filter -ResourceGroup $resourcegroupname -SubscriptionId $subscriptionid -TenantName $tenant -ExportPIManagementInstance $false -Token $token | Out-File $filenname

Get-APIManagementTemplate  -APIManagement $apimanagementname -FixedServiceNameParameter $true -ParametrizePropertiesOnly $true -ExportAuthorizationServers 1 -APIFilters $filter -ResourceGroup $resourcegroupname -SubscriptionId $subscriptionid -TenantName $tenant -ExportPIManagementInstance $false  | Out-File $filenname