# Azure functions walk-through

## Clone this repo

```bash
git clone https://github.com/dsanchor/azure-function-simple-dotnet.git
```

## Initialize environment variables

```bash
RG=<target-rg> # Ex: test-function-rg
LOCATION=<resources-location> # Ex: westeurope
SA=<storage-account-name> # Ex: testfunctionsanport2023sa
FUNCAPP=<func-app-name> #Ex: test-function-sanport
CODE_LOCATION=<cloned-code-location>
```

## Deploy to Azure

### Login to Azure
    
```bash
az login
```

### Create a resource group (if it doesn't exist)    

```bash
az group create --name $RG --location $LOCATION
```

### Create a storage account (if it doesn't exist) 

```bash
az storage account create --name $SA --location $LOCATION --resource-group $RG --sku Standard_LRS
```

### Create a function app
    
```bash
az functionapp create --resource-group $RG --consumption-plan-location $LOCATION --runtime dotnet --functions-version 4 --name $FUNCAPP --storage-account $SA
```

### Build function and publish to Azure

- Navigate to the function app directory
    
```bash
cd $CODE_LOCATION
```

- Publish the function app to Azure
    
```bash
dotnet publish --output ./publish
cd publish
zip publish.zip -r .
az functionapp deployment source config-zip --resource-group $RG --name $FUNCAPP --src ./publish.zip
```

### Test the function

curl https://$FUNCAPP.azurewebsites.net/HttpHello