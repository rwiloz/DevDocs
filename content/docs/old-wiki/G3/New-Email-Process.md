# New G3 Email process

There are currently three ways email can be sent in G3
- The **Origional** way with a EmailConfig and EmailSendConfig (along with a bunch of settings)
- **Simplified** way with and Alias (JSON setup in a setting)
- New **Template** way using the Email.EmailG3Settings table


### The new way - Prerequisites

- Client Setting for G3RootDir, example \\\\csofile2\SWMDevelopment\Server\UWater  
- SystemSetting EmailSendUpgrade=Y to enable this

## EmailG3Settings
It will take two passes to migrate the settings, the first pass will create the settings

|Column|Comment|
|-|-|
|AppCode|Either the Appcode or client code|
|EmailCode|During migratin this is taken from the MD template name, Eg NewDevice|
|FromConfig|Link to the Email.EmailConfig table (NB this can be a fake email address)|
|Subject|Email Subject, this can be templated using eg [[RefNo]]|
|PreviewText|used by GMail & Outlook, it's set during migration, it can be templated|
|Category|Using the Email table|
|CC|Option copy of the email, can be multiple address using ;|
|HtmlTemplate|CMS HTML template to use for the main structure|
|MdTemplate|CSM Markdown template to use for the body insert|
|EmbeddedFolder|User to store embedded image etc|
|AttachmentFolder|Default folder to find attachments|
|FieldNames|This is updated with each email and is informaiton that can be used later|

### UnityWater Migration
- Trigger all emails so the settings can be migrated
- Remove the "white" html at the top of the MD templates
- Update the PreviewText in the EmailG3Settings table










