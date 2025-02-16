
# Setup

## Set Location
az account list-location<br/>

az configure --defaults locartion=australiaeast

az configure --defaults resourceGroup=K8Sep22


## Variable Summary
resourceGroup=K8Sep22
vnetName=DevK8VNet
subnetName=DevK8VSubNet1
vnetAddressPrefix=10.0.0.0/16
subnetAddressPrefix=10.0.0.0/24
aksName=cusdev2208
gateway=cusgateway2208
publicIp=cuspubip2208

## Create Resource Group
resourceGroup=K8Sep22
az group create --name=$resourceGroup


## Create virtual network
resourceGroup=K8Sep22
vnetName=DevK8VNet
subnetName=DevK8VSubNet1
vnetAddressPrefix=10.0.0.0/16
subnetAddressPrefix=10.0.0.0/24

az network vnet create \
  --name $vnetName \
  --resource-group $resourceGroup \
  --address-prefixes $vnetAddressPrefix \
  --subnet-name $subnetName \
  --subnet-prefixes $subnetAddressPrefix

## Kubenaties
resourceGroup=K8Sep22
aksName=cusdev2208

NB
- -z 1 no DR


az aks create -g $resourceGroup -n $aksName -z 1 --enable-managed-identity --enable-cluster-autoscaler --min-count 1 --max-count 5 --enable-private-cluster --generate-ssh-keys --vnet-subnet-id=vnetName

NB
- -z 1 no DR

add this later
--attach-acr cusdev 


az aks delete -g $resourceGroup -n $aksName


--outbound-type userDefinedRouting --load-balancer-sku standard 




## Application Gateway

az network public-ip create -g $resourceGroup -n $publicIp

az network application-gateway create -g $resourceGroup -n gateway --capacity 1 --sku Standard_Small --vnet-name vnetName --subnet subnetName --public-ip-address $publicIp --priority 1001


add WAF_v2 later

--capacity 2 --sku Standard_Medium \
    --vnet-name MyVNet --subnet MySubnet --http-settings-cookie-based-affinity Enabled \
    --public-ip-address MyAppGatewayPublicIp --servers 10.0.0.4 10.0.0.5 --priority 1001