<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="cb29fd70-b4da-4467-8816-f000ffd82c30" namespace="RedNoble.Starmao.Study.Configuration" xmlSchemaNamespace="urn:RedNoble.Starmao.Study.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="RedNobleConfigSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="redNobleConfigSection">
      <elementProperties>
        <elementProperty name="Databases" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="databases" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/DatabaseElementCollection" />
          </type>
        </elementProperty>
        <elementProperty name="EmailClient" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="emailClient" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/EmailClientElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="DatabaseElementCollection" xmlItemName="database" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/DatabaseElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="DatabaseElement">
      <attributeProperties>
        <attributeProperty name="Type" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="type" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="EmailClientElement">
      <attributeProperties>
        <attributeProperty name="Host" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="host" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Port" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="port" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="UserName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="userName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Password" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="password" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="EnableSsl" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enableSsl" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="Sender" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sender" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/cb29fd70-b4da-4467-8816-f000ffd82c30/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>