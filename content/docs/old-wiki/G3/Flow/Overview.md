# Flow

Flow is designed to manaage business processes, each application to be processed it refered to as a "case". the Case data is stored by Flow and validated against a Schema

## Schema
A schema discribe the structure of a entity (object) it is made up of the following simple types:
- String - **S**
- Integer - **I**
- Number - **N**
- Date - **D**
- DateTime - **DT**
- Time - **T**
- or another Schema name (complex object) - ***SchemaName***

The Schema runs in two modes:
- Learn: new properties will be detected from case data and a schema item will be created as a S (string)
- Enforec: Case data that can be validated against the schema will be ignored (dropped)

At the stage validation is only where the schema exists or not

A schema item can be marked as "isIndex" which is important for query performance

## Data Storage (SQL Repo)

The FlowRepo's job is to:

- Save and load case data, **G3Flow.Cases**
- Monitor an audit of data changes **G3Flow.CaseAudit**
- Query case data (including indexed properties for performance) **G3Flow.CaseIndexes**

- Import data from CSV & Excel **G3Case.Imports & G3.ImportSummaries**

- Store Schema's **G3Flow.Schemas**
- Store Case Definintions, **G3Flow.Definitions**
- Manage Flow Queues and processing audits **G3Flow.Flows, G3Flow.TriggerQueues & G3Flow.ProcessAudit**

The current version is an an SQL impementaion, the SQL database schema is **G3Flow**

## Flow Definition

The current defintion for a flow is pretty basic
- The primary case data schema name
- The scheme validaiton method (Enforce or Learn)
- Roles to allow data access. (by default a user can only access their own data)


## Flow (process)

A flow represent one process. Each process is initated by a trigger and continues to process the flow until it reaches the end or termiates with an error

One day the flow will be repsented by a visual flow chart

**Current triggers are:**
- When a case property changes to a desired state (Eg status = New) **DataChange**

More to come
- Based on a schedule

- When a human response to a request (approval)

**Current processes are:**
- Populate a PDF (map case data to a templated PDF)
- Send an Email (send the PDF to the customer)

A flow is doumented in YAML or JSON

Example

~~~
caseType: signup
triggerType: DataChanged
runMode: Batch
triggerParams:
   property: status
   value: Sale
nextProcesses:
  - processType: PDFPopulate
    processName: Orcon Application
    continueOnError: false
    params: 
      path: '[G3RootDir]\Acq\Templates'
      pdfName: D2D-Signup-Orcon.pdf
      outputPath: '[G3RootDir]\Acq\Signups'
      outputFileName: Welcome_[signUpId]_[NOW|yyMMdd_HHmmss].pdf
      mapFields:
      - signUpDate|dd/MM/yyyy>Date
      - name>CustomerName 
      - address.formattedAddress>Address
      - address.nzRegion>Region
      - address.postcode>Postcode
      - address.postcode>Postcode
      - customerType|=New>NewCustomer
      - customerType|=Existing>ExistingCustomer
      - dob|dd/MM/yyyy>DOB
      - 'mobile|(##) #### ####>Mobile'
      - email>Email
      - provider>Provider
      - accountNumber>AccountNumber
      - plan.connectionType|=Copper>Copper
      - plan.connectionType|=Fibre>Fibre
      - plan.offer>Offer
      - plan.connectionSpeed>Speed
      - plan.connectionDate|dd/MM/yyyy>ConnectionDate
      - plan.modem|=BYOD>BYODevice
      - plan.modem|=FREE>FreeModem
      - plan.monitoredAlarm>Alarm
      - plan.contractTerm|=12>12MthContract
      - plan.contractTerm|=24>24MthContract
      - plan.monthlyAmount|#,##0.00>PlanMonthly
      - plan.contractTotal|#,##0.00>PlanTotalMth
      - callingPacks.top10>Top10
      - callingPacks.top20>Top20
      - callingPacks.top50>Top50
      - callingPacks.national>National
      - callingPacks.homeLine>HomeLine
      - 'callingPacks.phone|(##) #### ####>PackPhone'
      - callingPacks.monthlyPackAmount|#,##0.00>PackTotalMth
      - callingPacks.land100>Land100
      - callingPacks.land200>Land200
      - callingPacks.land500>Land500
      - callingPacks.monthlyLandAmount|#,##0.00>LandTotalMth
      - mobileOptions.basicPlan>MobileBasic
      - mobileOptions.valuePlan>MobileValue
      - mobileOptions.unlimitedPlan>MobileUnlimited
      - mobileOptions.ultraPlan>MobileUltra
      - mobileOptions.monthlyAmount|#,##0.00>MobileTotalMth
      - addons.addVoicemail>VoiceMail
      - addons.addStaticIp>StaticIP
      - addons.addPrioritySupport>PrioritySupport
      - addons.add4gBackup>4GBackup
      - addons.monthlyAmount|#,##0.00>AddonTotalMth
      - total.etfAmount|#,##0.00>ETFAmount
      - total.monthlyAmount|#,##0.00>ContractTotalMth
      - total.contractTotal|#,##0.00>ContractTotal1224
      - code.medical>CodeMedical
      - code.hasMobile>CodeHasMobile
      - code.mobileCoverage>CodeMobileCover
      - code.assistance>CodeAssistance
      - sign.customerSignature>CustomerSignature
      - signUpDate|dd/MM/yyyy>CustomerSignDate
      - sign.provide111ByAgent>Sign111ByCustomer
      - sign.agentSignature>AgentSignature
      - signUpDate|dd/MM/yyyy>AgentSignDate
      - sign.provide111ToCustomer>Sign111ByAgent
    transposeResults:
      - param.outputFileName>pdfAttachment 
  - processType: Email
    processName: Orcon Application
    continueOnError: false
    params: 
      emailAlias: Signup
      subject: Welcome To Orcon.
      mdTemplate: email/signup
      mapFields:
      - signUpId>RefNo
      - name>Name 
      - email>Email
      attachments:
      - input.pdfAttachment
~~~





