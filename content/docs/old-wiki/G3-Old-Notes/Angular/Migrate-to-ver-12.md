# Angular migration to ver 12

Compare folder to C:\Code\G3\G3.Template\G3.Web.BusinessName.Application

`git clone https://dev.azure.com/CTS-Bradfield/CommunicationServicesCUS/_git/G3.Template`

---

##  Polyfills

Check for IE
- /src/polyfills.ts

---

##  Browser List
**Delete**

- /src/browserslist
- /browserslist

**New one to use**

- /browserslistrc

---

## angular.json

Compare as there are a number of changes, the template has been updated to reflect a new "out of the box" config

- schematics
- inline scss
- evironment defaults
- lots of config option changes
- tsConfig name changes

---

## Index.html

update fonts for material icons

---

## Other Updates
Replace
- tslint.json
- tsconfig.json
- tsconfig.app.json

Update - check and align
- package.json
update build script 
`"build": "ng build -c production",`

update node version
- azure-pipelines.yml (update to ver 14.x)

```
  steps:
    - task: NodeTool@0
      displayName: 'Install Node.js'
      inputs:
        versionSpec: '14.x'
```

---

## SASS

Fix SASS errors
