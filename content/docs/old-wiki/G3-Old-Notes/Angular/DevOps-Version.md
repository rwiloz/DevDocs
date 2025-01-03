# DevOps - Angular Version

## The Angular version is now required as part of the YAML build process

Angular builds without this will get an <font color="red">InternalServerError</font> when the build process tries to store the package

This will extract the angular version from the package.json and submit it with the package to G3

1/ Add the following "Build" Task just before the NPM Install task

```
    - task: PowerShell@2
      name: setvar
      displayName: 'Set ngVer'
      inputs:
        targetType: 'inline'
        script: node -p "require('./package.json').dependencies['@angular/core']" > ngVer.txt; $ngVer= Get-Content -Path .\ngVer.txt; Write-Host "##vso[task.setvariable variable=ngVer;isOutput=true]$ngVer"
```

2/ Add a new ngVer variable to the "Deployment" section after the physicalPath
```
      physicalPath: 'E:\WebImage\Sites\G3Dev\Sites\$(webClient)\$(webApp)'
      ngVer: $[stageDependencies.Build_Stage.Build_Job.outputs['setvar.ngVer']]
```
3/ Update the "Deployement" Store Package task (add the last param)

```
          - task: CmdLine@2
            displayName: 'Store Package'
            inputs:
              script: 'e:\deployment\app\deployment $(Pipeline.Workspace)\app\application.zip angular $(webClient) $(webApp) $(appName) $(Build.BuildId) $(ngVer)'
```

Full Example

```
trigger:
- master
- feature/*

variables:
  feed: 'CommunicationServicesCUS/G3Npm'
  #Custom
  appName: 'BusinessName-ApplicationName'
  webClient: 'BusinessName'
  webApp: 'ApplicationName'

stages:
- stage: 'Build_Stage'
  displayName: 'Build'
  variables:
    buildOutputFolder: 'dist'

  jobs:
  - job: Build_Job
    pool:
      vmImage: 'windows-latest'

    steps:
    - task: NodeTool@0
      displayName: 'Install Node.js'
      inputs:
        versionSpec: '14.x'

    - task: PowerShell@2
      name: setvar
      displayName: 'Set ngVer'
      inputs:
        targetType: 'inline'
        script: node -p "require('./package.json').dependencies['@angular/core']" > ngVer.txt; $ngVer= Get-Content -Path .\ngVer.txt; Write-Host "##vso[task.setvariable variable=ngVer;isOutput=true]$ngVer"
        
    - task: Npm@1
      displayName: 'npm Install'
      inputs:
        verbose: false
        customRegistry: useFeed
        customFeed: '$(feed)'
      
    - task: Npm@1
      displayName: 'ng Build'
      inputs:
        command: custom
        verbose: false
        customCommand: 'run build'
        customRegistry: useFeed
        customFeed: '$(feed)'

    - task: CopyFiles@2
      displayName: 'Copy to Staging'
      inputs:
        sourceFolder: '$(buildOutputFolder)' 
        contents: '**/*' 
        targetFolder: '$(Build.ArtifactStagingDirectory)/application'
        cleanTargetFolder: true

    - task: ArchiveFiles@2
      displayName: 'Archive/zip'
      inputs:
        rootFolderOrFile: $(Build.ArtifactStagingDirectory)/application/$(appName)
        archiveType: 'zip'
        archiveFile: '$(Build.ArtifactStagingDirectory)/app/application.zip'
        includeRootFolder: false

    - task: PublishBuildArtifacts@1
      displayName: 'Publish Artifact'
      inputs:
        pathtoPublish: '$(build.artifactstagingdirectory)\app\application.zip' 
        artifactName: 'app'

- stage: 'Staging_Dev' 
  displayName: 'Development' 
  dependsOn: ['Build_Stage'] 
  jobs:
  - deployment: Deploy_Staging 
    displayName: Staging Deployment
    environment: Development
    variables:
      physicalPath: 'E:\WebImage\Sites\G3Dev\Sites\$(webClient)\$(webApp)'
      ngVer: $[stageDependencies.Build_Stage.Build_Job.outputs['setvar.ngVer']]

    pool: NonProdInternal
    strategy:
      runOnce:
        deploy:
          steps:
          - download: current
            artifact: 'app'

          - task: ExtractFiles@1
            displayName: 'Extract files'
            inputs:
              archiveFilePatterns: '$(Pipeline.Workspace)/app/application.zip'
              destinationFolder: '$(physicalPath)'
              cleanDestinationFolder: true

          - task: CmdLine@2
            displayName: 'Store Package'
            inputs:
              script: 'e:\deployment\app\deployment $(Pipeline.Workspace)\app\application.zip angular $(webClient) $(webApp) $(appName) $(Build.BuildId) $(ngVer)'

```