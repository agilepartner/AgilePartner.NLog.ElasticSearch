# AgilePartner.NLog.ElasticSearch
An NLog extension to use elasticSearch as logging target on .NET Core.

To use it follow the steps below :

## 1) Install the nuget package :
Install-Package AgilePartner.NLog.ElasticSearch

## 2) Update your nlog configuration file
  - add the elasticSearch extension
  - add the elasticSearch target
  - define a new rule

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      autoReload="true"
      internalLogLevel="Warn"
      internalLogFile="c:\temp\internal-nlog.txt">

  <extensions>
    <add assembly="AgilePartner.NLog.ElasticSearch"/>
  </extensions>
  
  <targets>
      <target name="elastic"
              xsi:type="ElasticSearch"
              layout="${logger} | ${threadid} | ${message} | ${uppercase:${level}} | ${newline} ${exception:format=ToString,StackTrace}"
              uri="http://localhost:9200" 
              index="myapplicationlogs"
              documentType="LogEntry"></target>
  </targets>
  <rules>
    <logger name="*" minlevel="Info" writeTo="elastic"/>
  </rules>
</nlog>
```

## Parameters

You have to provide 3 parameters in the target part :
- *uri* : the uri of your elasticSearch node
- *index* :  the index to write to
- *documentType* : the document type to use

If there is any issue during the logging in elasticSearch it will be logged by NLog in the "internalLogFile" defined in the configuration file.
